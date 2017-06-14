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
            InitializeComponent();
            comboBoxCOM.Text = ComSetting1.ComName;
            comboBoxBaudrate.Text = ComSetting1.ComSpeed.ToString();
        }

        public ComSettingsStruct ComSettingConnection
        {
            get { return ComSetting0; }
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
                ComSetting0.ComName = comboBoxCOM.Text;
                ComSetting0.ComSpeed = int.Parse(comboBoxBaudrate.Text);
                this.DialogResult = DialogResult.OK;
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

            // affichage du port com dans le form principale
            //this.textBoxPortCOM.Text = comboBoxCOM.SelectedItem.ToString(); 


        }

        private void comboBoxCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCOM.Text = comboBoxCOM.SelectedItem.ToString();
            ComSetting0.ComName = comboBoxCOM.Text;
        }

        
        private void comboBoxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBaudrate.Text = comboBoxBaudrate.SelectedItem.ToString();
            ComSetting0.ComSpeed = int.Parse(comboBoxBaudrate.Text);
        }

        private void ConnectionADCP_Load(object sender, EventArgs e)
        {

        }
        
    }
}
