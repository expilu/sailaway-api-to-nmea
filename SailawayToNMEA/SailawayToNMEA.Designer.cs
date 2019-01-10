
using System.Windows.Forms;

namespace SailawayToNMEA
***REMOVED***
    partial class SailawayToNMEA
    ***REMOVED***
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        ***REMOVED***
            if (disposing && (components != null))
            ***REMOVED***
                components.Dispose();
        ***REMOVED***
            base.Dispose(disposing);
    ***REMOVED***

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        ***REMOVED***
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBoats = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
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
            this.textBoxUsername.Enabled = false;
            this.textBoxUsername.Location = new System.Drawing.Point(102, 47);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 3;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(102, 12);
            this.numericUpDownPort.Maximum = new decimal(new int[] ***REMOVED***
            65535,
            0,
            0,
            0***REMOVED***);
            this.numericUpDownPort.Minimum = new decimal(new int[] ***REMOVED***
            1,
            0,
            0,
            0***REMOVED***);
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownPort.TabIndex = 4;
            this.numericUpDownPort.Value = new decimal(new int[] ***REMOVED***
            10110,
            0,
            0,
            0***REMOVED***);
            this.numericUpDownPort.ValueChanged += new System.EventHandler(this.numericUpDownPort_ValueChanged);
            // 
            // textBoxLog
            // 
            this.textBoxLog.AcceptsReturn = true;
            this.textBoxLog.AcceptsTab = true;
            this.textBoxLog.CausesValidation = false;
            this.textBoxLog.Location = new System.Drawing.Point(12, 129);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(776, 309);
            this.textBoxLog.TabIndex = 5;
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
            this.comboBoxBoats.TabIndex = 7;
            this.comboBoxBoats.ValueMember = "BoatNumber";
            this.comboBoxBoats.SelectedIndexChanged += new System.EventHandler(this.comboBoxBoats_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(260, 77);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "You need to have been online in the past 7 days";
            // 
            // SailawayToNMEA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxBoats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SailawayToNMEA";
            this.Text = "Sailaway to NMEA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SailawayToNMEA_FormClosing);
            this.Load += new System.EventHandler(this.SailawayToNMEA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    ***REMOVED***

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.TextBox textBoxLog;
        private Label label3;
        private ComboBox comboBoxBoats;
        private Button buttonStart;
        private Label label4;
***REMOVED***
***REMOVED***

