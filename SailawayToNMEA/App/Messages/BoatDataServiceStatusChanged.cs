using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
