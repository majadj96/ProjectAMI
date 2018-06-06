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
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        public FirstWindow()
        {
            InitializeComponent();
            MeasurementType.ItemsSource = Datas.type;

        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {

            if (!validate())
            {
                MessageBox.Show("Niste popunili sva pollja!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else { 

            string device = DeviceCombo.SelectedItem.ToString();

            long date = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value);
            string measure = MeasurementType.SelectedValue.ToString();

            long dateEnd = date + 86400;


            List<KeyValuePair<string, double>> values = new List<KeyValuePair<string, double>>();


                using (var data = new GlobalBaseDBContex())
                {
                    var AgregatorBase = from d in data.GlobalBaseData select d;

                    foreach (var lb in AgregatorBase)
                    {
                        long time = Common.Datas.ConvertToUnixTime(DateTime.Parse(lb.TimeStamp));
                        if (lb.DeviceCode == device && time >= date && time <= dateEnd)
                        {
                            switch (measure)
                            {

                                case "Voltage":
                                    KeyValuePair<string, double> pair = new KeyValuePair<string, double>(DateTime.Parse(lb.DeviceTime).ToString("HH:mm:ss:tt"), lb.Voltage);
                                    values.Add(pair);

                                    break;
                                case "Eletricity":
                                    KeyValuePair<string, double> pair1 = new KeyValuePair<string, double>(DateTime.Parse(lb.DeviceTime).ToString("HH:mm:ss:tt"), lb.Eletricity);
                                    values.Add(pair1);
                                    break;

                                case "Active power":
                                    KeyValuePair<string, double> pair2 = new KeyValuePair<string, double>(DateTime.Parse(lb.DeviceTime).ToString("HH:mm:ss:tt"), lb.ActivePower);
                                    values.Add(pair2);
                                    break;
                                case "Reactive power":
                                    KeyValuePair<string, double> pair3 = new KeyValuePair<string, double>(DateTime.Parse(lb.DeviceTime).ToString("HH:mm:ss:tt"), lb.ReactivePower);
                                    values.Add(pair3);
                                    break;
                            }

                        }
                    }




                    ((ColumnSeries)mcChart.Series[0]).ItemsSource = values;


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

            if (MeasurementType.SelectedValue == null)
            {
                MeasurementType.BorderThickness = new Thickness(3);
                MeasurementType.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                MeasurementType.BorderBrush = Brushes.Gray;
                result = true;
            }

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
