using SailawayToNMEA.Model;
using System.Collections.Generic;
using TinyMessenger;

namespace SailawayToNMEA.App.Messages
{
    public class UserBoatsRetrieved : GenericTinyMessage<List<BoatInfo>>
    {
        public UserBoatsRetrieved(object sender, List<BoatInfo> boats) : base(sender, boats)
        {
        }
    }
}
