using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADCP_Track.Commands;
using System.Windows.Forms;

namespace ADCP_Track
{
    public partial class ConnectionADCP : Form
    {
        private CreateConnectionADCP Serip = new CreateConnectionADCP();
        ComSettingsStruct ComSetting0;


        public struct ComSettingsStruct
        {
            public string ComName;// = "COM1";
            public int ComSpeed;// = 9600;
        }
        public ConnectionADCP(ComSettingsStruct ComSetting1)
        {
            Serip.namePort = ComSetting1.ComName;
            Serip.baudrateValue = int.Parse(ComSetting1.ComSpeed.ToString());
        }
        // Commands.CreateConnectionADCP Serip;
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
                Serip.Start();
                this.Close();
                Serip.Serip.Write("===");
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
            
            
            // affichage du port com dans le form principale
            //this.textBoxPortCOM.Text = comboBoxCOM.SelectedItem.ToString(); 

            
        }

        private void comboBoxCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCOM.Text = comboBoxCOM.SelectedItem.ToString();
            Serip.namePort = comboBoxCOM.Text;
        }

        
        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBaudrate.Text = comboBoxBaudrate.SelectedItem.ToString();
            Serip.baudrateValue = int.Parse(comboBoxBaudrate.Text);
        }

        private void ConnectionADCP_Load(object sender, EventArgs e)
        {

        }
        public ComSettingsStruct ComSetting
        {
            get { return ComSetting0; }
        }



       

        public string GetNamePort()
        {
            return Serip.namePort;
        }
        
    }
}
