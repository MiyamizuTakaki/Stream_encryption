using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

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
            textBox.Text = "";
            textBox.IsReadOnly = true;
            textBox2.IsReadOnly = false;
            
            textBox3.IsReadOnly = true;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)//选择解密
        {
            textBox2.Text = "";
            textBox.IsReadOnly = false;
            textBox2.IsReadOnly = true;
            textBox3.IsReadOnly = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)//执行
        {
            bool jiemi = true;
            bool exctue = false;
            if ((bool)radioButton.IsChecked)
                jiemi = false;
            if ((bool)radioButton1.IsChecked)
                jiemi= true;
                
            if (textBox2.Text == "" && jiemi == false)
            {
                MessageBox.Show("Исходные входные данные пусты");
                exctue = false;
            }
            else if(textBox2.Text != ""  && jiemi == false)
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
            
            if(jiemi== false&&exctue==true)
            {
                Execution_manager execution_Manager = new Execution_manager(jiemi, textBox2.Text);
                textBox3.Text=execution_Manager.get_text();
                textBox.Text=execution_Manager.get_keying();
            }
            else if(jiemi == true && exctue == true)
            {
                Execution_manager execution_Manager = new Execution_manager(jiemi, textBox3.Text, textBox.Text);
                textBox2.Text = execution_Manager.get_text();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)//关于本程序
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)//保存为一个文件
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)//打开一个文件
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)//分析数据
        {

        }
    }
}
