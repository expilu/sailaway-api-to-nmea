using SailawayToNMEA.App;
using SailawayToNMEA.App.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SailawayToNMEA
{
    public partial class SailawayToNMEA : Form
    {
        private bool initialDataRetrieved = false;
        private bool selectedBoatRefreshStarted = false;

        public SailawayToNMEA()
        {
            InitializeComponent();
        }

        private void SailawayToNMEA_Load(object sender, EventArgs e)
        {
            Global.Instance.MessageHub.Subscribe<LogMessage>((m) => {
                WriteToLog(m.Content);
            });

            Global.Instance.MessageHub.Subscribe<BoatsRefreshed>((m) => {
                if (!initialDataRetrieved)
                {
                    initialDataRetrieved = true;
                    textBoxUsername.Invoke(new Action(() =>
                    {
                        textBoxUsername.Enabled = true;
                    }));
                }
            });

            Global.Instance.PropertyChanged += userBoatsChanged;

            WriteToLog(Global.Instance.Texts.GetString("InitialLoad"));
        }

        private void SailawayToNMEA_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.Instance.AllBoatsCancellationTokenSource.Cancel();
            if(Global.Instance.SelectedBoatCancellationTokenSource != null) Global.Instance.SelectedBoatCancellationTokenSource.Cancel();
            Environment.Exit(Environment.ExitCode);
        }

        private void WriteToLog(string txt)
        {
            textBoxLog.Invoke(new Action(() => {
                textBoxLog.AppendText(txt + Environment.NewLine + Environment.NewLine);
            }));
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            Global.Instance.UserName = textBoxUsername.Text;
        }

        private void userBoatsChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "UserBoats")
            {
                ShowUserBoats();
            }
        }

        private void ShowUserBoats()
        {
            comboBoxBoats.DataSource = Global.Instance.UserBoats;
            comboBoxBoats.DisplayMember = "BoatName";
            comboBoxBoats.ValueMember = "BoatNumber";
            bool hasBoats = Global.Instance.UserBoats.Count > 0;
            comboBoxBoats.Enabled = hasBoats;
            buttonStart.Enabled = hasBoats;
            if(!hasBoats) Global.Instance.SelectedBoatNumber = null;
        }

        private void comboBoxBoats_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.Instance.SelectedBoatNumber = (Int64) comboBoxBoats.SelectedValue;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(selectedBoatRefreshStarted)
            {
                Global.Instance.StopSelectedBoatDataRefreshTask();
                buttonStart.Text = Global.Instance.Texts.GetString("Start");
            } else
            {
                Global.Instance.LaunchSelectedBoatDataRefreshTask();
                buttonStart.Text = Global.Instance.Texts.GetString("Stop");
            }

            selectedBoatRefreshStarted = !selectedBoatRefreshStarted;

            numericUpDownPort.Enabled = !selectedBoatRefreshStarted;
            textBoxUsername.Enabled = !selectedBoatRefreshStarted;
            comboBoxBoats.Enabled = !selectedBoatRefreshStarted;
        }

        private void numericUpDownPort_ValueChanged(object sender, EventArgs e)
        {
            Global.Instance.NmeaTcpPort = Convert.ToInt32(numericUpDownPort.Value);
        }
    }
}
