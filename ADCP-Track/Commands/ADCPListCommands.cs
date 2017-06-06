using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCP_Track.Commands
{
    class ADCPListCommands : Commands
    {
        public SerialPort Serip { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ListCommande()
        {
            Console.WriteLine("B:\t Send break to the ADCP \nC:\t Close connexion with port \nO:\t Open connexion with port \nOff:\t Make ADCP in standby \nS:\t Start ADCP\nES:\t Execute a script\nRS:\t Read a script");
        }

    }
}
