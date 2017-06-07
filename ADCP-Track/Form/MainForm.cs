using BottomTrackExport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ADCP_Track.Commands;
using System.Windows.Forms;

namespace ADCP_Track
{
    public partial class ADCPTrack : Form
    {

        Class_PD0_55 DataSend = new Class_PD0_55();
        public About about;
        public BotomTrack bt;
        public ProcessStartInfo psi;
        public ADCPTrack()
        {
            InitializeComponent();

        }

        private void ADCPTrack_Load(object sender, EventArgs e)
        {
            
            about = new About();
            bt = new BotomTrack();

            

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       

        private void buttonWTR_Click(object sender, EventArgs e)
        {

        }

        private void buttonBOT_Click(object sender, EventArgs e)
        {
            bt.Show(); 
        }

        private void buttonLDR_Click(object sender, EventArgs e)
        {

        }

        private void buttonNAV_Click(object sender, EventArgs e)
        {

        }

        private void buttonCFG_Click(object sender, EventArgs e)
        {

        }

        private void ModeToolStripMenuItemAutoConfig_Click(object sender, EventArgs e)
        {
            
        }
        private void ModeToolStripMenuItemAntiSun_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                UpdateColorControls(c);
            }

        }

        public void UpdateColorControls(Control myControl)
        {
            if (!myControl.BackColor.Equals(Color.DimGray))
            {
                this.BackColor = Color.DimGray;
                this.buttonBOT.BackColor = Color.DimGray;
                this.buttonBOT.ForeColor = Color.White;
                this.ToolStripMenuItemAntiSun.BackColor = Color.White;
                this.ToolStripMenuItemAntiSun.ForeColor = Color.DimGray; 
                myControl.BackColor = Color.DimGray;
                myControl.ForeColor = Color.White;
            }
            else
            {
                this.ToolStripMenuItemAntiSun.BackColor = Color.DimGray;
                this.ToolStripMenuItemAntiSun.ForeColor = Color.White;
                this.BackColor = Color.White;
                myControl.BackColor = Color.White;
                myControl.ForeColor = Color.Black;
            }
            foreach (Control subC in myControl.Controls)
            {
                UpdateColorControls(subC);
            }
        }

        private void sendScriptFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSearched fs = new FileSearched();
            fs.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            dlg.InitialDirectory = @"c:\";
            dlg.Filter = "files (*.txt)|*.txt";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               Process.Start("notepad.exe", "\""+dlg.FileName+"\"");
            }
        }

        private void commandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strp = Environment.CurrentDirectory;
            
                
            //ouvre un terminal et la connection avec l'ADCP pour lui envoyer manuellement des commandes
            
            //
            // TODO !!!
            //
   
            Process p = new Process();
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "cmd.exe";
            p.Start();
            p.StandardInput.WriteLine("MKDIR test1");
           
        }

        private void connexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionADCP conADCP = new ConnectionADCP();
            conADCP.Show();
        }



        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            about.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort.Close();
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ADCPBreak().Break();
        }

        public void textBoxPortCOM_TextChanged(object sender, EventArgs e)
        {
            Form cbox = Application.OpenForms["ConnectionADCP"];
            textBoxPortCOM.Text = ((ConnectionADCP)cbox).comboBoxCOM.Text;
        }
    }
}

