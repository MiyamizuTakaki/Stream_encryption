using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Stream_encryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)//选择加密
        {
            button2.IsEnabled = false;
            textBox.Text = "";
            textBox.IsReadOnly = true;
            textBox2.IsReadOnly = false;

            textBox3.IsReadOnly = true;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)//选择解密
        {
            button2.IsEnabled = false;
            textBox2.Text = "";
            textBox.IsReadOnly = false;
            textBox2.IsReadOnly = true;
            textBox3.IsReadOnly = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)//执行
        {
            button2.IsEnabled = false;
            bool jiemi = true;
            bool exctue = false;
            if ((bool)radioButton.IsChecked)
                jiemi = false;
            if ((bool)radioButton1.IsChecked)
                jiemi = true;

            if (textBox2.Text == "" && jiemi == false)
            {
                MessageBox.Show("Исходные входные данные пусты");
                exctue = false;
            }
            else if (textBox2.Text != "" && jiemi == false)
                exctue ^= true;
            if (textBox3.Text == "" && jiemi == true)
            {
                MessageBox.Show("Зашифрованный текст пуст, введите зашифрованный текст");
                exctue = false;
            }
            else if (textBox.Text == "" && jiemi == true)
            {
                MessageBox.Show("Ключ пуст, пожалуйста, заполните ключ");
                exctue = false;
            }
            else if (textBox3.Text != "" && textBox.Text != "" && jiemi == true)
                exctue ^= true;

            if (jiemi == false && exctue == true)
            {
                Execution_manager execution_Manager = new Execution_manager(jiemi, textBox2.Text);
                textBox3.Text = execution_Manager.get_text();
                textBox.Text = execution_Manager.get_keying();
            }
            else if (jiemi == true && exctue == true)
            {
                Execution_manager execution_Manager = new Execution_manager(jiemi, textBox3.Text, textBox.Text);
                textBox2.Text = execution_Manager.get_text();
            }
            button2.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)//关于本程序
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)//保存为一个文件
        {
            bool jiemi = true;
            if ((bool)radioButton.IsChecked)
                jiemi = false;
            if ((bool)radioButton1.IsChecked)
                jiemi = true;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "文件保存";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.Filter = "数据文件|*.dat";
            saveFileDialog.FileName = "savedata.dat";
            if (!(bool)saveFileDialog.ShowDialog())
            {
                MessageBox.Show("你居然不选择文件保存路径");
                return;
            }
            var filename = saveFileDialog.FileName;
            string savedata = "";
            if (jiemi == true)
                savedata = "Miyamizu_Original_Texn\n" + textBox2.Text;
            else if (jiemi == false)
                savedata = "Miyamizu_EncpyText\n" + textBox3.Text;
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(savedata);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)//打开一个文件
        {
            bool jiemi = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "数据文件|*.dat";
            if (!(bool)openFileDialog.ShowDialog())
            {
                MessageBox.Show("你居然不选择文件打开路径");
                return;
            }
            string line = "";
            var filename = openFileDialog.FileName;
            StreamReader sw = new StreamReader(filename);
            bool t1 = false;
            string lines;
            while (( lines = sw.ReadLine()) != null)
            {
                if (lines == "Miyamizu_Original_Text")
                { jiemi = false; t1 = true; continue; }
                else if (lines == "Miyamizu_EncpyText")
                { jiemi = true; t1 = true; continue; }
                else if (t1 == false)
                {
                    MessageBox.Show("请选择由宫水提供的加解密文件");
                    return;
                }
                if (t1 == true)
                    line = lines;
            }
            if (jiemi)
                textBox3.Text = line;
            else
                textBox2.Text = line;
        }

        private void button4_Click(object sender, RoutedEventArgs e)//分析数据
        {

        }
    }
}
