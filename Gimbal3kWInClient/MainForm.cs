﻿using System;
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

        // Buttons
        private bool ButtonLeft = false;
        private bool ButtonRight = false;
        private bool ButtonUp = false;
        private bool ButtonDown = false;

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
            textBoxPositionPanEnco.Text = localGimbalDataCopy.PositionPanEncoCNT.ToString();
            textBoxPositionTiltEnco.Text = localGimbalDataCopy.PositionTiltEncoCNT.ToString();
            textBoxPositionPanDeg.Text = localGimbalDataCopy.PositionPanDeg.ToString("0.00") + "°";
            textBoxPositionTiltDeg.Text = localGimbalDataCopy.PositionTiltDeg.ToString("0.00") + "°";

            if(localGimbalDataCopy.ActiveMode == 0x00)
            {
                textBoxActiveMode.Text = "DISABLED";
            }
            else if(localGimbalDataCopy.ActiveMode == 0x01)
            {
                textBoxActiveMode.Text = "MANUAL";
            }
            else if (localGimbalDataCopy.ActiveMode == 0x02)
            {
                textBoxActiveMode.Text = "AUTO";
            }
            else textBoxActiveMode.Text = "ERROR";

            // Debug Buttons
            Text = ButtonLeft.ToString() + ",";
            Text += ButtonRight.ToString() + ",";
            Text += ButtonUp.ToString() + ",";
            Text += ButtonDown.ToString();

            // Send Button Commands
            if (radioButtonManualMode.Checked)
            {
                SGimbal3kCommand cmd = new SGimbal3kCommand();
                cmd.Command = 0x1; // manual cmd
                float speed = 0.4f;
                if (ButtonLeft) cmd.RefPan = -speed;
                if (ButtonRight) cmd.RefPan = speed;
                if (ButtonUp) cmd.RefTilt = speed;
                if (ButtonDown) cmd.RefTilt = -speed;

                byte[] cmdArray = Comm.GetBytes(cmd);
                SendData(0x30, cmdArray);
            }
        }

        private void buttonGO_Click(object sender, EventArgs e)
        {
            if (radioButtonAutoMode.Checked)
            {
                float panRefDeg;
                float tiltRefDeg;

                if (float.TryParse(textBoxPanRef.Text, out panRefDeg))
                {
                    if (float.TryParse(textBoxTiltRef.Text, out tiltRefDeg))
                    {
                        // send new ref
                        SGimbal3kCommand cmd = new SGimbal3kCommand();
                        cmd.Command = 0x02; // auto cmd
                        cmd.RefPan = panRefDeg;
                        cmd.RefTilt = tiltRefDeg;

                        byte[] cmdArray = Comm.GetBytes(cmd);
                        SendData(0x30, cmdArray);
                    }
                }
            }
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
            udpClient.Send(data, data.Length, TargetAdress, TargetPort); 
        }

        private void buttonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonLeft = true;
        }

        private void buttonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonLeft = false;
        }

        private void buttonRight_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonRight = true;
        }

        private void buttonRight_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonRight = false;
        }

        private void buttonUp_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonUp = true;
        }

        private void buttonUp_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonUp = false;
        }

        private void buttonDown_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonDown = true;
        }

        private void buttonDown_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonDown = false;
        }
    }
}
