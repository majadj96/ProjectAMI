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
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Voltage: " + lb.Voltage + " " + lb.DeviceTime + "\n";
                                    }

                                }

                                if (opp.Equals("<"))
                                {
                                    if (lb.Voltage < vrednostD)
                                    {
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Voltage: " + lb.Voltage + " " + lb.DeviceTime + "\n";
                                    }
                                }

                                break;
                            case "Eletricity":
                                if (opp.Equals(">"))
                                {
                                    if (lb.Voltage > vrednostD)
                                    {
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Eletricity: " + lb.Eletricity + " " + lb.DeviceTime + "\n";
                                    }

                                }

                                if (opp.Equals("<"))
                                {
                                    if (lb.Voltage < vrednostD)
                                    {
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Eletricity: " + lb.Eletricity + " " + lb.DeviceTime + "\n";
                                    }
                                }
                                break;

                            case "Active power":
                                if (opp.Equals(">"))
                                {
                                    if (lb.Voltage > vrednostD)
                                    {
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Active power: " + lb.ActivePower + " " + lb.DeviceTime + "\n";
                                    }

                                }

                                if (opp.Equals("<"))
                                {
                                    if (lb.Voltage < vrednostD)
                                    {
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Active power: " + lb.ActivePower + " " + lb.DeviceTime + "\n";
                                    }
                                }
                                break;
                            case "Reactive power":
                                if (opp.Equals(">"))
                                {
                                    if (lb.Voltage > vrednostD)
                                    {
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Reactive power: " + lb.ReactivePower + " " + lb.DeviceTime + "\n";
                                    }

                                }

                                if (opp.Equals("<"))
                                {
                                    if (lb.Voltage < vrednostD)
                                    {
                                        Ispis.Text += lb.DeviceCode.ToString() + " " + "Reactive power: " + lb.ReactivePower + " " + lb.DeviceTime + "\n";
                                    }
                                }
                                break;
                        }



                    }
                }



            }
        }
    }
}
