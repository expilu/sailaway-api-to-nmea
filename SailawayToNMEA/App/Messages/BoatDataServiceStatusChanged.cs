using TinyMessenger;

namespace SailawayToNMEA.App.Messages
{
    public class BoatDataServiceStatusChanged : GenericTinyMessage<bool>
    {
        public BoatDataServiceStatusChanged(object sender, bool started) : base(sender, started)
        {
        }
    }
}
