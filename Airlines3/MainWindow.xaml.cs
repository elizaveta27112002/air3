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
using Airlines3.DataSetAirlinesTableAdapters;
using System.Windows.Threading;
namespace Airlines3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSetAirlines dataSetAirlines;
        UsersTableAdapter usersTableAdapter;
        DispatcherTimer timer = new DispatcherTimer();
        Int32 seconds = 0;
        Int32 errorCount = 0;
        String captcha = "";
        

        public MainWindow()
        {
            InitializeComponent();
            dataSetAirlines = new DataSetAirlines();
            usersTableAdapter = new UsersTableAdapter();
            generateCaptcha();
            //Timer.Tick += new EventHandler(timerTick);
            //Timer.Interval = new TimeSpan(0, 0, 1);

        }

        private void generateCaptcha()
        {
            var chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            var random = new Random();
            char[] charsString = new char[8];
            for (int i = 0; i < 8; i++)
            {
                charsString[i] = chars[random.Next(0, chars.Length)];
            }
            captcha = new string(charsString);
            lbl_Captcha.Content = $"Введите капчу: {captcha}";
        }

        private void lookInterface(bool state)
        {
            tb_Captcha.IsEnabled = state;
            pb_Password.IsEnabled = state;
            tb_Captcha.IsEnabled = state;
        }

        private void error()
        {
            errorCount++;
            if(errorCount>3)
            {
                lookInterface(false);
                errorCount = 0;
                timer.Start();
                generateCaptcha();
                MessageBox.Show("вы превысили кол-во попыток. подождите 10 сек");
            }
        }

        private void timerTick(object sender, RoutedEventArgs e)
        {
            seconds++;
            if(seconds>9)
            {
                seconds = 0;
                timer.Stop();
                lookInterface(true);             
            }
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if(tb_login.Text != "" && pb_Password.Password != "")
            {
                if(tb_Captcha.Text == captcha)
                {
                    int? id_user = usersTableAdapter.Login(tb_login.Text, pb_Password.Password);
                    if(id_user != null)
                    {
                        if(1 == usersTableAdapter.Role(tb_login.Text, pb_Password.Password))
                        {
                            Administartor b = new Administartor();
                            Close();
                            b.Show();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        error();
                        errors.Text = "Логин или пароль неверный";
                        tb_login.Clear();
                        pb_Password.Clear();
                    }
                }
                else
                {
                    error();
                    generateCaptcha();
                    errors.Text = "вы неверно ввели капчу";
                    tb_login.Clear();
                    pb_Password.Clear();
                    tb_Captcha.Clear();
                }
            }
            else
            {
                errors.Text = "Введите логин и или пароль";
                error();
                generateCaptcha();
            }
        }
    }
}
