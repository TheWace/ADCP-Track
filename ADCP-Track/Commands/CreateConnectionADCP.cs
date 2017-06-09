using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADCP_Track.Commands
{
    class CreateConnectionADCP : SerialPort
    {
        public string namePort { get; set; }
        public int baudrateValue { get; set; }
        public static SerialPort Serip;

        public void connection()
        {
            try
            {
                Serip.PortName = namePort;
                Serip.BaudRate = baudrateValue;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You can't take this value");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("ERROR: port not found");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERROR: port not found");
            }
            Serip.DtrEnable = true;
            Serip.Parity = Parity.None;
            Serip.StopBits = StopBits.One;
            Serip.DataBits = 8;
            Serip.Handshake = Handshake.None;
        }

        public void open()
        {
            try
            {
                Serip.Open();
                ConnectionADCP.ActiveForm.Close();
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                ConnectionADCP.ActiveForm.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Serip.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            Serip.Write("===");

        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }

    }
}
