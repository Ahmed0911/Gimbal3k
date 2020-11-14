using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Gimbal3kWInClient
{
    public partial class MainForm : Form
    {
        private UdpClient udpClient;
        private const int TargetPort = 12000;
        private string TargetAdress = ""; // filled in dialog
        private int LocalPort = 0; // autoselect port (will be sent in ping command)        

        private SGimbal3kData localGimbalDataCopy;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // get IP address
            TargetAdress = textBoxIPAddress.Text;

            // create UDP Client
            udpClient = new UdpClient(LocalPort);
            LocalPort = ((IPEndPoint)udpClient.Client.LocalEndPoint).Port; // get local port (receive)
            timerPeriodic.Enabled = true;

            buttonConnect.Enabled = false;
        }

        private void timerPeriodic_Tick(object sender, EventArgs e)
        {
            // send ping
            byte[] lp = BitConverter.GetBytes(LocalPort); // send local port
            SendData(0x10, lp);

            // Receive Data, Get data from UDP
            while (udpClient.Available > 0)
            {
                // get data
                IPEndPoint endP = new IPEndPoint(IPAddress.Any, 0); // any port of the sender
                byte[] bytes = udpClient.Receive(ref endP);

                // process data
                if (PacketIsValid(bytes))
                {
                    // remove header
                    byte[] withoutHeader = bytes.Skip(3).ToArray();
                    switch (bytes[2])
                    {
                        case 0x20:
                            // data                            
                            SGimbal3kData gimbalData = (SGimbal3kData)Comm.FromBytes(withoutHeader, new SGimbal3kData());
                            localGimbalDataCopy = gimbalData;
                            break;
                    }
                }
            }

            // update screen
            textBoxMainLoopCounter.Text = localGimbalDataCopy.LoopCounter.ToString();
            textBoxPositionPan.Text = localGimbalDataCopy.Position1.ToString();
            textBoxPositionTilt.Text = localGimbalDataCopy.Position2.ToString();
        }

        ///////////////////////////////
        // HELPERS
        ///////////////////////////////
        private bool PacketIsValid(byte[] bytes)
        {
            bool valid = true;
            if (bytes[0] != 0x42) valid = false;
            if (bytes[1] != 0x24) valid = false;

            return valid;
        }
        public void SendData(byte type, byte[] buffer)
        {
            if (udpClient == null) return;

            byte[] data = new byte[buffer.Length + 3];
            // assemble
            data[0] = 0x42;
            data[1] = 0x24;
            data[2] = type; // Type
            Array.Copy(buffer, 0, data, 3, buffer.Length);
            udpClient.Send(data, data.Length, TargetAdress, TargetPort); // target port is ignored (use 10000)
        }
    }
}
