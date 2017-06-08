using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCP_Track.Commands
{
    class ADCPPing : Commands
    {

        public SerialPort Serip { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       
        public void StartPing()  //Lancement de l'ADCP
        {
            try
            {
                Serip.Write("\t");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Operation failed");
            }
        }
    }
}
