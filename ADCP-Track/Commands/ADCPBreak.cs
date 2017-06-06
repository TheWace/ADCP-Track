using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADCP_Track.Commands 
{
    class ADCPBreak : Commands
    {
        public static void Break() //Break de l'ADCP
        {

            try //Vérification de la connexion du port
            {
                Thread.Sleep(300);
                Serip.Write("===");
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
    }
}
