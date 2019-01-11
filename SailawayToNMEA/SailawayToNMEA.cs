using SailawayToNMEA.App;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SailawayToNMEA
{
    public partial class SailawayToNMEA : Form
    {
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

            Global.Instance.MessageHub.Subscribe<UserBoatsRetrieved>((m) => {
                ShowUserBoats();
            });

            Global.Instance.MessageHub.Subscribe<BoatDataServiceStatusChanged>((m) =>
            {
                bool started = m.Content;

                if (started) Global.Instance.MessageHub.PublishAsync(new LogMessage(this, "------------------------------------------------------------------"));

                buttonStart.Invoke(new Action(() =>
                {
                    string txt = started ? Global.Instance.Texts.GetString("Stop") : Global.Instance.Texts.GetString("Start");
                    buttonStart.Text = Global.Instance.Texts.GetString(txt);
                }));

                buttonLoadBoats.Invoke(new Action(() =>
                {
                    buttonLoadBoats.Enabled = !started;
                }));

                selectedBoatRefreshStarted = started;

                numericUpDownPort.Invoke(new Action(() =>
                {
                    numericUpDownPort.Enabled = !started;
                }));
                textBoxUsername.Invoke(new Action(() =>
                {
                    textBoxUsername.Enabled = !started;
                }));
                comboBoxBoats.Invoke(new Action(() =>
                {
                    comboBoxBoats.Enabled = !started;
                }));
            });
        }

        private void SailawayToNMEA_FormClosing(object sender, FormClosingEventArgs e)
        {
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

            buttonLoadBoats.Enabled = Global.Instance.UserName != null && Global.Instance.UserName.Length > 0;
        }

        private void ShowUserBoats()
        {
            bool hasBoats = Global.Instance.UserBoats != null && Global.Instance.UserBoats.Count > 0;

            comboBoxBoats.Invoke(new Action(() =>
            {
                comboBoxBoats.DataSource = Global.Instance.UserBoats;
                comboBoxBoats.DisplayMember = "BoatName";
                comboBoxBoats.ValueMember = "BoatNumber";
                comboBoxBoats.Enabled = hasBoats;
            }));

            buttonStart.Invoke(new Action(() =>
            {
                buttonStart.Enabled = hasBoats;
            }));

            
            if(!hasBoats) Global.Instance.SelectedBoatNumber = null;
        }

        private void comboBoxBoats_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.Instance.SelectedBoatNumber = ((BoatInfo) comboBoxBoats.SelectedItem).BoatNumber;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (selectedBoatRefreshStarted)
                Global.Instance.StopSelectedBoatDataRefreshTask();
            else
                Global.Instance.LaunchSelectedBoatDataRefreshTask();
        }

        private void numericUpDownPort_ValueChanged(object sender, EventArgs e)
        {
            Global.Instance.NmeaTcpPort = Convert.ToInt32(numericUpDownPort.Value);
        }

        private void buttonLoadBoats_Click(object sender, EventArgs e)
        {
            Global.Instance.GetUserBoats();
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLoadBoats_Click(this, new EventArgs());
            }
        }

        private void comboBoxBoats_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonStart_Click(this, new EventArgs());
            }
        }
    }
}
