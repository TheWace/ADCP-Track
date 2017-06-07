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
            }catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        public void comboBoxCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Serip.PortName = comboBoxCOM.SelectedItem.ToString();
        }

        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Serip.BaudRate = int.Parse(comboBoxBaudrate.SelectedItem.ToString());
        }

        private void ConnectionADCP_Load(object sender, EventArgs e)
        {

        }

    }
}
