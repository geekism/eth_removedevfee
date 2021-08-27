using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using WinDivertSharp;

namespace PhoenixMinerBoost
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            var walletAddr = string.Empty;
            var portFilter = string.Empty;
            byte[] pattern = null;
            byte[] replacement = null;
            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                switch (arg)
                {
                    case "-p":
                        portFilter = args[i + 1].Split(",").Select(port => "tcp.DstPort == " + port).Aggregate((a, b) => a + " || " + b);
                        Console.WriteLine(DateTime.Now + ": Using Portfilter from -p argument: " + portFilter);
                        break;
                    case "-w":
                        walletAddr = args[i + 1];
                        Console.WriteLine(DateTime.Now + ": Using wallet address from -w argument: " + walletAddr);
                        break;
                    case "-s":
                        pattern = Encoding.ASCII.GetBytes(args[i + 1]);
                        Console.WriteLine(DateTime.Now + ": Using pattern from -s argument: " + args[i + 1]);
                        break;
                    case "-r":
                        replacement = Encoding.ASCII.GetBytes(args[i + 1]);
                        Console.WriteLine(DateTime.Now + ": Using replacement from -r argument: " + args[i + 1]);
                        break;
                }
            }
            try
            {
                new TcpClient().Connect("eu1.ethermine.org", 5555);
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode != SocketError.AccessDenied)
                {
                    Console.WriteLine(DateTime.Now + ": Make sure to block outgoing SSL-Ports in your firewall (for example: 5555 for ethermine).");
                }
            }

            if (string.IsNullOrEmpty(walletAddr))
            {
                Console.WriteLine(DateTime.Now + ": Trying to read wallet address from wallet.txt ...");
                var fileContent = File.ReadAllLines("./wallet.txt");
                if (fileContent.Length != 1 || fileContent[0].Length != 42)
                {
                    throw new InvalidDataException("Failed to read wallet address: " + fileContent);
                }

                walletAddr = fileContent[0];
                Console.WriteLine(DateTime.Now + ": Using wallet address from wallet.txt: " + walletAddr);
            }

            if (portFilter == string.Empty)
            {
                portFilter = "tcp.DstPort == 4444 || tcp.DstPort == 14444";
                Console.WriteLine(DateTime.Now + ": Using Portfilter: " + portFilter);
            }

            if (pattern == null)
            {
                pattern = Encoding.ASCII.GetBytes("eth_submitLogin");
                Console.WriteLine(DateTime.Now + ": Using default pattern: eth_submitLogin");
            }

            if (replacement == null)
            {
                replacement = Encoding.ASCII.GetBytes("0x");
                Console.WriteLine(DateTime.Now + ": Using default replacement: 0x");
            }

            var handle =
                WinDivert.WinDivertOpen(portFilter, WinDivertLayer.Network, -1000, WinDivertOpenFlags.None);
            if (handle == (IntPtr) (-1))
            {
                throw new IOException("Unable to open network-stream. Did you run as Administrator?");
            }
            WinDivert.WinDivertSetParam(handle, WinDivertParam.QueueLen, 8192);
            WinDivert.WinDivertSetParam(handle, WinDivertParam.QueueTime, 2048);

            var buffer = new WinDivertBuffer(0xFFFF);
            WinDivertAddress address = default;
            uint readLength = 0;

            Console.WriteLine(DateTime.Now + ": Booster initialized! Now just keep it running...");
            while (true)
            {
                if (WinDivert.WinDivertRecv(handle, buffer, ref address, ref readLength))
                {
                    var packet = WinDivert.WinDivertHelperParsePacket(buffer, readLength);
                    var tcpHeader = packet.TcpHeader;
                    if (tcpHeader != null)
                    {
                        switch (address.Direction)
                        {
                            case WinDivertDirection.Outbound:
                            {
                                if (packet.PacketPayloadLength > 0)
                                {
                                    var span = new Span<byte>(packet.PacketPayload, (int)packet.PacketPayloadLength);
                                    if (span.IndexOf(pattern) >= 0)
                                    {
                                        Encoding.ASCII.GetBytes(walletAddr).AsSpan().CopyTo(span.Slice(span.IndexOf(replacement), walletAddr.Length));
                                        WinDivert.WinDivertHelperCalcChecksums(buffer, readLength, WinDivertChecksumHelperParam.All);
                                        Console.WriteLine(DateTime.Now + ": Boost successfull!");
                                    }
                                }
                                break;
                            }
                        }
                    }

                    WinDivert.WinDivertSend(handle, buffer, readLength, ref address);
                }
            }
        }
    }
}