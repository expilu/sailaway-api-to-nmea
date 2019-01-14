using SailawayToNMEA.Model;
using TinyMessenger;

namespace SailawayToNMEA.App.Messages
{
    public class LogMessage : GenericTinyMessage<LogText>
    {
        public LogMessage(object sender, LogText logText) : base(sender, logText)
        {
        }
    }
}
