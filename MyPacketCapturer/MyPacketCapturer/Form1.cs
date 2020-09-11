using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using PacketDotNet;
using System.Windows.Forms;

namespace MyPacketCapturer
{
    public partial class Form1 : Form
    {
        //List of devices for this computer
        CaptureDeviceList devices;
        //The device we will be using
        public static ICaptureDevice device;
        //date that is captured
        public static string stringPackets = ""
            ;
        public Form1()
        {
            InitializeComponent();
            //get list of devices
            devices = CaptureDeviceList.Instance;

            //Exit program if we don't have any devices
            if (devices.Count < 1)
            {
                MessageBox.Show("No Caputre Devices Found");
                Application.Exit();
            }

            //put devices into the combo box
            foreach(ICaptureDevice dev in devices)
            {
                cmbDevices.Items.Add(dev.Description);
            }

            //This is what Dr. Harris had. I prefer to only have this in one spot. Added an if in the event to catch if a device is not selected

            ////get the first device and display in combo box
            //device = devices[6];
            //cmbDevices.Text = device.Description;

            ////Register the handler function
            //device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            ////Open the device for capturing
            //int readTimeoutMilliseconds = 1000;
            //device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
        }

        private static void device_OnPacketArrival(object sender, CaptureEventArgs packet)
        {
            //array to store our data
            byte[] data = packet.Packet.Data;

            //keep track of the number of bytes displayed per line
            int byteCounter = 0;

            //Process each byte in our capture packet
            foreach(byte b in data)
            {
                //Add the byte tot he stringe (in hex)
                stringPackets += b.ToString("X2") + " ";
                byteCounter++;

                //make new line
                if (byteCounter == 16)
                {
                    byteCounter = 0;
                    stringPackets += Environment.NewLine;
                }

                
            }

            stringPackets += Environment.NewLine;
            stringPackets += Environment.NewLine;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem == null)
            {
                MessageBox.Show("No Caputre Devices Selected");
                return;
            }
            try
            {
                if (btnStartStop.Text == "Start")
                {
                    device.StartCapture();
                    timer1.Enabled = true;
                    btnStartStop.Text = "Stop";
                }
                else
                {
                    device.StopCapture();
                    timer1.Enabled = false;
                    btnStartStop.Text = "Start";
                }
            }
            catch
            {

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCapturedData.AppendText(stringPackets);
            stringPackets = "";
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = devices[cmbDevices.SelectedIndex];
            cmbDevices.Text = device.Description;

            //Register the handler function
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            //Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
        }
    }
}
