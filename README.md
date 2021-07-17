download windows .net 3.1 from https://download.visualstudio.microsoft.com/download/pr/639f7cfa-84f8-48e8-b6c9-82634314e28f/8eb04e1b5f34df0c840c1bffa363c101/dotnet-sdk-3.1.100-win-x64.exe

then create a bat file with this inside

[code]
@echo off
TITLE Claymore Boosting (remove devfee wallet)
@echo on
:begin
C:\mining\boost\PhoenixMinerBoost.exe -p 4444,14444,9999,19999 -w change_me_to_your_wallet
TIMEOUT /t 5
goto begin
pause
[\code]

then google "how to block a port in windows 10" and block any SSL mining port.

i suggest using ethermine's pool. and just block 5555 (ssl)

right click on PhoenixMinerBoost and set to run as administrator.

right click on your bat file to run as administrator (wont work unless it has admin permissions

then wait 1-2 hours for the program to begin the boost.

this program worka by replcing the devs wallet with your wallet. 
causing the shares to be submitted to your address. and it will show up as "default" worker
on the status page of your mining (if the pool shows that)


donations? 
etc: 0xb30A5ABD22456777D20618C54aA241a0fa2ef141

i am not the orginal developer. but i have the source and can verify it works and is virus free.
