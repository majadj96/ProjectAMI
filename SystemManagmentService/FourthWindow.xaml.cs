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
    /// Interaction logic for FourthWindow.xaml
    /// </summary>
    public partial class FourthWindow : Window
    {
        public FourthWindow()
        {
            InitializeComponent();
            MeasurementType.ItemsSource = Datas.type;

            AgregatorCombo.ItemsSource = Datas.agregatorsCombo;
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {


            if (!validate())
            {
                MessageBox.Show("There are empty/invalid filds!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                string agregator = AgregatorCombo.SelectedItem.ToString();
                string measure = MeasurementType.SelectedValue.ToString();

                // 00:00 AM -- 23:00 AM
                long date = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value);
                long date1 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(1));
                long date2 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(2));
                long date3 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(3));
                long date4 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(4));
                long date5 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(5));
                long date6 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(6));
                long date7 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(7));
                long date8 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(8));
                long date9 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(9));
                long date10 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(10));
                long date11 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(11));
                long date12 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(12));
                long date13 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(13));
                long date14 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(14));
                long date15 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(15));
                long date16 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(16));
                long date17 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(17));
                long date18 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(18));
                long date19 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(19));
                long date20 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(20));
                long date21 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(21));
                long date22 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(22));
                long date23 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(23));
                long date24 = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value.AddHours(24));

                List<double> l1 = new List<double>();
                List<double> l2 = new List<double>();
                List<double> l3 = new List<double>();
                List<double> l4 = new List<double>();
                List<double> l5 = new List<double>();
                List<double> l6 = new List<double>();
                List<double> l7 = new List<double>();
                List<double> l8 = new List<double>();
                List<double> l9 = new List<double>();
                List<double> l10 = new List<double>();
                List<double> l11 = new List<double>();
                List<double> l12 = new List<double>();
                List<double> l13 = new List<double>();
                List<double> l14 = new List<double>();
                List<double> l15 = new List<double>();
                List<double> l16 = new List<double>();
                List<double> l17 = new List<double>();
                List<double> l18 = new List<double>();
                List<double> l19 = new List<double>();
                List<double> l20 = new List<double>();
                List<double> l21 = new List<double>();
                List<double> l22 = new List<double>();
                List<double> l23 = new List<double>();
                List<double> l24 = new List<double>();


                long dateEnd = date + 86400;


                List<double> values = new List<double>();

                using (var data = new GlobalBaseDBContex())
                {
                    var AgregatorBase = from d in data.GlobalBaseData select d;

                    foreach (var lb in AgregatorBase)
                    {
                        long time = Common.Datas.ConvertToUnixTime(DateTime.Parse(lb.TimeStamp));
                        if (lb.AgregatorCode == agregator && time >= date && time <= dateEnd)
                        {
                            switch (measure)
                            {

                                case "Voltage":
                                    if (time >= date && time < date1)//vreme od 00:01
                                    {
                                        l1.Add(lb.Voltage);
                                    }
                                    if (time >= date1 && time < date2)//vreme od 01:02
                                    {
                                        l2.Add(lb.Voltage);
                                    }
                                    if (time >= date2 && time < date3)//vreme od 00:01
                                    {
                                        l3.Add(lb.Voltage);
                                    }
                                    if (time >= date3 && time < date4)//vreme od 00:01
                                    {
                                        l4.Add(lb.Voltage);
                                    }
                                    if (time >= date4 && time < date5)//vreme od 00:01
                                    {
                                        l5.Add(lb.Voltage);
                                    }
                                    if (time >= date5 && time < date6)//vreme od 00:01
                                    {
                                        l6.Add(lb.Voltage);
                                    }
                                    if (time >= date6 && time < date7)//vreme od 00:01
                                    {
                                        l7.Add(lb.Voltage);
                                    }
                                    if (time >= date7 && time < date8)//vreme od 00:01
                                    {
                                        l8.Add(lb.Voltage);
                                    }
                                    if (time >= date8 && time < date9)//vreme od 00:01
                                    {
                                        l9.Add(lb.Voltage);
                                    }
                                    if (time >= date9 && time < date10)//vreme od 00:01
                                    {
                                        l10.Add(lb.Voltage);
                                    }
                                    if (time >= date10 && time < date11)//vreme od 00:01
                                    {
                                        l11.Add(lb.Voltage);
                                    }
                                    if (time >= date11 && time < date12)//vreme od 00:01
                                    {
                                        l12.Add(lb.Voltage);
                                    }
                                    if (time >= date12 && time < date13)//vreme od 00:01
                                    {
                                        l13.Add(lb.Voltage);
                                    }
                                    if (time >= date13 && time < date14)//vreme od 00:01
                                    {
                                        l14.Add(lb.Voltage);
                                    }
                                    if (time >= date14 && time < date15)//vreme od 00:01
                                    {
                                        l15.Add(lb.Voltage);
                                    }
                                    if (time >= date15 && time < date16)//vreme od 00:01
                                    {
                                        l16.Add(lb.Voltage);
                                    }

                                    if (time >= date16 && time < date17)//vreme od 00:01
                                    {
                                        l17.Add(lb.Voltage);
                                    }

                                    if (time >= date17 && time < date18)//vreme od 00:01
                                    {
                                        l18.Add(lb.Voltage);
                                    }

                                    if (time >= date18 && time < date19)//vreme od 00:01
                                    {
                                        l19.Add(lb.Voltage);
                                    }
                                    if (time >= date19 && time < date20)//vreme od 00:01
                                    {
                                        l20.Add(lb.Voltage);
                                    }
                                    if (time >= date20 && time < date21)//vreme od 00:01
                                    {
                                        l21.Add(lb.Voltage);
                                    }
                                    if (time >= date21 && time < date22)//vreme od 00:01
                                    {
                                        l22.Add(lb.Voltage);
                                    }
                                    if (time >= date22 && time < date23)//vreme od 00:01
                                    {
                                        l23.Add(lb.Voltage);
                                    }
                                    if (time >= date23 && time < date24)//vreme od 00:01
                                    {
                                        l24.Add(lb.Voltage);
                                    }



                                    break;
                                case "Eletricity":
                                    if (time >= date && time < date1)//vreme od 00:01
                                    {
                                        l1.Add(lb.Eletricity);
                                    }
                                    if (time >= date1 && time < date2)//vreme od 01:02
                                    {
                                        l2.Add(lb.Eletricity);
                                    }
                                    if (time >= date2 && time < date3)//vreme od 00:01
                                    {
                                        l3.Add(lb.Eletricity);
                                    }
                                    if (time >= date3 && time < date4)//vreme od 00:01
                                    {
                                        l4.Add(lb.Eletricity);
                                    }
                                    if (time >= date4 && time < date5)//vreme od 00:01
                                    {
                                        l5.Add(lb.Eletricity);
                                    }
                                    if (time >= date5 && time < date6)//vreme od 00:01
                                    {
                                        l6.Add(lb.Eletricity);
                                    }
                                    if (time >= date6 && time < date7)//vreme od 00:01
                                    {
                                        l7.Add(lb.Eletricity);
                                    }
                                    if (time >= date7 && time < date8)//vreme od 00:01
                                    {
                                        l8.Add(lb.Eletricity);
                                    }
                                    if (time >= date8 && time < date9)//vreme od 00:01
                                    {
                                        l9.Add(lb.Eletricity);
                                    }
                                    if (time >= date9 && time < date10)//vreme od 00:01
                                    {
                                        l10.Add(lb.Eletricity);
                                    }
                                    if (time >= date10 && time < date11)//vreme od 00:01
                                    {
                                        l11.Add(lb.Eletricity);
                                    }
                                    if (time >= date11 && time < date12)//vreme od 00:01
                                    {
                                        l12.Add(lb.Eletricity);
                                    }
                                    if (time >= date12 && time < date13)//vreme od 00:01
                                    {
                                        l13.Add(lb.Eletricity);
                                    }
                                    if (time >= date13 && time < date14)//vreme od 00:01
                                    {
                                        l14.Add(lb.Eletricity);
                                    }
                                    if (time >= date14 && time < date15)//vreme od 00:01
                                    {
                                        l15.Add(lb.Eletricity);
                                    }
                                    if (time >= date15 && time < date16)//vreme od 00:01
                                    {
                                        l16.Add(lb.Eletricity);
                                    }

                                    if (time >= date16 && time < date17)//vreme od 00:01
                                    {
                                        l17.Add(lb.Eletricity);
                                    }

                                    if (time >= date17 && time < date18)//vreme od 00:01
                                    {
                                        l18.Add(lb.Eletricity);
                                    }

                                    if (time >= date18 && time < date19)//vreme od 00:01
                                    {
                                        l19.Add(lb.Eletricity);
                                    }
                                    if (time >= date19 && time < date20)//vreme od 00:01
                                    {
                                        l20.Add(lb.Eletricity);
                                    }
                                    if (time >= date20 && time < date21)//vreme od 00:01
                                    {
                                        l21.Add(lb.Eletricity);
                                    }
                                    if (time >= date21 && time < date22)//vreme od 00:01
                                    {
                                        l22.Add(lb.Eletricity);
                                    }
                                    if (time >= date22 && time < date23)//vreme od 00:01
                                    {
                                        l23.Add(lb.Eletricity);
                                    }
                                    if (time >= date23 && time < date24)//vreme od 00:01
                                    {
                                        l24.Add(lb.Eletricity);
                                    }

                                    break;

                                case "Active power":
                                    if (time >= date && time < date1)//vreme od 00:01
                                    {
                                        l1.Add(lb.ActivePower);
                                    }
                                    if (time >= date1 && time < date2)//vreme od 01:02
                                    {
                                        l2.Add(lb.ActivePower);
                                    }
                                    if (time >= date2 && time < date3)//vreme od 00:01
                                    {
                                        l3.Add(lb.ActivePower);
                                    }
                                    if (time >= date3 && time < date4)//vreme od 00:01
                                    {
                                        l4.Add(lb.ActivePower);
                                    }
                                    if (time >= date4 && time < date5)//vreme od 00:01
                                    {
                                        l5.Add(lb.ActivePower);
                                    }
                                    if (time >= date5 && time < date6)//vreme od 00:01
                                    {
                                        l6.Add(lb.ActivePower);
                                    }
                                    if (time >= date6 && time < date7)//vreme od 00:01
                                    {
                                        l7.Add(lb.ActivePower);
                                    }
                                    if (time >= date7 && time < date8)//vreme od 00:01
                                    {
                                        l8.Add(lb.ActivePower);
                                    }
                                    if (time >= date8 && time < date9)//vreme od 00:01
                                    {
                                        l9.Add(lb.ActivePower);
                                    }
                                    if (time >= date9 && time < date10)//vreme od 00:01
                                    {
                                        l10.Add(lb.ActivePower);
                                    }
                                    if (time >= date10 && time < date11)//vreme od 00:01
                                    {
                                        l11.Add(lb.ActivePower);
                                    }
                                    if (time >= date11 && time < date12)//vreme od 00:01
                                    {
                                        l12.Add(lb.ActivePower);
                                    }
                                    if (time >= date12 && time < date13)//vreme od 00:01
                                    {
                                        l13.Add(lb.ActivePower);
                                    }
                                    if (time >= date13 && time < date14)//vreme od 00:01
                                    {
                                        l14.Add(lb.ActivePower);
                                    }
                                    if (time >= date14 && time < date15)//vreme od 00:01
                                    {
                                        l15.Add(lb.ActivePower);
                                    }
                                    if (time >= date15 && time < date16)//vreme od 00:01
                                    {
                                        l16.Add(lb.ActivePower);
                                    }

                                    if (time >= date16 && time < date17)//vreme od 00:01
                                    {
                                        l17.Add(lb.ActivePower);
                                    }

                                    if (time >= date17 && time < date18)//vreme od 00:01
                                    {
                                        l18.Add(lb.ActivePower);
                                    }

                                    if (time >= date18 && time < date19)//vreme od 00:01
                                    {
                                        l19.Add(lb.ActivePower);
                                    }
                                    if (time >= date19 && time < date20)//vreme od 00:01
                                    {
                                        l20.Add(lb.ActivePower);
                                    }
                                    if (time >= date20 && time < date21)//vreme od 00:01
                                    {
                                        l21.Add(lb.ActivePower);
                                    }
                                    if (time >= date21 && time < date22)//vreme od 00:01
                                    {
                                        l22.Add(lb.ActivePower);
                                    }
                                    if (time >= date22 && time < date23)//vreme od 00:01
                                    {
                                        l23.Add(lb.ActivePower);
                                    }
                                    if (time >= date23 && time < date24)//vreme od 00:01
                                    {
                                        l24.Add(lb.ActivePower);
                                    }
                                    break;
                                case "Reactive power":
                                    if (time >= date && time < date1)//vreme od 00:01
                                    {
                                        l1.Add(lb.ReactivePower);
                                    }
                                    if (time >= date1 && time < date2)//vreme od 01:02
                                    {
                                        l2.Add(lb.ReactivePower);
                                    }
                                    if (time >= date2 && time < date3)//vreme od 00:01
                                    {
                                        l3.Add(lb.ReactivePower);
                                    }
                                    if (time >= date3 && time < date4)//vreme od 00:01
                                    {
                                        l4.Add(lb.ReactivePower);
                                    }
                                    if (time >= date4 && time < date5)//vreme od 00:01
                                    {
                                        l5.Add(lb.ReactivePower);
                                    }
                                    if (time >= date5 && time < date6)//vreme od 00:01
                                    {
                                        l6.Add(lb.ReactivePower);
                                    }
                                    if (time >= date6 && time < date7)//vreme od 00:01
                                    {
                                        l7.Add(lb.ReactivePower);
                                    }
                                    if (time >= date7 && time < date8)//vreme od 00:01
                                    {
                                        l8.Add(lb.ReactivePower);
                                    }
                                    if (time >= date8 && time < date9)//vreme od 00:01
                                    {
                                        l9.Add(lb.ReactivePower);
                                    }
                                    if (time >= date9 && time < date10)//vreme od 00:01
                                    {
                                        l10.Add(lb.ReactivePower);
                                    }
                                    if (time >= date10 && time < date11)//vreme od 00:01
                                    {
                                        l11.Add(lb.ReactivePower);
                                    }
                                    if (time >= date11 && time < date12)//vreme od 00:01
                                    {
                                        l12.Add(lb.ReactivePower);
                                    }
                                    if (time >= date12 && time < date13)//vreme od 00:01
                                    {
                                        l13.Add(lb.ReactivePower);
                                    }
                                    if (time >= date13 && time < date14)//vreme od 00:01
                                    {
                                        l14.Add(lb.ReactivePower);
                                    }
                                    if (time >= date14 && time < date15)//vreme od 00:01
                                    {
                                        l15.Add(lb.ReactivePower);
                                    }
                                    if (time >= date15 && time < date16)//vreme od 00:01
                                    {
                                        l16.Add(lb.ReactivePower);
                                    }

                                    if (time >= date16 && time < date17)//vreme od 00:01
                                    {
                                        l17.Add(lb.ReactivePower);
                                    }

                                    if (time >= date17 && time < date18)//vreme od 00:01
                                    {
                                        l18.Add(lb.ReactivePower);
                                    }

                                    if (time >= date18 && time < date19)//vreme od 00:01
                                    {
                                        l19.Add(lb.ReactivePower);
                                    }
                                    if (time >= date19 && time < date20)//vreme od 00:01
                                    {
                                        l20.Add(lb.ReactivePower);
                                    }
                                    if (time >= date20 && time < date21)//vreme od 00:01
                                    {
                                        l21.Add(lb.ReactivePower);
                                    }
                                    if (time >= date21 && time < date22)//vreme od 00:01
                                    {
                                        l22.Add(lb.ReactivePower);
                                    }
                                    if (time >= date22 && time < date23)//vreme od 00:01
                                    {
                                        l23.Add(lb.ReactivePower);
                                    }
                                    if (time >= date23 && time < date24)//vreme od 00:01
                                    {
                                        l24.Add(lb.ReactivePower);
                                    }
                                    break;
                            }

                        }
                    }
                }

                double s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24;
                s1 = s2 = s3 = s4 = s5 = s6 = s7 = s8 = s9 = s10 = s11 = s12 = s13 = s14 = s15 = s16 = s17 = s18 = s19 = s20 = s21 = s22 = s23 = s24 = 0;

                foreach (var v in l1)
                    s1 += v;
                if (l1.Count > 0)
                    s1 /= l1.Count;

                foreach (var v in l2)
                    s2 += v;
                if (l2.Count > 0)
                    s2 /= l2.Count;

                foreach (var v in l3)
                    s3 += v;
                if (l3.Count > 0)
                    s3 /= l3.Count;

                foreach (var v in l4)
                    s4 += v;
                if (l4.Count > 0)
                    s4 /= l4.Count;

                foreach (var v in l5)
                    s5 += v;
                if (l5.Count > 0)
                    s5 /= l5.Count;

                foreach (var v in l6)
                    s6 += v;
                if (l6.Count > 0)
                    s6 /= l6.Count;

                foreach (var v in l7)
                    s7 += v;
                if (l7.Count > 0)
                    s7 /= l7.Count;

                foreach (var v in l8)
                    s8 += v;
                if (l8.Count > 0)
                    s8 /= l8.Count;

                foreach (var v in l9)
                    s9 += v;
                if (l9.Count > 0)
                    s9 /= l9.Count;

                foreach (var v in l10)
                    s10 += v;
                if (l10.Count > 0)
                    s10 /= l10.Count;

                foreach (var v in l11)
                    s11 += v;
                if (l11.Count > 0)
                    s11 /= l11.Count;

                foreach (var v in l12)
                    s12 += v;
                if (l12.Count > 0)
                    s12 /= l12.Count;

                foreach (var v in l13)
                    s13 += v;
                if (l13.Count > 0)
                    s13 /= l13.Count;

                foreach (var v in l14)
                    s14 += v;
                if (l14.Count > 0)
                    s14 /= l14.Count;

                foreach (var v in l15)
                    s15 += v;
                if (l15.Count > 0)
                    s15 /= l15.Count;

                foreach (var v in l16)
                    s16 += v;
                if (l16.Count > 0)
                    s16 /= l16.Count;

                foreach (var v in l17)
                    s17 += v;
                if (l17.Count > 0)
                    s17 /= l17.Count;

                foreach (var v in l18)
                    s18 += v;
                if (l18.Count > 0)
                    s18 /= l18.Count;

                foreach (var v in l19)
                    s19 += v;
                if (l19.Count > 0)
                    s19 /= l19.Count;

                foreach (var v in l20)
                    s20 += v;
                if (l20.Count > 0)
                    s20 /= l20.Count;

                foreach (var v in l21)
                    s21 += v;
                if (l21.Count > 0)
                    s21 /= l21.Count;
                foreach (var v in l22)
                    s22 += v;
                if (l22.Count > 0)
                    s22 /= l22.Count;
                foreach (var v in l23)
                    s23 += v;
                if (l23.Count > 0)
                    s23 /= l23.Count;
                foreach (var v in l24)
                    s24 += v;
                if (l24.Count > 0)
                    s24 /= l24.Count;

                List<KeyValuePair<string, double>> lista1 = new List<KeyValuePair<string, double>>();
                lista1.Add(new KeyValuePair<string, double>("", s1));
                lista1.Add(new KeyValuePair<string, double>("1", s2));
                lista1.Add(new KeyValuePair<string, double>("2", s3));
                lista1.Add(new KeyValuePair<string, double>("3", s4));
                lista1.Add(new KeyValuePair<string, double>("4", s5));
                lista1.Add(new KeyValuePair<string, double>("5", s6));
                lista1.Add(new KeyValuePair<string, double>("6", s7));
                lista1.Add(new KeyValuePair<string, double>("7", s8));
                lista1.Add(new KeyValuePair<string, double>("8", s9));
                lista1.Add(new KeyValuePair<string, double>("9", s10));
                lista1.Add(new KeyValuePair<string, double>("10", s11));
                lista1.Add(new KeyValuePair<string, double>("11", s12));
                lista1.Add(new KeyValuePair<string, double>("12", s13));
                lista1.Add(new KeyValuePair<string, double>("13", s14));
                lista1.Add(new KeyValuePair<string, double>("14", s15));
                lista1.Add(new KeyValuePair<string, double>("15", s16));
                lista1.Add(new KeyValuePair<string, double>("16", s17));
                lista1.Add(new KeyValuePair<string, double>("17", s18));
                lista1.Add(new KeyValuePair<string, double>("18", s19));
                lista1.Add(new KeyValuePair<string, double>("19", s20));
                lista1.Add(new KeyValuePair<string, double>("20", s21));
                lista1.Add(new KeyValuePair<string, double>("21", s22));
                lista1.Add(new KeyValuePair<string, double>("22", s23));
                lista1.Add(new KeyValuePair<string, double>("23", s24));




                ((LineSeries)mcChart.Series[0]).ItemsSource = lista1;

            }
            }

        private void AgregatorCombo_DropDownOpened(object sender, EventArgs e)
        {
            Datas.agregatorsCombo = Datas.loadAgregatorsFromDataBase();
            AgregatorCombo.ItemsSource = Datas.agregatorsCombo;

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


            if (AgregatorCombo.SelectedItem == null)
            {
                AgregatorCombo.BorderThickness = new Thickness(3);
                AgregatorCombo.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                AgregatorCombo.BorderBrush = Brushes.Gray;
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
