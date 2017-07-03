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
using WindowsFormsApplication1;


namespace ADCP_Track
{
    public partial class CmdADCP : Form
    {
        private Class_PD0.RealTime PD0RealT = new Class_PD0.RealTime();
        private Encoding enc = Encoding.ASCII;
        SerialPort SerialIN;
        public delegate void IODataReceived(Object sender, ComDataReceivied e);
        public event IODataReceived DataREvent;
        public CmdADCP()
        {
            InitializeComponent();
        }

        public CmdADCP(SerialPort Serial00)
        {
            InitializeComponent();
            SerialIN = Serial00;

          // openingSerial();
        }

        private void openingSerial()
        {
            SerialIN.Open();
        }

        public struct ComDataReceivied
        {
            public string ASCIIDATA;
            public Byte[] BinData;
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
                if (tempC[0] == (char)8)//Backspace
                {

                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                }
                else if (tempC[0] == (char)13)//Enter
                {
                    textBox1.Text += Environment.NewLine;
                    SerialIN.Write(textBox1.ToString());
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

        string tempEnc;
        int bytes;
        byte[] combuff;
        void serialTerminalADCP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bytes = SerialIN.BytesToRead;
            combuff = new byte[bytes];
            SerialIN.Read(combuff, 0, bytes);

            //tempEnc = enc.GetString(combuff);
            /*  if(PD0RealT.AddByteToBufferIN(combuff)== Class_PD0.RecordType.Ensemble)
              {
                  Process
              }*/
            tempEnc = "hello";
            combuff = null;
            display(tempEnc);
        }

        private delegate void SetTextOutCallback(string txt);
        public void display(string txt)
        {
            try
            {
                if (textBox1.InvokeRequired)
                {
                    SetTextOutCallback stoc = new SetTextOutCallback(display);
                    this.Invoke(stoc, new object[] { txt });
                }
                else
                {
                    textBox1.AppendText(txt);
                    if(textBox1.Text.Length > 10000) { textBox1.Text = ""; }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        void displaydata(object sender, CmdADCP.ComDataReceivied e)
        {
            display(e.ASCIIDATA);
            DataREvent?.Invoke(this, e);

        }

        
    }
}
