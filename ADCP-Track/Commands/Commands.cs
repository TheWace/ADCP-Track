using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCP_Track.Commands
{
    interface Commands
    {
        SerialPort Serip { get; set; }
    }
}
