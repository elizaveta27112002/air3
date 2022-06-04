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
using System.Windows.Shapes;
using Airlines3.DataSetAirlinesTableAdapters;

namespace Airlines3
{
    /// <summary>
    /// Логика взаимодействия для Administartor.xaml
    /// </summary>
    public partial class Administartor : Window
    {

        public Administartor()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            Close();
            a.Show();
        }
    }
}
