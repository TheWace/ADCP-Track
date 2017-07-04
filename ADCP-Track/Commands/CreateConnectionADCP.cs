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
        internal SerialPort Seriport = new SerialPort();

        public void GetADCPParameterConnection()
        {
            ConnectionADCP com0 = new ConnectionADCP();
            com0.ShowDialog();
            comstruct0 = com0.ComSettingConnection;
            Start();

            
        }
        
        public CreateConnectionADCP()
        {
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
           string indata = sp.ReadExisting();
           // Seriport.display(indata);
        }

        public void Start()
        {
            try
            {
                Seriport.PortName = comstruct0.ComName;
                Seriport.BaudRate = comstruct0.ComSpeed;
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
            Seriport.DtrEnable = true;
            Seriport.Parity = Parity.None;
            Seriport.StopBits = StopBits.One;
            Seriport.DataBits = 8;
            Seriport.Handshake = Handshake.None;

            try
            {
                Seriport.Open();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Seriport.Write("===");
            Seriport.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        
       

        
    }
}
