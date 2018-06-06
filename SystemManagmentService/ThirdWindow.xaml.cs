using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemManagmentService
{
    /// <summary>
    /// Interaction logic for ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        public ThirdWindow()
        {
            InitializeComponent();

            DeviceCombo.ItemsSource =Datas.devicesCombo;
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {

            if (!validate())
            {
                MessageBox.Show("Niste popunili sva pollja!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {



                long date = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value);
            string agregator = DeviceCombo.SelectedItem.ToString();

            long dateEnd = date + 86400;


            List<double> napon = new List<double>();
            List<double> struja = new List<double>();

            List<double> aktivna = new List<double>();

            List<double> reaktivna = new List<double>();



                using (var data = new GlobalBaseDBContex())
                {
                    var AgregatorBase = from d in data.GlobalBaseData select d;

                    foreach (var lb in AgregatorBase)
                    {
                        long time = Common.Datas.ConvertToUnixTime(DateTime.Parse(lb.TimeStamp));
                        if (lb.DeviceCode == agregator && time >= date && time <= dateEnd)
                        {
                            struja.Add(lb.Eletricity);
                            napon.Add(lb.Voltage);
                            aktivna.Add(lb.ActivePower);
                            reaktivna.Add(lb.ReactivePower);


                        }
                    }

                    double sum1 = 0;
                    double sum2 = 0;
                    double sum3 = 0;
                    double sum4 = 0;

                    foreach (var value in struja)
                    {
                        sum1 += value;
                    }
                    sum1 /= struja.Count;

                    foreach (var value in napon)
                    {
                        sum2 += value;
                    }
                    sum2 /= napon.Count;

                    foreach (var value in aktivna)
                    {
                        sum3 += value;
                    }
                    sum3 /= aktivna.Count;

                    foreach (var value in reaktivna)
                    {
                        sum4 += value;
                    }
                    sum4 /= reaktivna.Count;

                    List<KeyValuePair<string, double>> lista1 = new List<KeyValuePair<string, double>>();
                    lista1.Add(new KeyValuePair<string, double>("Voltage", sum2));
                    lista1.Add(new KeyValuePair<string, double>("Eletricity", sum1));
                    lista1.Add(new KeyValuePair<string, double>("Active power", sum3));
                    lista1.Add(new KeyValuePair<string, double>("Reactive power", sum4));



                    ((ColumnSeries)mcChart.Series[0]).ItemsSource = lista1;


                }


            }
        }

        private void DeviceCombo_DropDownOpened(object sender, EventArgs e)
        {
            Datas.devicesCombo = Datas.loadDevicesFromDataBase();
            DeviceCombo.ItemsSource = Datas.devicesCombo;


        }



        private bool validate()
        {
            bool result = false;


            if (DeviceCombo.SelectedItem == null)
            {
                DeviceCombo.BorderThickness = new Thickness(3);
                DeviceCombo.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                DeviceCombo.BorderBrush = Brushes.Gray;
                result = true;
            }

            if (dataPicker.SelectedDate == null)
            {
                dataPicker.BorderThickness = new Thickness(3);
                dataPicker.BorderBrush = Brushes.Gray;
                return false;
            }
            else
            {
                dataPicker.BorderBrush = Brushes.Gray;
                result = true;
            }

           
           return result;
        }
    }
}
