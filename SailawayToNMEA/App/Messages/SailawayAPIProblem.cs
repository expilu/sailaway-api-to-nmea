using TinyMessenger;

namespace SailawayToNMEA.App.Messages
{
    public class SailawayAPIProblem : GenericTinyMessage<string>
    {
        public SailawayAPIProblem(object sender, string msg) : base(sender, msg)
        {
        }
    }
}
