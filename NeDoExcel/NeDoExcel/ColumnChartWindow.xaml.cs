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
    /// Логика взаимодействия для ColumnChartWindow.xaml
    /// </summary>
    public partial class ColumnChartWindow : Window
    {
        Dictionary<string, int> valuePairs;
        public ColumnChartWindow(Dictionary<string, int> valuePairs)
        {
            this.valuePairs = valuePairs;
            InitializeComponent();
            DrawChart();
            
        }
        /// <summary>
        /// Drawing column chart according to valuePairs info.
        /// </summary>
        public void DrawChart()
        {
            grid.Children.Clear();
            valuePairs = MainWindow.ValuePairs;
            for (int i = 0; i < valuePairs.Count * 2 + 1; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < valuePairs.Select(x => x.Value).Max() + 80; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            grid.RowDefinitions.Add(new RowDefinition());
            var max = valuePairs.Select(x => x.Value).Max();
            
            for (int i = 0; i < valuePairs.Count; i++)
            {
                var block = new Rectangle()
                {
                    Stroke = Brushes.LightSteelBlue,
                    Fill = Brushes.LightSteelBlue,
                    Stretch = Stretch.UniformToFill,
                };
                var textBlock = new Label();
                textBlock.Content = $"{valuePairs.Keys.ToList()[i]} - {valuePairs[valuePairs.Keys.ToList()[i]]}";
                textBlock.LayoutTransform = new RotateTransform(180);
                Grid.SetColumn(block, i * 2 + 1);
                Grid.SetRow(block, 0);
                Grid.SetRowSpan(block, valuePairs[valuePairs.Keys.ToList()[i]]);
                Grid.SetColumn(textBlock, i * 2 + 1);
                Grid.SetRow(textBlock, 0);
                Grid.SetRowSpan(textBlock, max);
                grid.Children.Add(block);
                grid.Children.Add(textBlock);
            }
            grid.LayoutTransform = new RotateTransform(180);
        }
    }
}
