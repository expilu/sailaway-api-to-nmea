# Sailaway to NMEA

*This is a fork of https://github.com/expilu/sailaway-api-to-nmea. Command line arguments for non-interactive start were added*

This is a Windows application that retrieves your boat data from Sailaway server and sends it through TCP using NMEA sentences.

You can use this to connect Sailaway to a software (or hardware!) that accepts NMEA sentences + TCP. Specially useful for routing software such as qtVlm or OpenCPN.

Boat data is refreshed every 10 minutes. This is to avoid overloading the Sailaway servers, which can have an impact on game performance.

## How to use

1. Download and extract [SailawayToNMEA_0.5.2.zip](https://github.com/elpatron68/sailaway-api-to-nmea/releases/download/0.5.2/SailawayToNMEA_0.5.2.zip)
2. Run the application and wait for it to connect to the Sailaway server.
3. Select the TCP port you want to use.
4. Enter your username (exactly!) and then click in _Load boats_. The boats will only appear if you have been online in the game in the past 7 days.
5. Select the boat you want to track.
6. Click Start.
7. Once the server is started you can connect to its address with the chosen TCP port from your hardware or software (qtVlm, OpenCPN,...). The address is usually 127.0.0.1 if you run both softwares in the same computer.

### Command Line Arguments

To run Sailaway to NMEA without having to set username and boatname after the launch, the program supports command line arguments:

- `-username <Sailaway user name>` (sets the user name)
- `-boatname <Sailaway boat name>` (sets the boat´s name)
- `-port <Value>` (sets the port value)
- `-adroff` (uncheck *Activate dead reckoning*, if not given, *Activate dead reckoning* will be active)
- `-autostart` (starts NMEA logging without any user interaction. Both `-username` and `-boatname` have to be set, too)
- `-launch` <Path to executable>` (program to launch after startup)
- `-minimize` (Start *SailawayToNMEA* minimized)

Example for desktop shortcut (field "Destination"):

`C:\Users\foo\Tools\SailawayToNMEA\SailawayToNMEA.exe -username foo -boatname "Fast As Hell" -autostart -launch "C:\Program Files\qtVlm\qtVlm.exe"`

Take a look at the [WIKI](https://github.com/expilu/sailaway-api-to-nmea/wiki)!
