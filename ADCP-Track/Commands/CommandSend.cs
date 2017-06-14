using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ADCP_Track.Commands
{
    class CommandSend : CreateConnectionADCP
    {

        public void Break() //Break de l'ADCP
        {
            try //Vérification de la connexion du port
            {
                Thread.Sleep(300);
           //     Serip.Write("===");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("ERROR: Port has been closed. Open him to send command");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Reference null");
            }
        }

        public void ListCommande()
        {
            Console.WriteLine("B:\t Send break to the ADCP \nC:\t Close connexion with port \nO:\t Open connexion with port \nOff:\t Make ADCP in standby \nS:\t Start ADCP\nES:\t Execute a script\nRS:\t Read a script");
        }

        public void StartPing()  //Lancement de l'ADCP
        {
            try
            {
         //       Serip.Write("\t");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Operation failed");
            }
        }

        public void ExecuteScript(string[] scripts)
        {
            ExecSript file = new ExecSript();
            try
            {
                foreach (string line in scripts)
                {
                    Thread.Sleep(100);
                    file.Exec(line);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Not file found");
            }
        }

    }
}
