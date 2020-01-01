using Ookii.CommandLine;

namespace SailawayToNMEA
{
    public class Arguments
    {
        [CommandLineArgument]
        public string Username { get; set; }
        [CommandLineArgument]
        public string Boatname { get; set; }
        [CommandLineArgument]
        public string Launch { get; set; }
        [CommandLineArgument]
        public bool Autostart { get; set; }
        [CommandLineArgument]
        public int Port { get; set; }
        [CommandLineArgument]
        public bool Adr { get; set; }
    }
}
