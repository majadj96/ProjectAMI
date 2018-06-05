﻿using Common;
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
    /// Interaction logic for ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        public ThirdWindow()
        {
            InitializeComponent();
            MeasurementType.ItemsSource = Datas.type;

            DeviceCombo.ItemsSource =Datas.devicesCombo;
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {
            long date = Common.Datas.ConvertToUnixTime(dataPicker.SelectedDate.Value);
            string agregator = DeviceCombo.SelectedItem.ToString();
            string measure = MeasurementType.SelectedValue.ToString();

            long dateEnd = date + 86400;

            L.Content = date;

            List<double> values = new List<double>();
            // List<Tuple<DateTime, double>> lista = new List<Tuple<DateTime, double>>();

            using (var data = new GlobalBaseDBContex())
            {
                var AgregatorBase = from d in data.GlobalBaseData select d;

                foreach (var lb in AgregatorBase)
                {
                    long time = Common.Datas.ConvertToUnixTime(DateTime.Parse(lb.TimeStamp));
                    if (lb.DeviceCode == agregator && time >= date && time <= dateEnd)
                    {
                        switch (measure)
                        {
                            case "Voltage":
                                //Tuple<DateTime, double> tupla = new Tuple<DateTime, double>(DateTime.Parse(lb.TimeStamp), lb.Voltage);
                                //lista.Add(tupla);
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

                foreach (var value in values)
                {
                    sum += value;
                }

                sum /= values.Count;






                const double margin = 10;
                double xmin = margin;
                double xmax = canGraph.Width - margin;
                double ymin = margin;
                double ymax = canGraph.Height - margin;
                const double step = 10;

                // Make the X axis.
                GeometryGroup xaxis_geom = new GeometryGroup();
                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(0, ymax), new Point(canGraph.Width, ymax)));
                for (double x = xmin + step;
                    x <= canGraph.Width - step; x += step)
                {
                    xaxis_geom.Children.Add(new LineGeometry(
                        new Point(x, ymax - margin / 2),
                        new Point(x, ymax + margin / 2)));
                }

                Path xaxis_path = new Path();
                xaxis_path.StrokeThickness = 1;
                xaxis_path.Stroke = Brushes.Black;
                xaxis_path.Data = xaxis_geom;

                canGraph.Children.Add(xaxis_path);

                // Make the Y ayis.
                GeometryGroup yaxis_geom = new GeometryGroup();
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin, 0), new Point(xmin, canGraph.Height)));
                for (double y = step; y <= canGraph.Height - step; y += step)
                {
                    yaxis_geom.Children.Add(new LineGeometry(
                        new Point(xmin - margin / 2, y),
                        new Point(xmin + margin / 2, y)));
                }

                Path yaxis_path = new Path();
                yaxis_path.StrokeThickness = 1;
                yaxis_path.Stroke = Brushes.Black;
                yaxis_path.Data = yaxis_geom;

                canGraph.Children.Add(yaxis_path);

                // Make some data sets.
                Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue };
                Random rand = new Random();

                int last_y = (int)sum;

                PointCollection points = new PointCollection();
                for (double x = xmin; x <= xmax; x += step)
                {

                    points.Add(new Point(x, last_y));
                }

                Polyline polyline = new Polyline();
                polyline.StrokeThickness = 1;
                polyline.Stroke = brushes[0];
                polyline.Points = points;

                canGraph.Children.Add(polyline);
            }
        }
    }
}
