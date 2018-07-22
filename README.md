**GUI NOW REQUIRES Newtonssoft.Json.dll and Newtonsoft.Json.xml FILES TO RUN**

# CQMacroCreator

CQMacroCreator is a "GUI' for Dicecycle's Cosmos Quest PvE Instance Solver 

Hogwash's fork: https://github.com/hw1-5/C-Hero-Calc

Original repo: https://github.com/Diceycle/C-Hero-Calc

Just place CQMacroCreator.exe in the same folder as CosmosQuest.exe and run it.
![screenshot](https://i.imgur.com/MuTsyGA.png)
# What's new
v.3.0.1c - Added Kryton("aboss" works too), added option to get Dungeon lineup from server and solve them. 

v.3.0.1 - Season 6 heroes added.

v.2.9.9b - new option for settings. Now you can select which heroes you want to have enabled at the start instead of relying on app's "Choose best heroes" algorithm. There is new option for "default action on start" to use heroes from settings. Buttons for loading/saving old hero files moved to "Other" tab.

v2.9.9a - changed settings file to new format. New settings file will be automatically created from the old one or by using "Settings Creator Helper" available through button in "Other" tab.
v2.9.1 - added quest support. GUI can now send quest solutions to server.

v2.8.2 - Playfab integration, settings file, aliases

**PLayfab** - GUI can now automatically download your heroes' levels and enemy DQ lineup from server so there is no need to write it down. It requires finding your Authentication Ticket and Kongregate ID and writing it down in settings file. You can see instruction how to get them below.

**Settings file** - you can now create settings file so the GUI will automatically load heroes from file or server at start-up. First line tells the program what to do: 0 - no action(GUI will load as it used to), 1 - load heroes from "defaultHeroes" file if it exists, 2 - loads heroes from server, 3 - load heroes and your current DQ enemy lineup from server. 2nd line is you Authentication Ticket, 3rd line is KongregateID. 

**Aliases** - you can use alternative hero names. List below

| Alias | Name in calc |
| --- | --- |
| LADY | ladyoftwilight |
| LOT | ladyoftwilight |
| KAIRY | k41ry |
| TRONIX | tr0n1x |
| GAIA | gaiabyte |
| BRYN | brynhildr |
| TAURUS |t4urus |
| HALL | hallinskidi |
| PYRO | pyromancer |
| DRUID | forestdruid |
| ODELITH | ladyodelith |
| KIRK | lordkirk |
| NEP | neptunius |
| DULLA | dullahan |
| DULL | dullahan |
| JACK | jackoknight |
| SHIT | geum |
| WATERBOOM | zeth |
| EARTHBOOM | koth |
| WOLF | werewolf |
| OGREFART | ourea |
| COOORRRRRAAAAALLL!| carl |
| URSULA | ladyodelith |
| SHYGUY | shygu |
| ALF | alvitr |
| FREUD | sigrun |
| FOREIGNER | koldis |
| VOWELCHICK | aoyuki |

v.2.7.6
Added new quest heroes. If you enable too many heroes or you don't enable any of them you need to confirm you want to proceed.


v.2.7.3
Hero save files now keep which heroes were enabled.
Added check/uncheck all button and "Select best heroes" button. The latter one selects up to 12 heroes with highest strength.
Added short guide and few tooltips.

# How to get Authentication Ticket and KongregateID
Open the game and open the console(Ctrl+Shift+J or F12), choose "Network" tab.
![screenshot](https://image.prntscr.com/image/jbnEU_vqS22_fNBQDpf-zQ.png)
Without closing the Network tab refresh the game website. A lot of entries should appear. You need to find one called "LoginWithKongregate"(you can use search/filter option placed above all entries) and click on it.
![screenshot](https://image.prntscr.com/image/rq85HuDfR2qxRgmAHYx_hw.png)
On the right side you should see "Request Payload" section if you are using Chrome or Maxthon, on Firefox you should see "Params" tab. Authentication Ticket and your KongregateID will be written just there. Just copy them and paste into "MacroSettings" file(auth ticket should be in 2nd line, kong ID in line 3, don't use quotes). I included example MacroSettings file in the repository so you can see how it should look like.
![screenshot](https://image.prntscr.com/image/q9yVmqa4Rg6dnwQmfIHDIg.png)
## WARNING
**NEVER share your Authentication Ticket with anyone. If someone has access to it he will be able to do a lot of nasty stuff with your game like enter tournaments with bad lineups, spend your UM or clear your PvP grid.**

### List of all files required for calc to work
* CosmosQuest.exe - Dice's calc
* CQMacroCreator.exe
* Newtonsoft.Json.dll
* Newtonsoft.Json.xml
* MacroSettings.txt(optional - required for playfab features)
* defaultHeroes(optional - the standard hero file loaded automatically if default action on open is set to 1 in MacroSettings.txt file)



