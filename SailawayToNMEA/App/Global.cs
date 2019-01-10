using NMEAServerLib;
using SailawayToNMEA.API;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
using System;
***REMOVED***
using System.ComponentModel;
***REMOVED***
using System.Resources;
***REMOVED***
using System.Threading;
***REMOVED***
using TinyMessenger;

***REMOVED***
***REMOVED***
    public sealed class Global : INotifyPropertyChanged
    ***REMOVED***
        private static readonly Lazy<Global> lazy = new Lazy<Global>(() => new Global());

        public static Global Instance ***REMOVED*** get ***REMOVED*** return lazy.Value; ***REMOVED*** ***REMOVED***

        private Global()
        ***REMOVED***
            MessageHub = new TinyMessengerHub();

            Texts = new ResXResourceSet(@".\Resources\Texts.resx");

            MessageHub.Subscribe<BoatsRefreshed>((m) => ***REMOVED***
                AllBoats = m.Content;
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("BoatsRefreshed")));
        ***REMOVED***);

            MessageHub.Subscribe<SelectedBoatRefreshed>((m) => ***REMOVED***
                Boat = m.Content;
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("BoatDataRefreshed")));
                Boat.toInstrumentsData(ref boatData);
        ***REMOVED***);

            AllBoatsCancellationTokenSource = new CancellationTokenSource();
            allBoatsCancellationToken = AllBoatsCancellationTokenSource.Token;            

            Tasks.RefreshAllBoats(allBoatsCancellationToken);

            nmeaServer = new NMEAServer(ref boatData, NmeaTcpPort, Conf.NMEA_SEND_RATE);
            nmeaServer.OnServerStarted += delegate
            ***REMOVED***
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEAServerStarted") + " " + NmeaTcpPort));
        ***REMOVED***;
            nmeaServer.OnServerStop += delegate
            ***REMOVED***
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEAServerStopped")));
        ***REMOVED***;
            nmeaServer.OnNMEASent += NmeaServer_OnNMEASent;
    ***REMOVED***

        private void NmeaServer_OnNMEASent(string nmea)
        ***REMOVED***
            MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("NMEASent") + nmea.Replace("$", "\r\n$") + "\r\n"));
    ***REMOVED***

        public CancellationTokenSource AllBoatsCancellationTokenSource;
        private CancellationToken allBoatsCancellationToken;
        public CancellationTokenSource SelectedBoatCancellationTokenSource;

        private NMEAServer nmeaServer;
        public int NmeaTcpPort = 10110;
        private InstrumentsData boatData = new InstrumentsData(); 

        public List<BoatInfo> AllBoats ***REMOVED*** get; set; ***REMOVED***

        public List<BoatInfo> UserBoats
        ***REMOVED***
            get
            ***REMOVED***
                return AllBoats.Where(o => o.UserName == UserName).ToList();
        ***REMOVED***
    ***REMOVED***

        public TinyMessengerHub MessageHub ***REMOVED*** get; ***REMOVED***

        public ResXResourceSet Texts ***REMOVED*** get; ***REMOVED***

        private string _userName;
        public string UserName
        ***REMOVED***
            get
            ***REMOVED***
                return _userName;
        ***REMOVED***

            set
            ***REMOVED***
                _userName = value;
                NotifyPropertyChanged("UserName");
                NotifyPropertyChanged("UserBoats");
        ***REMOVED***
    ***REMOVED***
        
        public Nullable<Int64> SelectedBoatNumber ***REMOVED*** get; set; ***REMOVED***

        public BoatInfo Boat ***REMOVED*** get; set; ***REMOVED***

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        ***REMOVED***
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            ***REMOVED***
                handler(this, new PropertyChangedEventArgs(propertyName));
        ***REMOVED***
    ***REMOVED***

        public void LaunchSelectedBoatDataRefreshTask()
        ***REMOVED***
            StopSelectedBoatDataRefreshTask();

            if (SelectedBoatNumber != null)
            ***REMOVED***
                SelectedBoatCancellationTokenSource = new CancellationTokenSource();

                Tasks.RefreshSelectedBoat(SelectedBoatCancellationTokenSource.Token);
                nmeaServer.Start();
        ***REMOVED***
    ***REMOVED***

        public void StopSelectedBoatDataRefreshTask()
        ***REMOVED***
            if (SelectedBoatCancellationTokenSource != null)
            ***REMOVED***
                SelectedBoatCancellationTokenSource.Cancel();
                nmeaServer.Stop();
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***
