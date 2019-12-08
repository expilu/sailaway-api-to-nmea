namespace SailawayToNMEA.App
{
    public class Conf
    {
        public const string API_BASE_URL = "https://backend.sailaway.world/cgi-bin/sailaway";
        public const string API_KEY = "<your API Key here>";
#if DEBUG
        public const int REQUEST_RATE = 60000;
#else
        public const int REQUEST_RATE = 10 * 60 * 1000;
#endif
        public const double MS_TO_KNOTS = 1.94384;

#if DEBUG
        public const int DEAD_RECKONING_RATE = 10000;
#else
        public const int DEAD_RECKONING_RATE = 60000;
#endif
    }
}
