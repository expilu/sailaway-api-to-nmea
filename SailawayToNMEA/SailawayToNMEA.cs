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
        public object Globals { get; private set; }

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
                textBoxUsername.Invoke(new Action(() => {
                    textBoxUsername.Enabled = true;
                }));
            });

            Global.Instance.PropertyChanged += userBoatsChanged;

            WriteToLog(Global.Instance.Texts.GetString("InitialLoad"));
        }

        private void SailawayToNMEA_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.Instance.AllBoatsCancellationTokenSource.Cancel();
        }

        private void WriteToLog(string txt)
        {
            textBoxLog.Invoke(new Action(() => {
                textBoxLog.AppendText(txt + Environment.NewLine);
            }));
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            Global.Instance.UserName = textBoxUsername.Text.Trim();
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
            comboBoxBoats.Enabled = Global.Instance.UserBoats.Count > 0;
            Global.Instance.SelectedBoatNumber = null;
        }

        private void comboBoxBoats_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.Instance.SelectedBoatNumber = (Int64) comboBoxBoats.SelectedValue;
        }
    }
}
