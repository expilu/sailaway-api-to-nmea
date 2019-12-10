using Ookii.CommandLine;

namespace SailawayToNMEA
{
    public class Arguments
    {
        [CommandLineArgument]
        public string username { get; set; }
        [CommandLineArgument]
        public string boatname { get; set; }
        [CommandLineArgument]
        public bool autostart { get; set; }
        [CommandLineArgument]
        public int port { get; set; }
        [CommandLineArgument]
        public bool adr { get; set; }
    }
}
