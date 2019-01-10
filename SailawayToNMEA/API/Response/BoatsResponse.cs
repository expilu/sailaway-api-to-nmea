using RestSharp.Deserializers;
using SailawayToNMEA.Model;
using System.Collections.Generic;

namespace SailawayToNMEA.API.Response
{
    class BoatsResponse
    {
        [DeserializeAs(Name = "boats")]
        public List<BoatInfo> Boats { get; set; }
    }
}
