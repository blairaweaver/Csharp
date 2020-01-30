using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Assignment_One
{
    class Handler
    {
        //This class bridges between the form and the convertor. This class also verifies that the input matches what is expected
        //Currently, there is no check to make sure the inputs are not too big
        private NumberConversion form;
        public Handler(NumberConversion form)
        {
            this.form = form;
        }
        public void DecimalCoversion(string decString)
        {
            if(verifyDecimal(decString))
            {
                string binNum = NumberConvertor.DecToBin(decString);
                string hexNum = NumberConvertor.DecToHex(decString);
                form.UpdateTextbox(hexNum, "Hexadecimal");
                form.UpdateTextbox(binNum, "Binary");
            }
            else
            {
                form.ErrorMessage("Number entered isn't a valid Decimal Number. Please only use 0-9.", "Error Dectected in Input");
            }
        }

        public void HexadecimalCoversion(string hexString)
        {
            hexString = hexString.ToUpper();
            if(verifyHexadecimal(hexString))
            {
                string decNum = NumberConvertor.HexToDec(hexString);
                string binNum = NumberConvertor.DecToBin(decNum);
                form.UpdateTextbox(decNum, "Decimal");
                form.UpdateTextbox(binNum, "Binary");
            }
            else
            {
                form.ErrorMessage("Number entered isn't a valid Hexadecimal Number. Please only use 0-9 & A-F.", "Error Dectected in Input");
            }
        }

        public void BinaryCoversion(string binString)
        {
            if(verifyBinary(binString))
            {
                string decNum = NumberConvertor.BinToDec(binString);
                string hexNum = NumberConvertor.DecToHex(decNum);
                form.UpdateTextbox(hexNum, "Hexadecimal");
                form.UpdateTextbox(decNum, "Decimal");
            }
            else
            {
                form.ErrorMessage("Number entered isn't a valid Binary Number. Please only use 0 or 1.", "Error Dectected in Input");
            }
        }

        private Boolean verifyDecimal(string decString)
        {
            foreach(char c in decString)
            {
                if(c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean verifyBinary(string binString)
        {
            foreach (char c in binString)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }
        private Boolean verifyHexadecimal(string hexString)
        {
            foreach (char c in hexString)
            {
                if (c < '0' || c > '9' && c < 'A' || c > 'F')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
