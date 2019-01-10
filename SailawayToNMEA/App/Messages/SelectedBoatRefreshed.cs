using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
