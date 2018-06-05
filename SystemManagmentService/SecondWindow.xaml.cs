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
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            MeasurementType.ItemsSource = Datas.type;

            AgregatorCombo.ItemsSource = Datas.agregatorsCombo;
           
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {

            long date = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value);
            string agregator = AgregatorCombo.SelectedItem.ToString();
            string measure = MeasurementType.SelectedValue.ToString();

            long dateEnd = date + 86400;


            List<double> values = new List<double>();

            using (var data = new GlobalBaseDBContex())
            {
                var AgregatorBase = from d in data.GlobalBaseData select d;

                foreach (var lb in AgregatorBase)
                {
                    long time = Common.Datas.ConvertToUnixTime(DateTime.Parse(lb.TimeStamp));
                    if (lb.AgregatorCode == agregator && time>=date && time<=dateEnd)
                    {
                        switch (measure)
                        {

                            case "Voltage":
                                values.Add(lb.Voltage);

                                break;
                            case "Eletricity":
                                values.Add(lb.Eletricity);
                                break;

                            case "Active power":
                                values.Add(lb.ActivePower);
                                break;
                            case "Reactive power":
                                values.Add(lb.ReactivePower);
                                break;
                        }

                    }
                }

                double sum = 0;

                foreach(var value in values)
                {
                    sum += value;
                }

                if (measure == "Voltage")
                    sum /= values.Count;

                List<KeyValuePair<string, double>> lista1 = new List<KeyValuePair<string, double>>();
                lista1.Add(new KeyValuePair<string, double>(dataPicker.SelectedDate.Value.ToShortDateString(), sum));
                


                ((ColumnSeries)mcChart.Series[0]).ItemsSource = lista1;



               
            }

    



        }
    }
}
