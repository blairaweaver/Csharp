using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPv4_validator
{
    class Handler
    {
        //This class bridges between the form and the convertor. This class also verifies that the input matches what is expected
        private IPv4Validator form;
        public Handler(IPv4Validator form)
        {
            this.form = form;
        }
        
        public void DecimalCoversion(string decString)
        {
            string[] sections = decString.Split('.');
            for(int cnt = 0; cnt < sections.Length; cnt++)
            {
                int decNum;
                bool success = Int32.TryParse(sections[cnt], out decNum);
                
                if(success && decNum < 256)
                {
                    sections[cnt] = NumberConvertor.DecToHex(decNum);
                }
                else
                {
                    string message = string.Format("Value entered isn't a valid IPv4 address. Each group should have a number between 0 and 255. First error at group {0}", cnt + 1);
                    form.ErrorMessage(message, "Error Dectected in Input");
                    return;
                }
            }

            form.UpdateTextbox(string.Join(".", sections));
        }       
    }
}
