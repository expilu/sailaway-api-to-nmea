using RestSharp.Deserializers;
using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailawayToNMEA.API.Response
{
    class BoatsResponse
    {
        [DeserializeAs(Name = "boats")]
        public List<BoatInfo> Boats { get; set; }
    }
}
