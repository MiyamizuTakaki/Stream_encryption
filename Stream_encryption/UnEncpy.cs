using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_encryption
{
    class UnEncpy
    {
        private byte Key_long = 8;
        private int longs = 0;
        private List<int> First_array = new List<int>();
        private List<int> Second_array = new List<int>();
        private List<int> Third_array = new List<int>();
        public string GetText(string getori, string getepy)
        {
            this.longs = getepy.Length;
            this.Key_long = (byte)this.longs;
            string resulttext = "";
            int c = 0;
            for (int i = 0; i < Key_long; i++)
                First_array.Add(Convert.ToInt32(Int32.Parse(Convert.ToString(getepy[i]))));
            for (int i = 0; i < Key_long; i++)
                Second_array.Add(Convert.ToInt32(First_array[i]));
            for (int i = 0; i < Key_long; i++)
                Third_array.Add(1);
            for (int j = 0; j < getori.Length; j++)
            {
                string key = "";
                for (int i = 0; i < Key_long; i++)
                    key += Second_array[i];
                GetNewKey();
                c++;
                resulttext += Convert.ToChar(Convert.ToByte(getori[j]) ^ BinToByte(key));
            }
            return resulttext;
        }
        private void GetNewKey()
        {
            List<int> next = new List<int>();
            int temp = 1;
            for (int i = 0; i < Key_long; i++)
            {
                if (Convert.ToInt16(Third_array[i]) == 1)
                {
                    temp = i;
                    next.Add(Convert.ToInt16(Second_array[i]));
                    break;
                }
            }
            for (int i = temp + 1; i < Key_long; i++)
                if (Convert.ToInt16(Third_array[i]) == 1)
                    next[0] = next[0] ^ Convert.ToInt16(Second_array[i]);

            for (int i = 0; i < Key_long - 1; i++)
                next.Add(Convert.ToInt16(Second_array[i]));
            for (int i = 0; i < Key_long; i++)
                Second_array[i] = next[i];
        }
        private byte BinToByte(string binary)
        {
            byte result = 0, val = 0;
            for (int i = 0; i < this.Key_long; i++)
            {
                if (binary[i] == '0')
                    val = 0;
                else
                    val = 1;
                result += Convert.ToByte(Math.Truncate(val * Math.Exp(Math.Log10(2) * (this.longs - i))));
            }
            return result;
        }
    }
}
