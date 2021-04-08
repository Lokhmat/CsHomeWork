using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CsvHelper;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Globalization;
using System.Data;
using System.Windows.Controls.Primitives;

namespace NeDoExcel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt;
        public static Dictionary<string, int> ValuePairs { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Opens csv and loads it in datagrid.
        /// </summary>
        private void OpenCSV(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { Filter = "CSV files | *.csv" };
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    List<string> headerRow;
                    using (var reader = new StreamReader(dialog.FileName))
                    using (var csv = new CsvReader(reader, new CultureInfo("us-US")))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        headerRow = csv.HeaderRecord.ToList();
                        TableWithHeader(ref headerRow);
                        while (csv.Read())
                        {
                            var dataRow = Enumerable.ToList(csv.GetRecord<dynamic>());
                            var row = dt.NewRow();
                            for (int i = 0; i < dataRow.Count; i++)
                            {
                                if (((KeyValuePair<string, object>)dataRow[i]).Key == "")
                                {
                                    row[$"{i + 1}-ая пустая строка"] = ((KeyValuePair<string, object>)dataRow[i]).Value;
                                    continue;
                                }
                                row[((KeyValuePair<string, object>)dataRow[i]).Key.Replace('/', '\\')] = ((KeyValuePair<string, object>)dataRow[i]).Value;
                            }
                            dt.Rows.Add(row);
                            tableGrid.AutoGenerateColumns = true;
                            tableGrid.DataContext = dt.DefaultView;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка:{Environment.NewLine}{ex.Message}", "Ошибка");
                }
            }
        }
        /// <summary>
        /// Initialize DataGrid with headers.
        /// </summary>
        /// <param name="headerRow"> List of headers.</param>
        private void TableWithHeader(ref List<string> headerRow)
        {
            DataTable dt = new DataTable();
            headerRow = headerRow.Select(x => x.Replace('/', '\\')).ToList();
            for (int i = 0; i < headerRow.Count; i++)
            {
                if (headerRow[i] == "")
                    headerRow[i] = $"{i + 1}-ая пустая строка";
            }
            headerRow.ForEach(x => dt.Columns.Add(new DataColumn(x) { AllowDBNull = true }));
            this.dt = dt;
        }
        /// <summary>
        /// Handler of creating a XY plot.
        /// </summary>
        private void XYButton_Click(object sender, RoutedEventArgs e)
        {
            if (dt == null)
            {
                MessageBox.Show("Таблица не загружена", "Ошибка");
                return;
            }
            if (!int.TryParse(xId.Text, out int xid) || dt.Columns.Count < xid || xid <= 0 || !int.TryParse(yId.Text, out int yid) || dt.Columns.Count < yid || yid <= 0)
            {
                MessageBox.Show("Не существует такого столбца(индексация с единицы) \nВведите номера столбцов в поля \" - X\" и \" - Y\"", "Ошибка");
                return;
            }
            List<double> valuesX = new List<double>();
            List<double> valuesY = new List<double>();
            foreach (DataRow el in dt.Rows)
            {
                if (!double.TryParse(el.ItemArray[xid - 1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double xtemp) || !double.TryParse(el.ItemArray[yid - 1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double ytemp))
                {
                    MessageBox.Show("В стобце не только числовые значения", "Ошибка");
                    return;
                }
                valuesX.Add(xtemp);
                valuesY.Add(ytemp);
            }
            if(valuesX.ToHashSet().Count() != valuesX.Count)
            {
                MessageBox.Show("В стобце значений X стоят не уникальные значения, функции не получится", "Ошибка");
                return;
            }
            TwoDimChart twoDimChart = new TwoDimChart(valuesX, valuesY);
            twoDimChart.Show();
        }
        /// <summary>
        /// Handler of counting stats of column.
        /// </summary>
        private void CountButton_Click(object sender, RoutedEventArgs e)
        {

            if (dt == null)
            {
                MessageBox.Show("Таблица не загружена", "Ошибка");
                return;
            }
            if (!int.TryParse(colId.Text, out int id) || dt.Columns.Count < id || id <= 0)
            {
                MessageBox.Show("Не существует такого столбца(индексация с единицы) \nВведите номер столбца в поле номер столбца", "Ошибка");
                return;
            }
            List<double> values = new List<double>();
            foreach (DataRow el in dt.Rows)
            {
                if (!double.TryParse(el.ItemArray[id - 1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double temp))
                {
                    MessageBox.Show("В стобце не только числовые значения", "Ошибка");
                    return;
                }
                values.Add(temp);
            }

            midLabel.Content = $"Среднее - {values.Average()}";
            avSqLabel.Content = $"Среднекв. откл. - {Math.Sqrt(values.Select(x => (x - values.Average()) * (x - values.Average())).Sum() / values.Count)}";
            dispLabel.Content = $"Дисперсия - {values.Select(x => (x - values.Average()) * (x - values.Average())).Sum() / (values.Count - 1)}";
            values.Sort();
            medLabel.Content = $"Медиана - {values[values.Count / 2]}";
        }
        /// <summary>
        /// Handler of creation of gistogram.
        /// </summary>
        private void GistButton_Click(object sender, RoutedEventArgs e)
        {
            if (dt == null)
            {
                MessageBox.Show("Таблица не загружена", "Ошибка");
                return;
            }
            if (!int.TryParse(colId.Text, out int id) || dt.Columns.Count < id || id <= 0)
            {
                MessageBox.Show("Не существует такого столбца(индексация с единицы)", "Ошибка");
                return;
            }
            List<string> values = new List<string>();
            foreach (DataRow el in dt.Rows)
                values.Add(el.ItemArray[id - 1].ToString());

            var dict = values.GroupBy(x => x);
            ValuePairs = new Dictionary<string, int>();
            foreach (var el in dict)
            {
                ValuePairs.Add(el.Key, el.Count());
            }
            ColumnChartWindow columnChart = new ColumnChartWindow(ValuePairs);
            columnChart.Show();
        }
        /// <summary>
        /// Shows FAQ to user.
        /// </summary>
        private void FAQButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Что же вот моя первая поделка на wpf\n" +
                "В этой программе не реализовано доп. пунктов из тз.\n" +
                "Я старался, но время было не на моей стороне.\n" +
                "Чтобы посчитать средние и чтобы построить гистограмму следует вписывать номер столбца в одну и ту же графу - номер столбца.\n" +
                "Тут изспользован CSVHelper, но раз вы это читаете, значит смогли запустить.", "Инфо");
        }
    }
}
