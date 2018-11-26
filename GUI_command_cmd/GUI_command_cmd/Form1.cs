using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI_command_cmd
{

    public partial class Form1 : Form
    {
        private object toolTip1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String command = "/C ipconfig " + comboBox2.Text + " " + textBox1.Text;
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", command);
            // скрываем окно запущенного процесса
            psiOpt.StandardOutputEncoding = Encoding.GetEncoding(866);
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
            // запускаем процесс
            Process procCommand = Process.Start(psiOpt);
            // получаем ответ запущенного процесса
            StreamReader srIncoming = procCommand.StandardOutput;
            // выводим результат
            richTextBox1.Text = srIncoming.ReadToEnd().ToString();
            // закрываем процесс
            procCommand.WaitForExit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            String command = "/C ping " + comboBox1.Text + " " + textBox2.Text;
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", command);
            psiOpt.StandardOutputEncoding = Encoding.GetEncoding(866);
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.RedirectStandardInput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
            Process procCommand = Process.Start(psiOpt);
            StreamReader srIncoming = procCommand.StandardOutput;
            richTextBox1.Text = srIncoming.ReadToEnd().ToString();
            procCommand.WaitForExit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String command = "/C tracert " + textBox3.Text;
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", command);
            psiOpt.StandardOutputEncoding = Encoding.GetEncoding(866);
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
            Process procCommand = Process.Start(psiOpt);
            StreamReader srIncoming = procCommand.StandardOutput;
            richTextBox1.Text = srIncoming.ReadToEnd().ToString();
            procCommand.WaitForExit();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            String command = " " + comboBox4.Text + " " + textBox4.Text;
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"netsh.exe", command);
            psiOpt.StandardOutputEncoding = Encoding.GetEncoding(866);
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
            Process procCommand = Process.Start(psiOpt);
            StreamReader srIncoming = procCommand.StandardOutput;
            richTextBox1.Text = srIncoming.ReadToEnd().ToString();
            procCommand.WaitForExit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (comboBox1.Text)
            {
                case "-a":
                    label9.Text = " Разрешает адреса в имена узлов.";
                    break;
                case "-f":
                    label9.Text = " Устанавливает флаг, запрещающий фрагментацию, в пакете(только IPv4).";
                    break;
                case "-R":
                    label9.Text = " Использует заголовок маршрута для проверки и обратного маршрута(только IPv6). \n В соответствии с RFC 5095, использование этого заголовка маршрута \n  не рекомендуется." +
                        "\n В некоторых системах запросы проверки связи могут быть" +
                        "\n сброшены, если используется этот заголовок. ";
                    break;
                case "-p":
                    label9.Text = " Проверяет связь с сетевым адресом поставщика \n виртуализации Hyper-V.";
                    break;
                case "-4":
                    label9.Text = " Задает принудительное использование протокола IPv4.";
                    break;
                case "-6":
                    label9.Text = " Задает принудительное использование протокола IPv6.";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "/all":
                    label10.Text = " Вывод подробных сведений о конфигурации.";
                    break;
                case "/release":
                    label10.Text = " Освобождение IPv4-адреса для указанного адаптера.";
                    break;
                case "/release6":
                    label10.Text = " Освобождение IPv6-адреса для указанного адаптера.";
                    break;
                case "/renew":
                    label10.Text = " Обновление IPv4-адреса для указанного адаптера.";
                    break;
                case "/renew6":
                    label10.Text = " Обновление IPv6-адреса для указанного адаптера.";
                    break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBox3.Text)
            {
                case "-d":
                    label11.Text = "Без разрешения в имена узлов.";
                    break;
                case "-R":
                    label11.Text = " Трассировка пути (только IPv6).";
                    break;
                case "-4":
                    label11.Text = " Принудительное использование IPv4.";
                    break;
                case "-6":
                    label11.Text = " Принудительное использование IPv6.";
                    break;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.Text)
            {
                case "show alias":
                    label12.Text = " Вывод списка всех определенных псевдонимов.";
                    break;
                case "show helper":
                    label12.Text = " Перечисление всех модулей поддержки верхнего уровня.";
                    break;
            }

        }
    }
}
