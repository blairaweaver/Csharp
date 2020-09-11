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
        public static string stringPackets = "";
        static int numPackets = 0;
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

        }

        private static void device_OnPacketArrival(object sender, CaptureEventArgs packet)
        {
            //increment the number of packets captured
            numPackets++;

            //Put the packet number in the capture window
            stringPackets += "Packet Number: " + Convert.ToString(numPackets);
            stringPackets += Environment.NewLine;

            //array to store our data
            byte[] data = packet.Packet.Data;

            //keep track of the number of bytes displayed per line
            int byteCounter = 0;

            stringPackets += "Destination MAC Address: ";
            //Parse the packet
            foreach (byte b in data)
            {
                if(byteCounter <= 13)
                {
                    //Add the byte to the stringe (in hex)
                    stringPackets += b.ToString("X2") + " ";
                }

                byteCounter++;

                switch (byteCounter)
                {
                    case 6: 
                        stringPackets += Environment.NewLine;
                        stringPackets += "Source MAC Address: ";
                        break;
                    case 12:
                        stringPackets += Environment.NewLine;
                        stringPackets += "EtherType: ";
                        break;
                    case 14:
                        if(data[12] == 8)
                        {
                            if (data[13] == 0)
                            {
                                stringPackets += "(IP)";
                            }
                            else if (data[13] == 6)
                            {
                                stringPackets += "(ARP)";
                            }
                        }
                        stringPackets += Environment.NewLine;
                        break;
                    default:
                        break;
                }
            }

            stringPackets += Environment.NewLine;

            //Reset the byte counter for next loop
            byteCounter = 0;
            stringPackets += "Raw Data" + Environment.NewLine;

            //Process each byte in our capture packet
            foreach (byte b in data)
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

            stringPackets += Environment.NewLine + Environment.NewLine;
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

        //This is used to update the textboxes in the window
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtNumPackets.Text = Convert.ToString(numPackets);
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

        private void txtCapturedData_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save the Captured Packets";
            saveFileDialog1.ShowDialog();

            //check if filename was given
            if(saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtCapturedData.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog1.Title = "Save the Captured Packets";
            openFileDialog1.ShowDialog();

            //check if filename was given
            if (openFileDialog1.FileName != "")
            {
                txtCapturedData.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }
    }
}
