using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPv4_validator
{
    static class NumberConvertor
    {
        
        public static string DecToHex(int decNum)
        {
            string hexNum = "";
            if(decNum == 0)
            {
                hexNum = "0";
            }
            while (decNum > 0)
            {
                string temp = (decNum % 16).ToString();
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
                decNum /= 16;
                hexNum = hexNum.Insert(0, temp);
            }
            return hexNum;
        }
    }
}
