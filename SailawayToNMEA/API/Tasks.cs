using SailawayToNMEA.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SailawayToNMEA.API
{
    public static class Tasks
    {
        public static async Task RefreshBoats(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    Global.Instance.Boats = Methods.GetBoats();
                    await Task.Delay(Conf.REQUEST_RATE, cancellationToken);
                    if (cancellationToken.IsCancellationRequested) break;
                }
            });
        }
    }
}
