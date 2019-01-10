using RestSharp.Deserializers;
using SailawayToNMEA.Model;
using System;
***REMOVED***
***REMOVED***
***REMOVED***
***REMOVED***

namespace SailawayToNMEA.API.Response
***REMOVED***
    class BoatsResponse
    ***REMOVED***
        [DeserializeAs(Name = "boats")]
        public List<BoatInfo> Boats ***REMOVED*** get; set; ***REMOVED***
***REMOVED***
***REMOVED***
