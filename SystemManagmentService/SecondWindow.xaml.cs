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

            L.Content = date;

            List<double> values = new List<double>();
            List<Tuple<DateTime, double>> lista = new List<Tuple<DateTime, double>>();

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
                                Tuple<DateTime, double> tupla = new Tuple<DateTime, double>(DateTime.Parse(lb.TimeStamp),lb.Voltage);
                                lista.Add(tupla);
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








                /*
                CGraph.Children.RemoveRange(0, CGraph.Children.Count);
                GrafTab.Visibility = Visibility.Visible;



                if (measure == "Voltage") //napon se ne sabira, nego se srednja vrednost se gleda. Jedina razlike je da ne povecavamo vrednosti na Y osi
                {
                    LMaxValue.Content = "100";
                    LAvgValue.Content = "200";
                    LMinValue.Content = "300";

                    //imamo vreme, i vrednost u tom vremenu
                    List<Tuple<DateTime, double>> retrievedValues = lista;

                    Dictionary<int, double> secondsValues = new Dictionary<int, double>();

                    int seconds = 0;
                    foreach (var tuple in retrievedValues)
                    {
                        seconds = tuple.Item1.Hour * 60 * 60 + tuple.Item1.Minute * 60 + tuple.Item1.Second;

                        //proveravamo da li u recinku postoji vec taj trenutak u danu, ako postoji, dodamo vrednost na njega
                        if (secondsValues.ContainsKey(seconds))
                        {
                            secondsValues[seconds] += tuple.Item2;
                        }
                        else //ako ne postoji, dodamo tu vrednost u tom trneutku u danu
                        {
                            secondsValues.Add(seconds, tuple.Item2);
                        }

                    }

                    for (int i = 0; i < 86400; i++) //ako imamo neki treuntak u danu u kojem nema merenja, dodamo 0 tu
                    {
                        if (!secondsValues.ContainsKey(i))//ako ne postoji merenje za dati sekund, vrednost je 0
                        {
                            secondsValues.Add(i, 0);
                        }
                    }

                    for (int i = 0; i < secondsValues.Count - 1; i++)
                    {
                        Line line = new Line
                        {
                            X1 = 0 + i * 0.552, // koordinate na x osi, od X do X+1 (po sekundama se pomeramo)
                            X2 = 0.552 + i * 0.552,

                            Y1 = 330 - (secondsValues[i] + 1) / lista.Count, //330 je 0, (0,330) --> koordinatni pocetak. +1 je mali cheat, da ne bude 0 vrednost
                            Y2 = 330 - (secondsValues[i + 1] + 1) / lista.Count,

                            Stroke = new SolidColorBrush(Colors.Black)
                        };

                        CGraph.Children.Add(line);
                    }

                }
                */
            }

    



        }
    }
}
