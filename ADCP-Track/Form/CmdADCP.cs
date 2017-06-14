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
        SerialPort SerialIN;

        public CmdADCP(SerialPort Serip)
        {
            InitializeComponent();
        }


        public CmdADCP()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (SerialIN.IsOpen)
            {
                if (e.KeyValue == 35) { SerialIN.Write("==="); };
            } 
        }

        char[] tempC = new char[1];

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            tempC[0] = e.KeyChar;
            byte[] byte0 = enc.GetBytes(tempC);
            if (SerialIN.IsOpen) // && tempC[0] != (char)35)
            { SerialIN.Write(byte0, 0, byte0.Length); }

            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
