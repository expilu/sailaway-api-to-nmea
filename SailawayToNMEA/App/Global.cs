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
        ***REMOVED***);

            AllBoatsCancellationTokenSource = new CancellationTokenSource();
            allBoatsCancellationToken = AllBoatsCancellationTokenSource.Token;

            Tasks.RefreshAllBoats(allBoatsCancellationToken);
    ***REMOVED***

        public CancellationTokenSource AllBoatsCancellationTokenSource;
        private CancellationToken allBoatsCancellationToken;
        private CancellationTokenSource selectedBoatCancellationTokenSource;
        private CancellationToken selectedBoatCancellationToken;

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

        private Nullable<Int64> _selectedBoatNumber;
        public Nullable<Int64> SelectedBoatNumber
        ***REMOVED***
            get ***REMOVED*** return _selectedBoatNumber; ***REMOVED***
            set
            ***REMOVED***
                _selectedBoatNumber = value;
                relaunchSelectedBoatDataRefreshTask();
        ***REMOVED***
    ***REMOVED***

        public BoatInfo Boat
        ***REMOVED***
            get;
            set;
    ***REMOVED***

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        ***REMOVED***
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            ***REMOVED***
                handler(this, new PropertyChangedEventArgs(propertyName));
        ***REMOVED***
    ***REMOVED***

        private void relaunchSelectedBoatDataRefreshTask()
        ***REMOVED***
            if(selectedBoatCancellationTokenSource != null) selectedBoatCancellationTokenSource.Cancel();
            selectedBoatCancellationTokenSource = new CancellationTokenSource();
            selectedBoatCancellationToken = AllBoatsCancellationTokenSource.Token;

            Tasks.RefreshSelectedBoat(selectedBoatCancellationToken);
    ***REMOVED***
***REMOVED***
***REMOVED***
