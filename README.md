# Sailaway to NMEA

This is a Windows application that retrieves your boat data from Sailaway server and sends it through TCP using NMEA sentences.

You can use this to connect Sailaway to software that accepts NMEA sentences + TCP such as qtVlm or OpenCPN.

Boat data is refreshed every 10 minutes. This is to avoid overloading the Sailaway servers, which can have an impact on game performance.

# How to use

1 - Run the program and wait for it to connect to Sailaway server.
2 - Select the TCP port you want to use.
3 - Enter your username (exactly!) and then pick one of your boats. Your boats will only appear if you have been online in the game in the past 7 days.
4 - Click Start
5 - Once the server is started you can connect to its address with the chosen TCP port from your favorite software (qtVlm, OpenCPN,...). The address is usually 127.0.0.1 if you run both softwares in the same machine.
