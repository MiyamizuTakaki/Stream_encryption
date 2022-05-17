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
        private List<char> gettxt = new List<char>();
        private List<int> gettxt2 = new List<int>();
        private List<char> sendtxt = new List<char>();
        private List<int> sendtxt2 = new List<int>();
        private List<string> bincode = new List<string>();
        private Dictionary<List<char>, List<int>> gettxt3= new Dictionary<List<char>, List<int>>();
        private Dictionary<List<char>, List<int>> sendtxt3 = new Dictionary<List<char>, List<int>>();
        private Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>> all1 = new Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>();
        private Dictionary<Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>, List<string>> all2 = new Dictionary<Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>, List<string>>();

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
                gettxt.Add(getori[j]);
                gettxt2.Add(Convert.ToInt32(getori[j]));
                string key = "";
                for (int i = 0; i < Key_long; i++)
                    key += Second_array[i];
                bincode.Add(key);
                GetNewKey();
                c++;
                char prosend = Convert.ToChar(Convert.ToByte(getori[j]) ^ BinToByte(key));
                sendtxt.Add(prosend);
                sendtxt2.Add(Convert.ToInt32(prosend));
                resulttext += prosend;
            }
            gettxt3.Add(gettxt, gettxt2);
            sendtxt3.Add(sendtxt, sendtxt2);
            all1.Add(gettxt3, sendtxt3);
            all2.Add(all1, bincode);
            return resulttext;
        }
        public Dictionary<Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>, List<string>> get_key_list()
        {
            return all2;
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
