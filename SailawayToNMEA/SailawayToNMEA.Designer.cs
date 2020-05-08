
using System.Windows.Forms;

namespace SailawayToNMEA
{
    partial class SailawayToNMEA
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SailawayToNMEA));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBoats = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoadBoats = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.checkBoxDeadReckoning = new System.Windows.Forms.CheckBox();
            this.numericUpDownDeadReckoningRate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadReckoningRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NMEA TCP Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User name";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(102, 47);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 2;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            this.textBoxUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUsername_KeyDown);
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(102, 12);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownPort.TabIndex = 1;
            this.numericUpDownPort.Value = new decimal(new int[] {
            10110,
            0,
            0,
            0});
            this.numericUpDownPort.ValueChanged += new System.EventHandler(this.numericUpDownPort_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Boat";
            // 
            // comboBoxBoats
            // 
            this.comboBoxBoats.DisplayMember = "BoatName";
            this.comboBoxBoats.Enabled = false;
            this.comboBoxBoats.FormattingEnabled = true;
            this.comboBoxBoats.Location = new System.Drawing.Point(102, 79);
            this.comboBoxBoats.Name = "comboBoxBoats";
            this.comboBoxBoats.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBoats.Sorted = true;
            this.comboBoxBoats.TabIndex = 4;
            this.comboBoxBoats.ValueMember = "BoatNumber";
            this.comboBoxBoats.SelectedIndexChanged += new System.EventHandler(this.comboBoxBoats_SelectedIndexChanged);
            this.comboBoxBoats.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxBoats_KeyDown);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(229, 77);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(289, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "You need to have been online in the past 7 days";
            // 
            // buttonLoadBoats
            // 
            this.buttonLoadBoats.Enabled = false;
            this.buttonLoadBoats.Location = new System.Drawing.Point(208, 47);
            this.buttonLoadBoats.Name = "buttonLoadBoats";
            this.buttonLoadBoats.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadBoats.TabIndex = 3;
            this.buttonLoadBoats.Text = "Load boats";
            this.buttonLoadBoats.UseVisualStyleBackColor = true;
            this.buttonLoadBoats.Click += new System.EventHandler(this.buttonLoadBoats_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(12, 106);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLog.Size = new System.Drawing.Size(776, 389);
            this.richTextBoxLog.TabIndex = 10;
            this.richTextBoxLog.Text = "";
            // 
            // checkBoxDeadReckoning
            // 
            this.checkBoxDeadReckoning.AutoSize = true;
            this.checkBoxDeadReckoning.Checked = true;
            this.checkBoxDeadReckoning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeadReckoning.Location = new System.Drawing.Point(373, 81);
            this.checkBoxDeadReckoning.Name = "checkBoxDeadReckoning";
            this.checkBoxDeadReckoning.Size = new System.Drawing.Size(171, 17);
            this.checkBoxDeadReckoning.TabIndex = 11;
            this.checkBoxDeadReckoning.Text = "Activate dead reckoning every";
            this.checkBoxDeadReckoning.UseVisualStyleBackColor = true;
            this.checkBoxDeadReckoning.CheckedChanged += new System.EventHandler(this.checkBoxDeadReckoning_CheckedChanged);
            // 
            // numericUpDownDeadReckoningRate
            // 
            this.numericUpDownDeadReckoningRate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownDeadReckoningRate.Location = new System.Drawing.Point(541, 78);
            this.numericUpDownDeadReckoningRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownDeadReckoningRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDeadReckoningRate.Name = "numericUpDownDeadReckoningRate";
            this.numericUpDownDeadReckoningRate.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownDeadReckoningRate.TabIndex = 12;
            this.numericUpDownDeadReckoningRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDeadReckoningRate.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownDeadReckoningRate.ValueChanged += new System.EventHandler(this.numericUpDownDeadReckoningRate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(592, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "seconds";
            // 
            // SailawayToNMEA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownDeadReckoningRate);
            this.Controls.Add(this.checkBoxDeadReckoning);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.buttonLoadBoats);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxBoats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SailawayToNMEA";
            this.Text = "Sailaway to NMEA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SailawayToNMEA_FormClosing);
            this.Load += new System.EventHandler(this.SailawayToNMEA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadReckoningRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private Label label3;
        private ComboBox comboBoxBoats;
        private Button buttonStart;
        private Label label4;
        private Button buttonLoadBoats;
        private RichTextBox richTextBoxLog;
        private CheckBox checkBoxDeadReckoning;
        private NumericUpDown numericUpDownDeadReckoningRate;
        private Label label5;
    }
}

