using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailawayToNMEA.App
{
    public sealed class Global
    {
        private static readonly Lazy<Global> lazy = new Lazy<Global>(() => new Global());

        public static Global Instance { get { return lazy.Value; } }

        private Global()
        {

        }

        public List<BoatInfo> Boats { get; set; }
    }
}
