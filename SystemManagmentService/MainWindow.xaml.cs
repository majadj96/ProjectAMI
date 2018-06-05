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

namespace SystemManagmentService
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







        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Datas.devicesCombo = Datas.loadDevicesFromDataBase();
            FirstWindow w = new FirstWindow();
            w.ShowDialog();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Datas.agregatorsCombo = Datas.loadAgregatorsFromDataBase();
            SecondWindow w = new SecondWindow();
            w.ShowDialog();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Datas.devicesCombo = Datas.loadDevicesFromDataBase();
            ThirdWindow w = new ThirdWindow();
            w.ShowDialog();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Datas.agregatorsCombo = Datas.loadAgregatorsFromDataBase();
            FourthWindow w = new FourthWindow();
            w.ShowDialog();

        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            Datas.devicesCombo = Datas.loadDevicesFromDataBase();
            FifthWindow w = new FifthWindow();
            w.ShowDialog();
        }
    }
}
