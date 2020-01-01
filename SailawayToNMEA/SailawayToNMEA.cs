using Ookii.CommandLine;
using SailawayToNMEA.App;
using SailawayToNMEA.App.Messages;
using SailawayToNMEA.Model;
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

namespace SailawayToNMEA
{
    public partial class SailawayToNMEA : Form
    {
        private bool selectedBoatRefreshStarted = false;
        public Arguments arguments;

        public SailawayToNMEA(string[] args)
        {
            InitializeComponent();
            CommandLineParser parser = new CommandLineParser(typeof(Arguments));
            try
            {
                arguments = (Arguments)parser.Parse(args);
            }
            catch (CommandLineArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                parser.WriteUsageToConsole();
            }
        }

        private void SailawayToNMEA_Load(object sender, EventArgs e)
        {
            if (arguments.Username != "") 
                textBoxUsername.Text = arguments.Username;
                if (selectedBoatRefreshStarted) Global.Instance.StopSelectedBoatDataRefreshTask();
                Global.Instance.GetUserBoats();

            if (arguments.Port > 0)
                numericUpDownPort.Value = arguments.Port;

            checkBoxDeadReckoning.Checked = arguments.Adr;

            Global.Instance.MessageHub.Subscribe<LogMessage>((m) => {
                WriteToLog(m.Content);
            });

            Global.Instance.MessageHub.Subscribe<UserBoatsRetrieved>((m) => {
                ShowUserBoats();
            });

            Global.Instance.MessageHub.Subscribe<BoatDataServiceStatusChanged>((m) =>
            {
                bool started = m.Content;

                if (started) Global.Instance.MessageHub.PublishAsync(new LogMessage(this, new LogText("------------------------------------------------------------------")));

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

            ToolTip deadReckoningTooltip = new ToolTip();
            deadReckoningTooltip.AutoPopDelay = 5000;
            deadReckoningTooltip.InitialDelay = 500;
            deadReckoningTooltip.ShowAlways = true;
            deadReckoningTooltip.SetToolTip(checkBoxDeadReckoning, Global.Instance.Texts.GetString("DeadReckoningExplanation"));
        }

        private void SailawayToNMEA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Global.Instance.SelectedBoatCancellationTokenSource != null) Global.Instance.SelectedBoatCancellationTokenSource.Cancel();
            Environment.Exit(Environment.ExitCode);
        }

        private void WriteToLog(LogText logText)
        {
            richTextBoxLog.Invoke(new Action(() => {
                
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.SelectionLength = 0;
                richTextBoxLog.SelectionColor = logText.Color;
                richTextBoxLog.AppendText(logText.Txt + Environment.NewLine);
                richTextBoxLog.SelectionColor = richTextBoxLog.ForeColor;
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.ScrollToCaret();
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
                if (arguments.Boatname != "")
                    try
                    {
                        int index = comboBoxBoats.FindString("Dehumanizer");
                        comboBoxBoats.SelectedIndex = index;
                    }
                    catch (Exception ex)
                    {
                        Global.Instance.MessageHub.PublishAsync(new LogMessage(this, new LogText(ex.Message)));
                    }
            }));

            buttonStart.Invoke(new Action(() =>
            {
                buttonStart.Enabled = hasBoats;
                if (arguments.Autostart)
                    if (selectedBoatRefreshStarted)
                        Global.Instance.StopSelectedBoatDataRefreshTask();
                    else
                        Global.Instance.LaunchSelectedBoatDataRefreshTask();
                        if (arguments.Launch != "")
                            try
                            {
                                Process.Start(arguments.Launch);
                            }
                            catch (Exception ex)
                            {
                                Global.Instance.MessageHub.PublishAsync(new LogMessage(this, new LogText(ex.Message)));
                            }
            }));

            if (!hasBoats) Global.Instance.SelectedBoatNumber = null;
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
            if (selectedBoatRefreshStarted) Global.Instance.StopSelectedBoatDataRefreshTask();
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

        private void checkBoxDeadReckoning_CheckedChanged(object sender, EventArgs e)
        {
            DeadReckoning.Active = checkBoxDeadReckoning.Checked;
        }
    }
}
