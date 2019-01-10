using SailawayToNMEA.App;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SailawayToNMEA.API
{
    public static class Tasks
    {
        public static async Task RefreshAllBoats(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Global.Instance.MessageHub.PublishAsync(new BoatsRefreshed(Global.Instance, Methods.GetBoats()));
                    await Task.Delay(Conf.REQUEST_RATE, cancellationToken);
                }
            });
        }

        public static async Task RefreshSelectedBoat(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (Global.Instance.SelectedBoatNumber != null)
                    {
                        List<BoatInfo> boats = Methods.GetBoats(Global.Instance.SelectedBoatNumber);
                        if (boats.Count == 1)
                        {
                            Global.Instance.MessageHub.PublishAsync(new SelectedBoatRefreshed(Global.Instance, boats.First()));
                        }
                    }
                    await Task.Delay(Conf.REQUEST_RATE, cancellationToken);
                }
            });
        }
    }
}
