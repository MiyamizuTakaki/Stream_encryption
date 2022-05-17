using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stream_encryption
{
    /// <summary>
    /// AnalyseList.xaml 的交互逻辑
    /// </summary>
    public partial class AnalyseList : Window
    {
        private Dictionary<Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>, List<string>> all2 = new Dictionary<Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>, List<string>>();
        public AnalyseList(Dictionary<Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>, List<string>> all2)
        {

            this.all2 = all2;
            InitializeComponent();
            List<string> keychain = new List<string>();
            ICollection al2 = all2.Values;
            foreach (List<string> key in al2)
                keychain = key;
            ICollection al3 = all2.Keys;
            Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>> alltext1 = new Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>>();
            foreach (Dictionary<Dictionary<List<char>, List<int>>, Dictionary<List<char>, List<int>>> key in al3)
                alltext1 = key;
            Dictionary<List<char>, List<int>> oritext =new Dictionary<List<char>, List<int>>();
            Dictionary<List<char>, List<int>> encytxt = new Dictionary<List<char>, List<int>>();    
            ICollection al4 = alltext1.Keys;
            ICollection al5 = alltext1.Values;
            foreach(Dictionary<List<char>, List<int>> ori in al4)
                oritext = ori;
            foreach (Dictionary<List<char>, List<int>> ecy in al5)
                encytxt = ecy;
            List<char> oritxti = new List<char>();
            List<int> oritxtas = new List<int>();
            List<char> encys = new List<char>();
            List<int> encyasc = new List<int>();
            foreach (List<char> txtx in oritext.Keys)
                oritxti = txtx;
            foreach (List<int> txtx in oritext.Values)
                oritxtas = txtx;
            foreach (List<char> txtx in encytxt.Keys)
                encys = txtx;
            foreach (List<int> txtx in encytxt.Values)
                encyasc = txtx;

            string str = "Оригинальный текст" + "ASCII CODE" + "расшифровывать" + "ASCII CODE" + "ключ\n";
            for(int i=0;i<oritxti.Count;i++)
            {
                str += oritxti[i]+" = " + oritxtas[i] + "         " + encys[i] + " = " + encyasc[i] + "        " + keychain[i]+"\n";
            }
            textBox.Text = str;
        }

    }
}
