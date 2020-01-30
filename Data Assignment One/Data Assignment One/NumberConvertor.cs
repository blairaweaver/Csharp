using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Assignment_One
{
    static class NumberConvertor
    {
        //Instead of having six methods for converting, will only convert to and from Decimal. This brings the number of methods to 4
        public static string BinToDec(string binNum)
        {
            string decNum = "";
            int sum = 0;
            int adjlength = binNum.Length - 1;
            for(int cnt = 0; cnt < binNum.Length; cnt++)
            {
                if(binNum[cnt] == '1')
                {
                    sum += (int) Math.Pow(2, adjlength - cnt);
                }
            }
            decNum = sum.ToString();
            return decNum;
        }
        
        public static string DecToBin(string decNum)
        {
            string binNum = "";
            int dec = Int32.Parse(decNum);
            if (dec == 0)
            {
                binNum = "0";
            }
            while(dec > 0)
            {
                string temp = (dec % 2).ToString();
                dec /= 2;
                binNum = binNum.Insert(0, temp);
            }

            return binNum;
        }
        
        public static string HexToDec(string hexNum)
        {
            int sum = 0;
            string decNum = "";
            int adjLength = hexNum.Length - 1;
            for(int cnt = 0; cnt < hexNum.Length; cnt++)
            {
                switch (hexNum[cnt])
                {
                    case 'A':
                        sum += 10 * (int)Math.Pow(16, adjLength - cnt);
                        break;
                    case 'B':
                        sum += 11 * (int)Math.Pow(16, adjLength - cnt);
                        break;
                    case 'C':
                        sum += 12 * (int)Math.Pow(16, adjLength - cnt);
                        break;
                    case 'D':
                        sum += 13 * (int)Math.Pow(16, adjLength - cnt);
                        break;
                    case 'E':
                        sum += 14 * (int)Math.Pow(16, adjLength - cnt);
                        break;
                    case 'F':
                        sum += 15 * (int)Math.Pow(16, adjLength - cnt);
                        break;
                    default:
                        sum += Int32.Parse(hexNum.Substring(cnt, 1)) * (int)Math.Pow(16, adjLength - cnt);
                        break;
                }
            }
            decNum = sum.ToString();
            return decNum;
        }
        
        public static string DecToHex(string decNum)
        {
            string hexNum = "";
            int dec = Int32.Parse(decNum);
            if (dec == 0)
            {
                hexNum = "0";
            }
            while (dec > 0)
            {
                string temp = (dec % 16).ToString();
                switch (temp)
                {
                    case "10":
                        temp = "A";
                        break;
                    case "11":
                        temp = "B";
                        break;
                    case "12":
                        temp = "C";
                        break;
                    case "13":
                        temp = "D";
                        break;
                    case "14":
                        temp = "E";
                        break;
                    case "15":
                        temp = "F";
                        break;
                    default:                        
                        break;
                }
                dec /= 16;
                hexNum = hexNum.Insert(0, temp);
            }
            return hexNum;
        }
    }
}
