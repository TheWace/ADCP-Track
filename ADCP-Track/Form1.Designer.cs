namespace ADCP_Track
{
    partial class ADCPTrack
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.MenuStrip menuStripTools;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.connexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemShip = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSend = new System.Windows.Forms.ToolStripMenuItem();
            this.commandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendScriptFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editScriptFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAntiSun = new System.Windows.Forms.ToolStripMenuItem();
            this.ModeToolStripMenuItemAutoConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBOT = new System.Windows.Forms.Button();
            this.buttonLDR = new System.Windows.Forms.Button();
            this.buttonNAV = new System.Windows.Forms.Button();
            this.buttonWTR = new System.Windows.Forms.Button();
            this.buttonCFG = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.RawVelocity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RawDataQuality = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxRawVelo = new System.Windows.Forms.TextBox();
            this.textBoxRawData = new System.Windows.Forms.TextBox();
            this.labelADCP = new System.Windows.Forms.Label();
            menuStripTools = new System.Windows.Forms.MenuStrip();
            menuStripTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RawVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RawDataQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripTools
            // 
            menuStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemEdit,
            this.ToolStripMenuItemOption,
            this.ToolStripMenuItemShip,
            this.ToolStripMenuItemHelp,
            this.ToolStripMenuItemSend,
            this.ToolStripMenuItemAntiSun,
            this.ModeToolStripMenuItemAutoConfig});
            menuStripTools.Location = new System.Drawing.Point(0, 0);
            menuStripTools.Name = "menuStripTools";
            menuStripTools.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            menuStripTools.Size = new System.Drawing.Size(1334, 27);
            menuStripTools.TabIndex = 0;
            menuStripTools.Text = "menuStripTools";
            menuStripTools.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexionToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(37, 19);
            this.ToolStripMenuItemFile.Text = "File";
            this.ToolStripMenuItemFile.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // connexionToolStripMenuItem
            // 
            this.connexionToolStripMenuItem.Name = "connexionToolStripMenuItem";
            this.connexionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connexionToolStripMenuItem.Text = "Connexion";
            this.connexionToolStripMenuItem.Click += new System.EventHandler(this.connexionToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(39, 19);
            this.ToolStripMenuItemEdit.Text = "Edit";
            // 
            // ToolStripMenuItemOption
            // 
            this.ToolStripMenuItemOption.Name = "ToolStripMenuItemOption";
            this.ToolStripMenuItemOption.Size = new System.Drawing.Size(56, 19);
            this.ToolStripMenuItemOption.Text = "Option";
            // 
            // ToolStripMenuItemShip
            // 
            this.ToolStripMenuItemShip.Name = "ToolStripMenuItemShip";
            this.ToolStripMenuItemShip.Size = new System.Drawing.Size(42, 19);
            this.ToolStripMenuItemShip.Text = "Ship";
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(44, 19);
            this.ToolStripMenuItemHelp.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemSend
            // 
            this.ToolStripMenuItemSend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandToolStripMenuItem,
            this.sendScriptFileToolStripMenuItem,
            this.editScriptFileToolStripMenuItem});
            this.ToolStripMenuItemSend.Name = "ToolStripMenuItemSend";
            this.ToolStripMenuItemSend.Size = new System.Drawing.Size(45, 19);
            this.ToolStripMenuItemSend.Text = "Send";
            // 
            // commandToolStripMenuItem
            // 
            this.commandToolStripMenuItem.Name = "commandToolStripMenuItem";
            this.commandToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.commandToolStripMenuItem.Text = "Command";
            this.commandToolStripMenuItem.Click += new System.EventHandler(this.commandToolStripMenuItem_Click);
            // 
            // sendScriptFileToolStripMenuItem
            // 
            this.sendScriptFileToolStripMenuItem.Name = "sendScriptFileToolStripMenuItem";
            this.sendScriptFileToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sendScriptFileToolStripMenuItem.Text = "Send Script File";
            this.sendScriptFileToolStripMenuItem.Click += new System.EventHandler(this.sendScriptFileToolStripMenuItem_Click);
            // 
            // editScriptFileToolStripMenuItem
            // 
            this.editScriptFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.modifyToolStripMenuItem});
            this.editScriptFileToolStripMenuItem.Name = "editScriptFileToolStripMenuItem";
            this.editScriptFileToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editScriptFileToolStripMenuItem.Text = "Edit Script File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "new";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.modifyToolStripMenuItem.Text = "modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemAntiSun
            // 
            this.ToolStripMenuItemAntiSun.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripMenuItemAntiSun.BackColor = System.Drawing.SystemColors.ControlText;
            this.ToolStripMenuItemAntiSun.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ToolStripMenuItemAntiSun.Name = "ToolStripMenuItemAntiSun";
            this.ToolStripMenuItemAntiSun.Size = new System.Drawing.Size(97, 19);
            this.ToolStripMenuItemAntiSun.Text = "Anti-SunMode";
            this.ToolStripMenuItemAntiSun.Click += new System.EventHandler(this.ModeToolStripMenuItemAntiSun_Click);
            // 
            // ModeToolStripMenuItemAutoConfig
            // 
            this.ModeToolStripMenuItemAutoConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ModeToolStripMenuItemAutoConfig.Name = "ModeToolStripMenuItemAutoConfig";
            this.ModeToolStripMenuItemAutoConfig.Size = new System.Drawing.Size(81, 19);
            this.ModeToolStripMenuItemAutoConfig.Text = "AutoConfig";
            this.ModeToolStripMenuItemAutoConfig.Click += new System.EventHandler(this.ModeToolStripMenuItemAutoConfig_Click);
            // 
            // buttonBOT
            // 
            this.buttonBOT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonBOT.BackColor = System.Drawing.Color.White;
            this.buttonBOT.Location = new System.Drawing.Point(511, 30);
            this.buttonBOT.Name = "buttonBOT";
            this.buttonBOT.Size = new System.Drawing.Size(93, 33);
            this.buttonBOT.TabIndex = 1;
            this.buttonBOT.Text = "BOTOMTRACK";
            this.buttonBOT.UseVisualStyleBackColor = false;
            this.buttonBOT.Click += new System.EventHandler(this.buttonBOT_Click);
            // 
            // buttonLDR
            // 
            this.buttonLDR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonLDR.Location = new System.Drawing.Point(610, 30);
            this.buttonLDR.Name = "buttonLDR";
            this.buttonLDR.Size = new System.Drawing.Size(93, 33);
            this.buttonLDR.TabIndex = 2;
            this.buttonLDR.Text = "LEADER";
            this.buttonLDR.UseVisualStyleBackColor = false;
            this.buttonLDR.Click += new System.EventHandler(this.buttonLDR_Click);
            // 
            // buttonNAV
            // 
            this.buttonNAV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNAV.Location = new System.Drawing.Point(709, 30);
            this.buttonNAV.Name = "buttonNAV";
            this.buttonNAV.Size = new System.Drawing.Size(93, 33);
            this.buttonNAV.TabIndex = 3;
            this.buttonNAV.Text = "NAVIGATION";
            this.buttonNAV.UseVisualStyleBackColor = false;
            this.buttonNAV.Click += new System.EventHandler(this.buttonNAV_Click);
            // 
            // buttonWTR
            // 
            this.buttonWTR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonWTR.Location = new System.Drawing.Point(412, 30);
            this.buttonWTR.Name = "buttonWTR";
            this.buttonWTR.Size = new System.Drawing.Size(93, 33);
            this.buttonWTR.TabIndex = 4;
            this.buttonWTR.Text = "WATERREF";
            this.buttonWTR.UseVisualStyleBackColor = false;
            this.buttonWTR.Click += new System.EventHandler(this.buttonWTR_Click);
            // 
            // buttonCFG
            // 
            this.buttonCFG.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonCFG.AutoSize = true;
            this.buttonCFG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCFG.Location = new System.Drawing.Point(809, 30);
            this.buttonCFG.Name = "buttonCFG";
            this.buttonCFG.Size = new System.Drawing.Size(93, 33);
            this.buttonCFG.TabIndex = 5;
            this.buttonCFG.Text = "CONFIG";
            this.buttonCFG.UseVisualStyleBackColor = false;
            this.buttonCFG.Click += new System.EventHandler(this.buttonCFG_Click);
            // 
            // RawVelocity
            // 
            this.RawVelocity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RawVelocity.BackColor = System.Drawing.Color.Black;
            chartArea5.Name = "ChartArea1";
            this.RawVelocity.ChartAreas.Add(chartArea5);
            legend5.BackColor = System.Drawing.Color.White;
            legend5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            legend5.InterlacedRows = true;
            legend5.IsDockedInsideChartArea = false;
            legend5.Name = "Legend1";
            legend5.Position.Auto = false;
            legend5.Position.Height = 8.026756F;
            legend5.Position.Width = 21.98853F;
            this.RawVelocity.Legends.Add(legend5);
            this.RawVelocity.Location = new System.Drawing.Point(28, 72);
            this.RawVelocity.Name = "RawVelocity";
            this.RawVelocity.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.LabelBorderWidth = 0;
            series5.Legend = "Legend1";
            series5.MarkerBorderWidth = 2;
            series5.MarkerSize = 10;
            series5.Name = "Raw Velocity";
            this.RawVelocity.Series.Add(series5);
            this.RawVelocity.Size = new System.Drawing.Size(524, 300);
            this.RawVelocity.TabIndex = 6;
            this.RawVelocity.Text = "chartRawVelocity";
            title5.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title5.ForeColor = System.Drawing.Color.White;
            title5.Name = "Raw Velocity";
            title5.Text = "Raw Velocity";
            this.RawVelocity.Titles.Add(title5);
            // 
            // RawDataQuality
            // 
            this.RawDataQuality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RawDataQuality.BackColor = System.Drawing.Color.Black;
            chartArea6.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea6.Name = "ChartArea1";
            this.RawDataQuality.ChartAreas.Add(chartArea6);
            legend6.Alignment = System.Drawing.StringAlignment.Center;
            legend6.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            legend6.DockedToChartArea = "ChartArea1";
            legend6.Name = "Legend1";
            legend6.Position.Auto = false;
            legend6.Position.Height = 8.026756F;
            legend6.Position.Width = 17.58389F;
            this.RawDataQuality.Legends.Add(legend6);
            this.RawDataQuality.Location = new System.Drawing.Point(576, 72);
            this.RawDataQuality.Name = "RawDataQuality";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "RawDataQuality";
            this.RawDataQuality.Series.Add(series6);
            this.RawDataQuality.Size = new System.Drawing.Size(746, 300);
            this.RawDataQuality.TabIndex = 7;
            this.RawDataQuality.Text = "chartRawDataQuality";
            title6.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title6.ForeColor = System.Drawing.Color.White;
            title6.Name = "Raw Data Quality";
            title6.Text = "Raw Data Quality";
            this.RawDataQuality.Titles.Add(title6);
            // 
            // textBoxRawVelo
            // 
            this.textBoxRawVelo.Location = new System.Drawing.Point(149, 378);
            this.textBoxRawVelo.Name = "textBoxRawVelo";
            this.textBoxRawVelo.Size = new System.Drawing.Size(256, 20);
            this.textBoxRawVelo.TabIndex = 8;
            this.textBoxRawVelo.TextChanged += new System.EventHandler(this.textBoxRawVelo_TextChanged);
            // 
            // textBoxRawData
            // 
            this.textBoxRawData.Location = new System.Drawing.Point(794, 378);
            this.textBoxRawData.Name = "textBoxRawData";
            this.textBoxRawData.Size = new System.Drawing.Size(209, 20);
            this.textBoxRawData.TabIndex = 9;
            // 
            // labelADCP
            // 
            this.labelADCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelADCP.AutoSize = true;
            this.labelADCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelADCP.Location = new System.Drawing.Point(12, 625);
            this.labelADCP.Name = "labelADCP";
            this.labelADCP.Size = new System.Drawing.Size(105, 31);
            this.labelADCP.TabIndex = 10;
            this.labelADCP.Text = "ADCP :";
            // 
            // ADCPTrack
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1334, 661);
            this.Controls.Add(this.labelADCP);
            this.Controls.Add(this.textBoxRawData);
            this.Controls.Add(this.textBoxRawVelo);
            this.Controls.Add(this.RawDataQuality);
            this.Controls.Add(this.RawVelocity);
            this.Controls.Add(this.buttonCFG);
            this.Controls.Add(this.buttonWTR);
            this.Controls.Add(this.buttonNAV);
            this.Controls.Add(this.buttonLDR);
            this.Controls.Add(this.buttonBOT);
            this.Controls.Add(menuStripTools);
            this.Location = new System.Drawing.Point(10, 10);
            this.MainMenuStrip = menuStripTools;
            this.Name = "ADCPTrack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADCP Tracker";
            this.Load += new System.EventHandler(this.ADCPTrack_Load);
            menuStripTools.ResumeLayout(false);
            menuStripTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RawVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RawDataQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOption;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSend;
        private System.Windows.Forms.ToolStripMenuItem commandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendScriptFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editScriptFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAntiSun;
        private System.Windows.Forms.ToolStripMenuItem ModeToolStripMenuItemAutoConfig;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connexionToolStripMenuItem;
        private System.Windows.Forms.Button buttonBOT;
        private System.Windows.Forms.Button buttonLDR;
        private System.Windows.Forms.Button buttonNAV;
        private System.Windows.Forms.Button buttonWTR;
        private System.Windows.Forms.Button buttonCFG;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart RawVelocity;
        private System.Windows.Forms.DataVisualization.Charting.Chart RawDataQuality;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxRawVelo;
        private System.Windows.Forms.TextBox textBoxRawData;
        private System.Windows.Forms.Label labelADCP;
    }
}

