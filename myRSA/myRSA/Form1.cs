using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace myRSA
{
    public partial class Form1 : Form
    {
        String publicKey, privateKey; //strings to hold the keys
        UnicodeEncoding encoder = new UnicodeEncoding(); //used to encode the data
        public Form1()
        {
            //does create a public and private key pair
            //can we just have this variable outside
            RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider();
            InitializeComponent();

            privateKey = myRSA.ToXmlString(true);
            publicKey = myRSA.ToXmlString(false);
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            txtCyperText.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPlainText.Clear();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //Why keep making new crypto service provider??
            var myRSA = new RSACryptoServiceProvider();
            myRSA.FromXmlString(privateKey);

            //split the data into an array
            //THERE IS NO CHECK TO MAKE SURE THAT THERE IS DATA!!
            String[] dataArray = txtCyperText.Text.Split(new char[] { ',' });

            //Convert to bytes
            byte[] dataByte = new byte[dataArray.Length];
            for(int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            List<byte[]> byteArrays = new List<byte[]>();
            List<byte> byteSlice = new List<byte>();
            for (int i = 0; i < dataByte.Length; i++)
            {
                //This will go after we have collected 128 bytes
                if (i % 128 == 0 && i != 0)
                {
                    //encrypt the slice and add to list of byte array
                    byteArrays.Add(myRSA.Decrypt(byteSlice.ToArray(), true));

                    //clear the byte slice
                    byteSlice.Clear();
                }

                //add the next byte to the slice
                byteSlice.Add(dataByte[i]);
            }
            //this is to catch the last byte slice
            //encrypt the slice and add to list of byte array
            byteArrays.Add(myRSA.Decrypt(byteSlice.ToArray(), true));


            StringBuilder sb = new StringBuilder();
            foreach (byte[] x in byteArrays)
            {
                sb.Append(encoder.GetString(x));
            }

            //place into text box
            txtPlainText.Text = sb.ToString();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //set up the crypto service provider. Why do we have to set up a new on?
            //Why not have a variable for the class?
            RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider();
            myRSA.FromXmlString(publicKey);

            //Encode the data to a byte array
            byte[] dataToEncrypt = encoder.GetBytes(txtPlainText.Text);

            List<byte[]> byteArrays = new List<byte[]>();
            List<byte> byteSlice = new List<byte>();
            for (int i = 0; i < dataToEncrypt.Length; i ++)
            {
                //This will go after we have collected 128 bytes
                if(i % 86 == 0 && i != 0)
                {
                    //encrypt the slice and add to list of byte array
                    byteArrays.Add(myRSA.Encrypt(byteSlice.ToArray(), true));

                    //clear the byte slice
                    byteSlice.Clear();
                }

                //add the next byte to the slice
                byteSlice.Add(dataToEncrypt[i]);
            }
            //this is to catch the last byte slice
            //encrypt the slice and add to list of byte array
            byteArrays.Add(myRSA.Encrypt(byteSlice.ToArray(), true));

            //create the string to put in the text box
            StringBuilder sb = new StringBuilder();
            foreach(byte x in byteArrays.SelectMany(i => i))
            {
                sb.Append(x);
                sb.Append(",");
            }
            sb.Length--; //remove the last comma

            txtCyperText.Text = sb.ToString();
        }
    }
}
