using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailawayToNMEA.App
{
    public class Conf
    {
        public const string API_BASE_URL = "https://backend.sailaway.world/cgi-bin/sailaway";
        public const string API_KEY = "<your api key>";
#if DEBUG
        public const int REQUEST_RATE = 10000;
#else
        public const int REQUEST_RATE = 10000;
#endif
        public const int NMEA_SEND_RATE = 1000;
        public const double MS_TO_KNOTS = 1.94384;
    }
}
