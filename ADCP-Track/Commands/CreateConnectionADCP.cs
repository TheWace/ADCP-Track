﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADCP_Track.Commands
{
    class CreateConnectionADCP
    {
        public SerialPort Serip = new SerialPort();
        public string namePort { get; set; }
        public int baudrateValue { get; set; }

        public void connection()
        {
            Serip.PortName = namePort;
            Serip.BaudRate = baudrateValue;
            Serip.DtrEnable = true;
            Serip.Parity = Parity.None;
            Serip.StopBits = StopBits.One;
            Serip.DataBits = 8;
            Serip.Handshake = Handshake.None;
        }

        public void open()
        {
            try
            {
                Serip.Open();
                ConnectionADCP.ActiveForm.Close();
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                ConnectionADCP.ActiveForm.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Serip.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }

    }
}