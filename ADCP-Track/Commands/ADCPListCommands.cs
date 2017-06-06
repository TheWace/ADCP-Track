using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCP_Track.Commands
{
    class ADCPListCommands : Commands
    {
        public static void ListCommande()
        {
            Console.WriteLine("B:\t Send break to the ADCP \nC:\t Close connexion with port \nO:\t Open connexion with port \nOff:\t Make ADCP in standby \nS:\t Start ADCP\nES:\t Execute a script\nRS:\t Read a script");
        }


        public static void Config() //Configuration de l'ADCP
        {

            try //Vérification de la connexion du port
            {
                Serip.WriteLine("ol");

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("ERROR: Port has been closed. Open him to send command");
            }
        }
    }
}
