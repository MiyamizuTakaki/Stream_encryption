using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Stream_encryption
{
    class Execution_manager
    {
        private string get_keyss = "";
        private string text;
        private void create_Keys(int text_lens)
        {
            get_keyss = "";
            int key_byte = 0;
            if (text_lens < 32)
                key_byte = 8;
            else 
                key_byte = 16;
            byte[] keybytes = new byte[5];
            int lehgth = 100;
            int ji = 0;
            int ou = 0;
            string keys = "";
            int longkey = key_byte;
            for (int j = 0; j < longkey; j++)
            {
                for (int i = 0; i < lehgth; i++)
                {
                    RandomNumberGenerator.Create().GetBytes(keybytes);
                    if (BitConverter.ToInt32(keybytes) <= 0)
                        lehgth += 1;
                    else
                    {
                        if (BitConverter.ToInt32(keybytes) % 2 == 0)
                            ou++;
                        else
                            ji++;
                    }
                }
                if (ou > ji)
                    keys += "0";
                else if(ou<ji)
                    keys +="1";
                else
                {
                    longkey++;
                    continue;
                }
                lehgth = 100;
                ji = 0;
                ou = 0;
            }
            get_keyss += keys;
        }
        public Execution_manager(bool encpy,string text,string keys="")
        {
            if (encpy == false)
                create_Keys(text.Length);
            else
                get_keyss += keys;
            this.text = text;
        }
        public string get_text()
        {
            UnEncpy unEncpy = new UnEncpy();
            return unEncpy.GetText(this.text, get_keyss);
        }
        public string get_keying()
        {
            return get_keyss;
        }
    }
}
