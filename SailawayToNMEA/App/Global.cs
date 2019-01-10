using NMEAServerLib;
using SailawayToNMEA.API;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyMessenger;

namespace SailawayToNMEA.App
{
    public sealed class Global : INotifyPropertyChanged
    {
        private static readonly Lazy<Global> lazy = new Lazy<Global>(() => new Global());

        public static Global Instance { get { return lazy.Value; } }

        private Global()
        {
            MessageHub = new TinyMessengerHub();

            Texts = new ResXResourceSet(@".\Resources\Texts.resx");

            MessageHub.Subscribe<BoatsRefreshed>((m) => {
                AllBoats = m.Content;
#if DEBUG
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("BoatsRefreshed")));
#endif
            });

            MessageHub.Subscribe<SelectedBoatRefreshed>((m) => {
                Boat = m.Content;
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("BoatDataRefreshed")));
                Boat.toInstrumentsData(ref boatData);
                nmeaServer.SendData();
            });

            AllBoatsCancellationTokenSource = new CancellationTokenSource();
            allBoatsCancellationToken = AllBoatsCancellationTokenSource.Token;            

            Tasks.RefreshAllBoats(allBoatsCancellationToken);

            nmeaServer = new NMEAServer(ref boatData, NmeaTcpPort);
            nmeaServer.OnServerStarted += delegate
            {
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEAServerStarted") + " " + NmeaTcpPort));
            };
            nmeaServer.OnServerStop += delegate
            {
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEAServerStopped")));
            };
            nmeaServer.OnNMEASent += NmeaServer_OnNMEASent;
            nmeaServer.OnServerError += NmeaServer_OnServerError;
            nmeaServer.OnClientConnected += NmeaServer_OnClientConnected;
        }

        private void NmeaServer_OnClientConnected(string address)
        {
            MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("ClientConnected") + address));
            nmeaServer.SendData();
        }

        private void NmeaServer_OnServerError(Exception exception)
        {
            MessageHub.PublishAsync(new LogMessage(this, "Error: " + exception.Message + "\r\n"));
        }

        private void NmeaServer_OnNMEASent(string nmea)
        {
            MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEASent") + nmea.Replace("$", "\r\n$")));
        }

        public CancellationTokenSource AllBoatsCancellationTokenSource;
        private CancellationToken allBoatsCancellationToken;
        public CancellationTokenSource SelectedBoatCancellationTokenSource;

        private NMEAServer nmeaServer;
        public int NmeaTcpPort = 10110;
        private InstrumentsData boatData = new InstrumentsData(); 

        public List<BoatInfo> AllBoats { get; set; }

        public List<BoatInfo> UserBoats
        {
            get
            {
                return AllBoats.Where(o => o.UserName == UserName).ToList();
            }
        }

        public TinyMessengerHub MessageHub { get; }

        public ResXResourceSet Texts { get; }

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
                NotifyPropertyChanged("UserName");
                NotifyPropertyChanged("UserBoats");
            }
        }
        
        public Nullable<Int64> SelectedBoatNumber { get; set; }

        public BoatInfo Boat { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void LaunchSelectedBoatDataRefreshTask()
        {
            StopSelectedBoatDataRefreshTask();

            if (SelectedBoatNumber != null)
            {
                SelectedBoatCancellationTokenSource = new CancellationTokenSource();

                Tasks.RefreshSelectedBoat(SelectedBoatCancellationTokenSource.Token);
                nmeaServer.Start();
            }
        }

        public void StopSelectedBoatDataRefreshTask()
        {
            if (SelectedBoatCancellationTokenSource != null)
            {
                SelectedBoatCancellationTokenSource.Cancel();
                nmeaServer.Stop();
            }
        }
    }
}
