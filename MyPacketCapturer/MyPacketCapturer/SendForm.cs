using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPacketCapturer
{
    public partial class SendForm : Form
    {
        public static int instantiations = 0;
        private String workingFilename = "";
        public SendForm()
        {
            InitializeComponent();
            instantiations++;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string stringBytes = "";
            //Get the hex values from the file
            foreach (string s in txtPacket.Lines)
            {
                //# will be a comment. only keep what is in front
                string[] noComments = s.Split('#');
                stringBytes += noComments[0] + Environment.NewLine;
            }

            //extract the hex values into a byte array
            string[] sBytes = stringBytes.Split(new string[] { "\n", "\r\n", " " }, StringSplitOptions.RemoveEmptyEntries);

            //change string to bytes
            byte[] packet = new byte[sBytes.Length];
            int i = 0;
            foreach(string s in sBytes)
            {
                packet[i] = Convert.ToByte(s , 16);
                i++;

                //Sending out the packet
                try
                {
                    PacketCaptureForm.device.SendPacket(packet);
                }
                catch(Exception exp)
                {

                }

            } //End btnSend
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workingFilename != "")
            {
                System.IO.File.WriteAllText(workingFilename, txtPacket.Text);
            }
            else
            {
                saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
                saveFileDialog1.Title = "Save the Captured Packets";
                saveFileDialog1.ShowDialog();

                //check if filename was given
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, txtPacket.Text);
                    workingFilename = saveFileDialog1.FileName;
                }
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save the Captured Packets";
            saveFileDialog1.ShowDialog();

            //check if filename was given
            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtPacket.Text);
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
                txtPacket.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void SendForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            instantiations--;
        }
    }
}
