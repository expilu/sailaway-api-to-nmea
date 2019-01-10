using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
