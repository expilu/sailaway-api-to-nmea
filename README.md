# Sailaway to NMEA

This is a Windows application that retrieves your boat data from Sailaway server and sends it through TCP using NMEA sentences.

You can use this to connect Sailaway to a software (or hardware!) that accepts NMEA sentences + TCP. Specially useful for routing software such as qtVlm or OpenCPN.

Boat data is refreshed every 10 minutes. This is to avoid overloading the Sailaway servers, which can have an impact on game performance.

# How to use

1. Download and extract the [SailawayToNMEA_0.2a.zip](https://github.com/expilu/sailaway-api-to-nmea/releases/download/v0.2a/SailawayToNMEA_0.2a.zip)
1. Run the application and wait for it to connect to the Sailaway server.
2. Select the TCP port you want to use.
3. Enter your username (exactly!) and then pick one of your boats. The boats will only appear if you have been online in the game in the past 7 days.
4. Click Start
5. Once the server is started you can connect to its address with the chosen TCP port from your hardware or software (qtVlm, OpenCPN,...). The address is usually 127.0.0.1 if you run both softwares in the same computer.
