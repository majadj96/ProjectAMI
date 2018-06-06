using Common;
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

namespace SystemManagmentService
{
    /// <summary>
    /// Interaction logic for FifthWindow.xaml
    /// </summary>
    public partial class FifthWindow : Window
    {
        public FifthWindow()
        {
            InitializeComponent();

            MeasurementType.ItemsSource = Datas.type;
            Operator.ItemsSource = Datas.operators;
            DeviceCombo.ItemsSource = Datas.devicesCombo;
            Ispis.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (!validate())
            {
                MessageBox.Show("Niste popunili sva pollja!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                Ispis.Text = "!!!ALARM STATES!!!\n\n";

                long dateStart = Common.Datas.ConvertToUnixTime(datePickerStart.SelectedDate.Value);
                long dateEnd = Common.Datas.ConvertToUnixTime(datePickerEnd.SelectedDate.Value);
                string measure = MeasurementType.SelectedValue.ToString();
                string device = DeviceCombo.SelectedItem.ToString();

                string vrednost = Value.Text;
                double vrednostD = double.Parse(vrednost);


                string opp = Operator.SelectedItem.ToString();

                using (var data = new GlobalBaseDBContex())
                {
                    var AgregatorBase = from d in data.GlobalBaseData select d;

                    foreach (var lb in AgregatorBase)
                    {
                        long time = Common.Datas.ConvertToUnixTime(DateTime.Parse(lb.DeviceTime));

                        if (lb.DeviceCode == device && time >= dateStart && time <= dateEnd)
                        {
                            switch (measure)
                            {

                                case "Voltage":
                                    if (opp.Equals(">"))
                                    {
                                        if (lb.Voltage > vrednostD)
                                        {
                                            Ispis.Text += "Voltage: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }

                                    }

                                    if (opp.Equals("<"))
                                    {
                                        if (lb.Voltage < vrednostD)
                                        {
                                            Ispis.Text += "Voltage: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }
                                    }

                                    break;
                                case "Eletricity":
                                    if (opp.Equals(">"))
                                    {
                                        if (lb.Voltage > vrednostD)
                                        {
                                            Ispis.Text += "Eletricity: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }

                                    }

                                    if (opp.Equals("<"))
                                    {
                                        if (lb.Voltage < vrednostD)
                                        {
                                            Ispis.Text += "Eletricity: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }
                                    }
                                    break;

                                case "Active power":
                                    if (opp.Equals(">"))
                                    {
                                        if (lb.Voltage > vrednostD)
                                        {
                                            Ispis.Text += "Active power: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }

                                    }

                                    if (opp.Equals("<"))
                                    {
                                        if (lb.Voltage < vrednostD)
                                        {
                                            Ispis.Text += "Active power: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }
                                    }
                                    break;
                                case "Reactive power":
                                    if (opp.Equals(">"))
                                    {
                                        if (lb.Voltage > vrednostD)
                                        {
                                            Ispis.Text += "Reactive power: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }

                                    }

                                    if (opp.Equals("<"))
                                    {
                                        if (lb.Voltage < vrednostD)
                                        {
                                            Ispis.Text += "Reactive power: " + lb.Voltage + " " + " at time: " + lb.DeviceTime + "\n";
                                        }
                                    }
                                    break;
                            }



                        }
                    }



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

            if (DeviceCombo.SelectedValue == null)
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


            if (Value.Text.Trim().Equals(""))
            {
                Value.BorderBrush = Brushes.Gray;
                return false;
            }
            else
            {
                try
                {
                    double broj = double.Parse(Value.Text.Trim());


                    if (broj < 0)
                    {
                        return false;
                    }
                    else
                    {
                        result = true;
                    }

                }
                catch (Exception e)
                {
                    Value.BorderBrush = Brushes.Gray;

                    return false;
                }
            }



            if (Operator.SelectedValue == null)
            {
                Operator.BorderThickness = new Thickness(3);
                Operator.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                Operator.BorderBrush = Brushes.Gray;
                result = true;
            }


            if (datePickerStart.SelectedDate == null)
            {
                datePickerStart.BorderThickness = new Thickness(3);
                datePickerStart.BorderBrush = Brushes.Gray;
                return false;
            }
            else
            {
                datePickerStart.BorderBrush = Brushes.Gray;
                result = true;
            }

            if (datePickerEnd.SelectedDate == null)
            {
                datePickerEnd.BorderThickness = new Thickness(3);
                datePickerEnd.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                datePickerEnd.BorderBrush = Brushes.Gray;
                result = true;
            }
           



          


           

            return result;
        }


    }
}
