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
        public SerialPort Serip = new SerialPort();
        ConnectionADCP.ComSettingsStruct comstruct0;

        public void GetADCPParameter()
        {
        ConnectionADCP com0 = new ConnectionADCP();
        com0.ShowDialog();
        comstruct0 = com0.ComSetting;
        }

        
        public CreateConnectionADCP()
        {
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

            Serip.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        }
        

        

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }
       

        public SerialPort GetSerip()
        {
            return Serip;
        }

        public void SetSerip(SerialPort SP)
        {
            Serip = SP;
        }

        
    }
}
