namespace ADCP_Track
{
    partial class ConnectionADCP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConfigAuto = new System.Windows.Forms.Button();
            this.buttonValidation = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxBits = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonConfigAuto
            // 
            this.buttonConfigAuto.Location = new System.Drawing.Point(12, 12);
            this.buttonConfigAuto.Name = "buttonConfigAuto";
            this.buttonConfigAuto.Size = new System.Drawing.Size(160, 23);
            this.buttonConfigAuto.TabIndex = 0;
            this.buttonConfigAuto.Text = "Configuration Auto";
            this.buttonConfigAuto.UseVisualStyleBackColor = true;
            this.buttonConfigAuto.Click += new System.EventHandler(this.buttonConfigAuto_Click);
            // 
            // buttonValidation
            // 
            this.buttonValidation.Location = new System.Drawing.Point(12, 235);
            this.buttonValidation.Name = "buttonValidation";
            this.buttonValidation.Size = new System.Drawing.Size(75, 23);
            this.buttonValidation.TabIndex = 1;
            this.buttonValidation.Text = "Validation";
            this.buttonValidation.UseVisualStyleBackColor = true;
            this.buttonValidation.Click += new System.EventHandler(this.buttonValidation_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(97, 235);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12"});
            this.comboBoxCOM.Location = new System.Drawing.Point(32, 55);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCOM.TabIndex = 3;
            this.comboBoxCOM.Text = "COM1";
            this.comboBoxCOM.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOM_SelectedIndexChanged);
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(32, 99);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudrate.TabIndex = 4;
            this.comboBoxBaudrate.Text = "9600";
            this.comboBoxBaudrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudrate_SelectedIndexChanged);
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(32, 190);
            this.comboBoxParity.MaxDropDownItems = 1;
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParity.TabIndex = 5;
            this.comboBoxParity.Text = "None";
            // 
            // comboBoxBits
            // 
            this.comboBoxBits.FormattingEnabled = true;
            this.comboBoxBits.Location = new System.Drawing.Point(32, 146);
            this.comboBoxBits.Name = "comboBoxBits";
            this.comboBoxBits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxBits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBits.TabIndex = 6;
            this.comboBoxBits.Text = "1";
            // 
            // ConnectionADCP
            // 
            this.AcceptButton = this.buttonValidation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(184, 274);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxBits);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.comboBoxBaudrate);
            this.Controls.Add(this.comboBoxCOM);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonValidation);
            this.Controls.Add(this.buttonConfigAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Name = "ConnectionADCP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectionADCP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConnectionADCP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConfigAuto;
        private System.Windows.Forms.Button buttonValidation;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxBits;
    }
}