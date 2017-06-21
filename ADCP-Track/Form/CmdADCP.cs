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



        public CmdADCP()
        {
            InitializeComponent();
        }

        public CmdADCP(SerialPort Serial00)
        {
            InitializeComponent();
            SerialIN = Serial00;

           openingSerial();
        }

        private void openingSerial()
        {
            SerialIN.Open();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (SerialIN.IsOpen)
            {
                if (e.KeyValue == 72) { SerialIN.Write("==="); };
            } 
        }

        char[] tempC = new char[1];

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            tempC[0] = e.KeyChar;
            byte[] byte0 = enc.GetBytes(tempC);
            if (SerialIN.IsOpen) 
            {

                SerialIN.Write(byte0, 0, byte0.Length);
                if (tempC[0] == (char)8 && textBox1.Text.ToString() != ">")//Backspace
                {

                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                }
                else if (tempC[0] == (char)13)//Enter
                {
                    SerialIN.Write(textBox1.ToString());
                    textBox1.Text += Environment.NewLine +">";
                }
                else
                {
                    textBox1.Text += e.KeyChar.ToString().ToUpper();
                }
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
                
            }
            e.Handled = true;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public void PassSerialPort(SerialPort Serip)
        {
            SerialIN = Serip;
        }
    }
}
