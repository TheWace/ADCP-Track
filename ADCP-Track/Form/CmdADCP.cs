using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADCP_Track
{
    public partial class CmdADCP : Form
    {
        private Encoding enc = Encoding.ASCII;
        Commands.CreateConnectionADCP SerialIN;
        public CmdADCP()
        {
            InitializeComponent();
            SerialIN = new Commands.CreateConnectionADCP();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (SerialIN.Serip.IsOpen)
            {
                if (e.KeyValue == 35) { SerialIN.Serip.Write("==="); };
            } 
        }

        char[] tempC = new char[1];

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            tempC[0] = e.KeyChar;
            byte[] byte0 = enc.GetBytes(tempC);
            if (SerialIN.Serip.IsOpen) // && tempC[0] != (char)35)
            { SerialIN.Serip.Write(byte0, 0, byte0.Length); }

            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
