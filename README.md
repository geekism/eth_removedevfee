## Version:</br>
<b>PhoenixMinerBoost.exe</b>: Doesnt have the <b>-s</b> flag, made just for ethereum based mining only.</br></br>
<b>PhoenixMinerBoost-2.2.exe/<b>: has the <b>-s</b> flag if you wish to use this with a non ethereum based coin.</br>
You would specify the "<b>String</b>" found in the wireshark traffic dump.</br>
It defaults to <b>eth_submitLogin</b> if <b>-s is not used</b>.</br></br>

## Compatible with:</br>
PhoenixMiner5.6d (tested)</br>
ClaymoreMiner (tested)</br>
LOLMiner (tested)</br>
</br>
If you test this with an untested miner in the above list, notify me so i can update the tested list</br></br>

This only works on ethereum/ethereum classic or any ethereum based pool.</br>
as long as it sends eth_submitLogin. it will work.</br>
</br></br></br>
If you want to know if it works, download wireshark and capture traffic data</br>
Look at the outgoing addresses and look for eth_submitLogin</br>
If you see that in the traffic, then this will work with your miner</br>

Download Windows .net 3.1</br></br>
[DotNet 3.1 Direct Download](https://download.visualstudio.microsoft.com/download/pr/639f7cfa-84f8-48e8-b6c9-82634314e28f/8eb04e1b5f34df0c840c1bffa363c101/dotnet-sdk-3.1.100-win-x64.exe)

## Create a bat file with this inside

```
   @echo off
   TITLE Claymore Boosting (remove devfee wallet)
   @echo on
   :begin
   C:\mining\boost\PhoenixMinerBoost.exe -p 4444,14444,9999,19999 -w change_me_to_your_wallet
   TIMEOUT /t 5
   goto begin
   pause
```
Make sure you change the path in the above to where you saved it.</br>
Then block the mining pools SSL port by doing the below.</br>

## How to block a port in windows 7/8/10
```
To block all TCP and UDP on port 5555 by windows defender firewall inbound and outbound rule, you could follow the steps:

1. Control panel > System and Security > Windows Firewall > Advanced settings
2. Right-click Outbound Rules and click new rule.
3. Choose Port and next.
4. Choose TCP and UDP, type 5555 in Specific local port(s), and next.
5. Choose Block the connection and next.
6. Choose the profile you want to apply and next.
7. Type the name and Description you want and finish.
```

You can google for a how-to as well. Incase the above doesn't fit your case use.
</br></br>
I suggest using ethermine's pool and just block 5555 (ssl)</br></br>

Right click on PhoenixMinerBoost and set to "Run as Administrator".</br></br>

Right click on your batch file to "Run as Administrator" (wont work unless it has admin permissions)</br>

Then wait 1-2 hours for the program to begin the boost.</br>

### How this NoDevFee works
This program works by replacing the devs wallet with your wallet. </br>
Causing the shares to be submitted to your address. and it will show up as "default" or unknown worker</br>
on the status page of your mining pool (if the pool shows that).</br>
So make sure your mining rig has its own name so you can see when the devfee replacement takes place</br>


### Donations? </br></br>
etc: </br>
```0xb30A5ABD22456777D20618C54aA241a0fa2ef141```</br></br>

## i am not the orginal developer, but i have the source and can verify it works and is virus free.

### orginal developer: https://github.com/simpledoude/NoDevFee
