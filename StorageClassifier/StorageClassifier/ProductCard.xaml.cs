using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StorageClassifier
{
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : Window
    {
        public ProductCard()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += checkFields;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            dispatcherTimer.Start();
        }

        public ProductCard(Product product) :this()
        {
            Name.Text = product.Name;
            Code.Text = product.Code;
            Price.Text = product.Price.ToString();
            Left.Text = product.Left.ToString();
        }

        private void checkFields(object sender, EventArgs e)
        {
            if (Name.Text != "" && Code.Text != "" && double.TryParse(Price.Text, out _) && int.TryParse(Left.Text, out _))
                saveButton.IsEnabled = true;
            else
                saveButton.IsEnabled = false;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product()
            {
                Name = Name.Text,
                Code = Code.Text,
                Price = double.Parse(Price.Text),
                Left = int.Parse(Left.Text)
            };
            (Owner as MainWindow).ProductData = product;
            Close();
        }
    }
}
