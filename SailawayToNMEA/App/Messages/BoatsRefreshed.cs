using SailawayToNMEA.Model;
using System.Collections.Generic;
using TinyMessenger;

namespace SailawayToNMEA.App.Messages
{
    public class BoatsRefreshed : GenericTinyMessage<List<BoatInfo>>
    {
        public BoatsRefreshed(object sender, List<BoatInfo> boats) : base(sender, boats)
        {
        }
    }
}
