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
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("BoatsRefreshed")));
            });

            MessageHub.Subscribe<SelectedBoatRefreshed>((m) => {
                Boat = m.Content;
                MessageHub.PublishAsync(new LogMessage(this, Texts.GetString("BoatDataRefreshed")));
            });

            AllBoatsCancellationTokenSource = new CancellationTokenSource();
            allBoatsCancellationToken = AllBoatsCancellationTokenSource.Token;

            Tasks.RefreshAllBoats(allBoatsCancellationToken);
        }

        public CancellationTokenSource AllBoatsCancellationTokenSource;
        private CancellationToken allBoatsCancellationToken;
        private CancellationTokenSource selectedBoatCancellationTokenSource;
        private CancellationToken selectedBoatCancellationToken;

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

        private Nullable<Int64> _selectedBoatNumber;
        public Nullable<Int64> SelectedBoatNumber
        {
            get { return _selectedBoatNumber; }
            set
            {
                _selectedBoatNumber = value;
                relaunchSelectedBoatDataRefreshTask();
            }
        }

        public BoatInfo Boat
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void relaunchSelectedBoatDataRefreshTask()
        {
            if(selectedBoatCancellationTokenSource != null) selectedBoatCancellationTokenSource.Cancel();
            selectedBoatCancellationTokenSource = new CancellationTokenSource();
            selectedBoatCancellationToken = AllBoatsCancellationTokenSource.Token;

            Tasks.RefreshSelectedBoat(selectedBoatCancellationToken);
        }
    }
}
