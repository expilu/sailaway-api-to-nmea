using SailawayToNMEA.App;
using System;
***REMOVED***
***REMOVED***
***REMOVED***
using System.Threading;
***REMOVED***

namespace SailawayToNMEA.API
***REMOVED***
    public static class Tasks
    ***REMOVED***
        public static async Task RefreshBoats(CancellationToken cancellationToken)
        ***REMOVED***
            await Task.Run(async () =>
            ***REMOVED***
                while (true)
                ***REMOVED***
                    Global.Instance.Boats = Methods.GetBoats();
                    await Task.Delay(Conf.REQUEST_RATE, cancellationToken);
                    if (cancellationToken.IsCancellationRequested) break;
            ***REMOVED***
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
