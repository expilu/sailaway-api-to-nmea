using RestSharp;
using SailawayToNMEA.API.Response;
using SailawayToNMEA.App;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailawayToNMEA.API
{
    static class Methods
    {
        public static List<BoatInfo> GetBoats(Nullable<Int64> boatNumber = null)
        {
            List<BoatInfo> boatInfos = new List<BoatInfo>();
            try
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri(Conf.API_BASE_URL);
                RestRequest request = new RestRequest("TrackAllBoats.pl");
                request.AddParameter("key", Conf.API_KEY);
                if (boatNumber != null) request.AddParameter("ubtnr", boatNumber);

                IRestResponse<BoatsResponse> response = client.Execute<BoatsResponse>(request);

                if(response.Data == null)
                {
                    Global.Instance.MessageHub.PublishAsync(new LogMessage(Global.Instance, Global.Instance.Texts.GetString("SailawayConnectionProblem") + response.Content + "\r\nCheck if your API key is set correctly"));
                } else
                {
                    boatInfos = response.Data.Boats;
                }
            } catch (Exception e)
            {
                Global.Instance.MessageHub.PublishAsync(new LogMessage(Global.Instance, Global.Instance.Texts.GetString("SailawayConnectionProblem") + e.Message));
            }

            return boatInfos;
        }
    }
}
