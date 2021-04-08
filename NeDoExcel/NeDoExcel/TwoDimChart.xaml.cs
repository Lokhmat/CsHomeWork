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

namespace NeDoExcel
{
    /// <summary>
    /// Логика взаимодействия для TwoDimChart.xaml
    /// </summary>
    public partial class TwoDimChart : Window
    {
        List<double> valuesX, valuesY;

        public TwoDimChart(List<double> valuesX, List<double> valuesY)
        {
            InitializeComponent();
            this.valuesX = valuesX;
            this.valuesY = valuesY;
        }
        /// <summary>
        /// Redrawing graph if size changed.
        /// </summary>
        private void RedrawGraph(object sender, SizeChangedEventArgs e)
        {
            canvas.Children.Clear();
            Line xAxis = new Line()
            {
                X1 = 10,
                Y1 = Height - 50,
                X2 = Width - 50,
                Y2 = Height - 50,
                Stroke = Brushes.Black
            };
            Line yAxis = new Line()
            {
                X1 = Width / 2,
                Y1 = Height,
                X2 = Width / 2,
                Y2 = 20,
                Stroke = Brushes.Black
            };
            canvas.Children.Add(xAxis);
            canvas.Children.Add(yAxis);
            SortedDictionary<double, double> dict = new SortedDictionary<double, double>(valuesX.Zip(valuesY, (x, y) => new { x, y }).ToDictionary(x => x.x, y => y.y));

            for (int i = 0; i < Math.Min(valuesX.Count, valuesY.Count) - 1; i++)
            {
                canvas.Children.Add(new Line
                {
                    X1 = Width / 2 + dict.Keys.ToList()[i],
                    Y1 = Height - 50 - dict[dict.Keys.ToList()[i]],
                    X2 = Width / 2 + dict.Keys.ToList()[i + 1],
                    Y2 = Height - 50 - dict[dict.Keys.ToList()[i + 1]],
                    StrokeThickness = 1.5,
                    Stroke = Brushes.Black
                });
            }
        }
    }
}
