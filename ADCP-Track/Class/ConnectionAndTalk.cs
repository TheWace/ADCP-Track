using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using WindowsFormsApplication1;
using System.Windows.Forms;

namespace ADCP_Track.Class
{
    class ConnectionAndTalk
    {
        // cmdADCP
        private Class_PD0.RealTime PD0RealT = new Class_PD0.RealTime();
        private Encoding enc = Encoding.ASCII;
        public delegate void IODataReceived(Object sender, ComDataReceivied e);
        public event IODataReceived DataREvent;

        public CmdADCP cmd = new CmdADCP();
       
        SerialPort Seriport;

        public ConnectionAndTalk()
        {
            Seriport = new SerialPort();
            this.Start();
        }

        public void openwimdow()
        {
            cmd.Show();
        }

        public struct ComDataReceivied
        {
            public string ASCIIDATA;
            public Byte[] BinData;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Seriport.IsOpen)
            {
                if (e.KeyValue == 72) { Seriport.Write("==="); };
            }
        }

        char[] tempC = new char[1];

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            tempC[0] = e.KeyChar;
            byte[] byte0 = enc.GetBytes(tempC);
            if (Seriport.IsOpen)
            {

                Seriport.Write(byte0, 0, byte0.Length);
                if (tempC[0] == (char)8)//Backspace
                {

                    cmd.textBox1.Text = cmd.textBox1.Text.Substring(0, cmd.textBox1.Text.Length - 1);

                }
                else if (tempC[0] == (char)13)//Enter
                {
                    cmd.textBox1.Text += Environment.NewLine;
                    Seriport.Write(cmd.textBox1.ToString());

                }
                cmd.textBox1.Focus();
                cmd.textBox1.SelectionStart = cmd.textBox1.Text.Length;

            }
            e.Handled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        string tempEnc;
        int bytes;
        byte[] combuff;


        private delegate void SetTextOutCallback(string txt);
        public void display(string txt)
        {
            try
            {
                if (cmd.textBox1.InvokeRequired)
                {
                    SetTextOutCallback stoc = new SetTextOutCallback(display);
                    cmd.Invoke(stoc, new object[] { txt });
                }
                else
                {
                    cmd.textBox1.AppendText(txt);
                    if (cmd.textBox1.Text.Length > 10000) { cmd.textBox1.Text = ""; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void displaydata(object sender, ComDataReceivied e)
        {
            display(e.ASCIIDATA);
            DataREvent?.Invoke(this, e);

        }

        // CreateConnection
        //ComSettingsStruct comstruct0;




        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //  SerialPort sp = (SerialPort)sender;
            // string indata = sp.ReadExisting();
            bytes = Seriport.BytesToRead;
            combuff = new byte[bytes];
            Seriport.Read(combuff, 0, bytes);

            tempEnc = enc.GetString(combuff);
            /*  if(PD0RealT.AddByteToBufferIN(combuff)== Class_PD0.RecordType.Ensemble)
              {
                  Process
              }*/
            combuff = null;
            display(tempEnc);
            // Seriport.display(indata);
        }

        public void Start()
        {
            try
            {
                Seriport.PortName = "COM1";//comstruct0.ComName;
                Seriport.BaudRate = 9600;//comstruct0.ComSpeed;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("ERROR: port can't be used");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("ERROR: port not found");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERROR: port not found");
            }
            Seriport.DtrEnable = true;
            Seriport.Parity = Parity.None;
            Seriport.StopBits = StopBits.One;
            Seriport.DataBits = 8;
            Seriport.Handshake = Handshake.None;

            try
            {

                Seriport.Open();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Seriport.Write("===");
            Seriport.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
