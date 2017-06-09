using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADCP_Track
{
    class ExecSript
    {
        public static void Exec(string cmd)
        {
            switch (cmd.ToLower())
            {
              /*  case "b":
                    Break();
                    break;
                case "c":
                    Closing();
                    break;
                case "o":
                    Opening();
                    break;
                case "s":
                    StartPing();
                    break;
                case "help":
                case "?":
                    ListCommande();
                    break;
                case "rs":
                case "es":
                    Console.WriteLine("You cannot create an infinite loop");
                    break;
                case "off":
                    Powerdown();
                    break;*/
                default:
                    Console.WriteLine("Command Unknow");
                    break;
            }
        }
    }
}
