using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADCP_Track
{
    public partial class FileSearched : Form
    {
        public FileSearched()
        {
            InitializeComponent();
        }

        private void buttonValid_Click(object sender, EventArgs e)
        {
            if(textBoxFileName.Text == "")
            {
                this.DialogResult = DialogResult.Cancel;
            }
            
            //Executera le sript
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFileName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileCaract();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            FileCaract();
        }

        private void FileCaract()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = textBoxFileName.Text;
            dlg.InitialDirectory = @"c:\";
            dlg.Filter = "files (*.txt)|*.txt";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBoxFileName.Text = dlg.FileName;
                buttonValid.Enabled = true;
            }
        }
    }
}
