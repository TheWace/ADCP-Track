using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADCP_Track
{
    public partial class ConnectionADCP : Form
    {

        private string indata;

        Commands.CreateConnectionADCP Serip { get; set; }
        public ConnectionADCP()
        {
            InitializeComponent();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfigAuto_Click(object sender, EventArgs e)
        {
        
            Cursor.Current = Cursors.WaitCursor;

            comboBoxCOM.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string tempPortName in ports)
            {
                using (SerialPort TempPort = new SerialPort(tempPortName))
                {
                    try { TempPort.Open(); }
                    catch { }
                    finally
                    {
                        if (TempPort.IsOpen)
                        {
                            comboBoxCOM.Items.Add(tempPortName);
                            TempPort.Close();
                            this.comboBoxCOM.Text = tempPortName.ToString();
                        }
                        else
                        {
                            comboBoxCOM.Items.Add(tempPortName);
                        }

                    }
                         
                }
            }

            Cursor.Current = Cursors.Default;
        }


        private void buttonValidation_Click(object sender, EventArgs e)
        {
            
            try
            {
                Serip.connection();

                Serip.open();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // affichage du port com dans le form principale
            //this.textBoxPortCOM.Text = comboBoxCOM.SelectedItem.ToString(); 

            
        }

        public string sendData
        {
            get
            {
                return indata;
            }
        }

        private void comboBoxCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCOM.Text = comboBoxCOM.SelectedItem.ToString();
            Serip.namePort = comboBoxCOM.SelectedItem.ToString();
        }

        
        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBaudrate.Text = comboBoxBaudrate.SelectedItem.ToString();
            Serip.baudrateValue = int.Parse(comboBoxBaudrate.SelectedItem.ToString());
        }

        private void ConnectionADCP_Load(object sender, EventArgs e)
        {

        }

    }
}
