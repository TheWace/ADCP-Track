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
        SerialPort Serip = new SerialPort();
        
        
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


        public void buttonValidation_Click(object sender, EventArgs e)
        {
            connectionADCP();
            
            // affichage du port com dans le form principale
            //this.textBoxPortCOM.Text = comboBoxCOM.SelectedItem.ToString(); 
        }

        public void connectionADCP()
        {
            // Cree la connection avec l'ADCP
            Serip.BaudRate = int.Parse(comboBoxBaudrate.SelectedItem.ToString());
            Serip.PortName = comboBoxCOM.SelectedItem.ToString();
            Serip.DtrEnable = true;
            Serip.Parity = Parity.None;
            Serip.StopBits = StopBits.One;
            Serip.DataBits = 8;
            Serip.Handshake = Handshake.None;
            try
            {
                Serip.Open();
                this.Close();
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Serip.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }

        public void comboBoxCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCOM.Text = comboBoxCOM.SelectedItem.ToString();
        }

        
        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBaudrate.Text = comboBoxBaudrate.SelectedItem.ToString();
        }

        private void ConnectionADCP_Load(object sender, EventArgs e)
        {

        }

    }
}
