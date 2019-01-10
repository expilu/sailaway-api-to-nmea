using SailawayToNMEA.Model;
using TinyMessenger;

namespace SailawayToNMEA.App.Messages
{
    public class SelectedBoatRefreshed : GenericTinyMessage<BoatInfo>
    {
        public SelectedBoatRefreshed(object sender, BoatInfo boat) : base(sender, boat)
        {

        }
    }
}
