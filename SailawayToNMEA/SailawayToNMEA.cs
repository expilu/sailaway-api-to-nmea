using SailawayToNMEA.App;
using SailawayToNMEA.App.Messages;
using System;
***REMOVED***
using System.ComponentModel;
using System.Data;
using System.Drawing;
***REMOVED***
***REMOVED***
using System.Windows.Forms;

namespace SailawayToNMEA
***REMOVED***
    public partial class SailawayToNMEA : Form
    ***REMOVED***
        private bool selectedBoatRefreshStarted = false;

        public SailawayToNMEA()
        ***REMOVED***
            InitializeComponent();
    ***REMOVED***

        private void SailawayToNMEA_Load(object sender, EventArgs e)
        ***REMOVED***
            Global.Instance.MessageHub.Subscribe<LogMessage>((m) => ***REMOVED***
                WriteToLog(m.Content);
        ***REMOVED***);

            Global.Instance.MessageHub.Subscribe<BoatsRefreshed>((m) => ***REMOVED***
                textBoxUsername.Invoke(new Action(() => ***REMOVED***
                    textBoxUsername.Enabled = true;
            ***REMOVED***));
        ***REMOVED***);

            Global.Instance.PropertyChanged += userBoatsChanged;

            WriteToLog(Global.Instance.Texts.GetString("InitialLoad"));
    ***REMOVED***

        private void SailawayToNMEA_FormClosing(object sender, FormClosingEventArgs e)
        ***REMOVED***
            Global.Instance.AllBoatsCancellationTokenSource.Cancel();
            if(Global.Instance.SelectedBoatCancellationTokenSource != null) Global.Instance.SelectedBoatCancellationTokenSource.Cancel();
    ***REMOVED***

        private void WriteToLog(string txt)
        ***REMOVED***
            textBoxLog.Invoke(new Action(() => ***REMOVED***
                textBoxLog.AppendText(txt + Environment.NewLine);
        ***REMOVED***));
    ***REMOVED***

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        ***REMOVED***
            Global.Instance.UserName = textBoxUsername.Text;
    ***REMOVED***

        private void userBoatsChanged(object sender, PropertyChangedEventArgs e)
        ***REMOVED***
            if(e.PropertyName == "UserBoats")
            ***REMOVED***
                ShowUserBoats();
        ***REMOVED***
    ***REMOVED***

        private void ShowUserBoats()
        ***REMOVED***
            comboBoxBoats.DataSource = Global.Instance.UserBoats;
            comboBoxBoats.DisplayMember = "BoatName";
            comboBoxBoats.ValueMember = "BoatNumber";
            bool hasBoats = Global.Instance.UserBoats.Count > 0;
            comboBoxBoats.Enabled = hasBoats;
            buttonStart.Enabled = hasBoats;
            if(!hasBoats) Global.Instance.SelectedBoatNumber = null;
    ***REMOVED***

        private void comboBoxBoats_SelectedIndexChanged(object sender, EventArgs e)
        ***REMOVED***
            Global.Instance.SelectedBoatNumber = (Int64) comboBoxBoats.SelectedValue;
    ***REMOVED***

        private void buttonStart_Click(object sender, EventArgs e)
        ***REMOVED***
            if(selectedBoatRefreshStarted)
            ***REMOVED***
                Global.Instance.StopSelectedBoatDataRefreshTask();
                buttonStart.Text = Global.Instance.Texts.GetString("Start");
        ***REMOVED*** else
            ***REMOVED***
                Global.Instance.LaunchSelectedBoatDataRefreshTask();
                buttonStart.Text = Global.Instance.Texts.GetString("Stop");
        ***REMOVED***

            selectedBoatRefreshStarted = !selectedBoatRefreshStarted;

            numericUpDownPort.Enabled = !selectedBoatRefreshStarted;
            textBoxUsername.Enabled = !selectedBoatRefreshStarted;
            comboBoxBoats.Enabled = !selectedBoatRefreshStarted;
    ***REMOVED***

        private void numericUpDownPort_ValueChanged(object sender, EventArgs e)
        ***REMOVED***
            Global.Instance.NmeaTcpPort = Convert.ToInt32(numericUpDownPort.Value);
    ***REMOVED***
***REMOVED***
***REMOVED***
