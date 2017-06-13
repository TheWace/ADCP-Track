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
        public string namePort { get; set; }
        public int baudrateValue { get; set; }
        public SerialPort Serip = new SerialPort();
       


        public CreateConnectionADCP()
        {
            try
            {
                Serip.PortName = namePort;
                Serip.BaudRate = baudrateValue;
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

        public void Start()
        {

            Serip.Open();

            Serip.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
    }
}
