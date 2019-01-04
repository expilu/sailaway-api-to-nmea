using SailawayToNMEA.App;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
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
        public static async Task RefreshAllBoats(CancellationToken cancellationToken)
        ***REMOVED***
            await Task.Run(async () =>
            ***REMOVED***
                while (!cancellationToken.IsCancellationRequested)
                ***REMOVED***
                    Global.Instance.MessageHub.PublishAsync(new BoatsRefreshed(Global.Instance, Methods.GetBoats()));
                    await Task.Delay(Conf.REQUEST_RATE, cancellationToken);
            ***REMOVED***
        ***REMOVED***);
    ***REMOVED***

        public static async Task RefreshSelectedBoat(CancellationToken cancellationToken)
        ***REMOVED***
            await Task.Run(async () =>
            ***REMOVED***
                while (!cancellationToken.IsCancellationRequested)
                ***REMOVED***
                    if (Global.Instance.SelectedBoatNumber != null)
                    ***REMOVED***
                        List<BoatInfo> boats = Methods.GetBoats(Global.Instance.SelectedBoatNumber);
                        if (boats.Count == 1)
                        ***REMOVED***
                            Global.Instance.MessageHub.PublishAsync(new SelectedBoatRefreshed(Global.Instance, boats.First()));
                    ***REMOVED***
                ***REMOVED***
                    await Task.Delay(Conf.REQUEST_RATE, cancellationToken);
            ***REMOVED***
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
