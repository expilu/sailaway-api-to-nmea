using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
