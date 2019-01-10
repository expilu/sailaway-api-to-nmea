using TinyMessenger;

namespace SailawayToNMEA.App.Messages
{
    public class LogMessage : GenericTinyMessage<string>
    {
        public LogMessage(object sender, string message) : base(sender, message)
        {
        }
    }
}
