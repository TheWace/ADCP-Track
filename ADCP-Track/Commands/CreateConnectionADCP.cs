using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADCP_Track.Commands
{
    class CreateConnectionADCP
    {
        ConnectionADCP.ComSettingsStruct comstruct0;

        public void GetADCPParameterConnection()
        {
            ConnectionADCP com0 = new ConnectionADCP();
            com0.ShowDialog();
            comstruct0 = com0.ComSettingConnection;
        }
        
        public CreateConnectionADCP()
        {
            
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }

        public void Start()
        {
            
            SerialPort Serip = new SerialPort();
            try
            {
                Serip.PortName = comstruct0.ComName;
                Serip.BaudRate = comstruct0.ComSpeed;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("ERROR: port can't be used");
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
            Serip.Open();
            Serip.Write("===");
            Serip.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        

        
    }
}
