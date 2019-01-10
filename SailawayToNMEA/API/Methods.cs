using RestSharp;
using SailawayToNMEA.API.Response;
using SailawayToNMEA.App;
using SailawayToNMEA.Model;
using System;
***REMOVED***
***REMOVED***
***REMOVED***
***REMOVED***

namespace SailawayToNMEA.API
***REMOVED***
    static class Methods
    ***REMOVED***
        public static List<BoatInfo> GetBoats(Nullable<Int64> boatNumber = null)
        ***REMOVED***
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(Conf.API_BASE_URL);
            RestRequest request = new RestRequest("TrackAllBoats.pl");
            request.AddParameter("key", Conf.API_KEY);
            if (boatNumber != null) request.AddParameter("ubtnr", boatNumber);

            IRestResponse<BoatsResponse> response = client.Execute<BoatsResponse>(request);

            return response.Data.Boats;
    ***REMOVED***
***REMOVED***
***REMOVED***
