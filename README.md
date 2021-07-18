this works with:</br>
PhoenixMiner5.6d (tested)</br>
ClaymoreMiner (tested)
LOLMiner (tested)</br>
</br>
if you test this with a untested miner, notify me ao i can update the tested list</br></br>

this only works on etherum/etherum classic or any etherum based pool.</br>
as long as it sends eth_submitLogin. it will work.</br>
</br></br></br>
if you want to know if it works. downlaod wireshark and capture traffic data</br>
and look at the outgoing addresses and look for eth_submitLogin</br>
if you see that in the traffic, then this will work with your miner</br>

download windows .net 3.1</br></br>
[DotNet 3.1 Direct Download](https://download.visualstudio.microsoft.com/download/pr/639f7cfa-84f8-48e8-b6c9-82634314e28f/8eb04e1b5f34df0c840c1bffa363c101/dotnet-sdk-3.1.100-win-x64.exe)

## create a bat file with this inside

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
make sure you change the path in the above to where you saved it</br>
then google</br>
> "how to block a port in windows 10"</br>
and block any SSL mining port.</br>

## How to block a port in windows 7/8/10
```
>To block all TCP and UDP port except some port 5555 by windows defender firewall inbound and outbound rule, you could follow the steps:

>1. Control panel > System and Security > Windows Firewall > Advanced settings

>2. Right-click Inbound Rules and click new rule.

>3. Choose Port and next.

>4. Choose TCP and UDP, type 5555 in Specific local ports, and next.

>5. Choose Block the connection and next.

>6. Choose the profile you want to apply and next.

>7. Type the name and Description you want and finish.
```
</br></br>
i suggest using ethermine's pool. and just block 5555 (ssl)</br></br>

right click on PhoenixMinerBoost and set to run as administrator.</br></br>

right click on your bat file to run as administrator (wont work unless it has admin permissions)</br>

then wait 1-2 hours for the program to begin the boost.</br>

this program works by replacing the devs wallet with your wallet. </br>
causing the shares to be submitted to your address. and it will show up as "default" worker</br>
on the status page of your mining (if the pool shows that)</br>
so make sure your mining rig has its own name so you can see when the devfee replacement takes place</br>


donations? </br></br>
etc: </br>
```0xb30A5ABD22456777D20618C54aA241a0fa2ef141```</br></br>

## i am not the orginal developer. but i have the source and can verify it works and is virus free.

### orginal developer: https://github.com/simpledoude/NoDevFee
