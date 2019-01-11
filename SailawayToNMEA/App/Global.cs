using NMEAServerLib;
using SailawayToNMEA.API;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Threading;
using TinyMessenger;

namespace SailawayToNMEA.App
{
    public sealed class Global
    {
        private static readonly Lazy<Global> lazy = new Lazy<Global>(() => new Global());

        public static Global Instance { get { return lazy.Value; } }

        private Global()
        {
            MessageHub = new TinyMessengerHub();

            Texts = new ResXResourceSet(@".\Resources\Texts.resx");

            MessageHub.Subscribe<UserBoatsRetrieved>((m) => {
                UserBoats = m.Content;
#if DEBUG                
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("UserBoatsRetrieved")));
#endif
            });

            MessageHub.Subscribe<SelectedBoatRefreshed>((m) => {
                Boat = m.Content;
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("BoatDataRefreshed") + " - " + Boat.UserName + "'s " + Boat.BoatName + " - " + DateTime.Now.ToString("hh:mm:ss")));
                Boat.toInstrumentsData(ref boatData);
                NmeaServer.SendData();
            });

            NmeaServer = new NMEAServer(ref boatData, NmeaTcpPort);
            NmeaServer.OnServerStarted += delegate
            {
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEAServerStarted") + " " + NmeaTcpPort));
            };
            NmeaServer.OnServerStop += delegate
            {
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEAServerStopped")));
            };
            NmeaServer.OnNMEASent += NmeaServer_OnNMEASent;
            NmeaServer.OnServerError += NmeaServer_OnServerError;
            NmeaServer.OnClientConnected += NmeaServer_OnClientConnected;
        }

        private void NmeaServer_OnClientConnected(string address)
        {
            MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("ClientConnected") + address));
            NmeaServer.SendData();
        }

        private void NmeaServer_OnServerError(Exception exception)
        {   
            MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEAServerError") + exception.Message + "\r\n"));
            StopSelectedBoatDataRefreshTask();
        }

        private void NmeaServer_OnNMEASent(string nmea)
        {
            MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEASent") + nmea.Replace("$", "\r\n$")));
        }

        public CancellationTokenSource SelectedBoatCancellationTokenSource;

        public NMEAServer NmeaServer;
        public int NmeaTcpPort = 10110;
        private InstrumentsData boatData = new InstrumentsData(); 

        public List<BoatInfo> UserBoats { get; set; }

        public TinyMessengerHub MessageHub { get; }

        public ResXResourceSet Texts { get; }

        public string UserName { get; set; }
        
        public Nullable<Int64> SelectedBoatNumber { get; set; }

        private BoatInfo _boat;
        public BoatInfo Boat {
            get
            {
                return _boat;
            }
            set
            {
                _boat = value;
            }
        }

        public void GetUserBoats()
        {
            Tasks.GetUserBoats(UserName);
        }

        public void LaunchSelectedBoatDataRefreshTask()
        {
            StopSelectedBoatDataRefreshTask();

            if (SelectedBoatNumber != null)
            {
                SelectedBoatCancellationTokenSource = new CancellationTokenSource();

                Tasks.RefreshSelectedBoat(SelectedBoatCancellationTokenSource.Token);
                NmeaServer.Start();
                TimeSpan t = TimeSpan.FromMilliseconds(Conf.REQUEST_RATE);
                string humanReadableRate = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("RequestRateInformation") + humanReadableRate));
                MessageHub.PublishAsync(new BoatDataServiceStatusChanged(Global.Instance, true));
            }
        }

        public void StopSelectedBoatDataRefreshTask()
        {
            if (SelectedBoatCancellationTokenSource != null)
            {
                SelectedBoatCancellationTokenSource.Cancel();
                NmeaServer.Stop();
                MessageHub.PublishAsync(new BoatDataServiceStatusChanged(Global.Instance, false));
            }
        }
    }
}
