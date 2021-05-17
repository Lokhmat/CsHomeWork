using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Store Shop { get; private set; }
        public static Worker Worker { get; set; }
        public static Customer Customer { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeShop();
        }
        /// <summary>
        /// Initializing shop.
        /// </summary>
        private void InitializeShop()
        {
            Closing += MainWindow_Closing;
            Shop = new Store(new List<Customer>(), new List<Order>(), new List<Worker>(), 0);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("shop.bin", FileMode.Open))
                {
                    fs.Position = 0;
                    Shop = (Store)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            IsEnabled = false;
            RegPage regPage = new RegPage();
            regPage.Closed += RegPage_Closed;
            regPage.Show();
            regPage.Topmost = true;
            // Here you can insert dummy product creation like: Shop.Products.Add(new Product("a", 3)).
            // But don't forget to remove them(after one run) cause they will doublesave otherwise
            foreach (var product in Shop.Products)
            {
                Products.Items.Add(product);
            }
        }
        /// <summary>
        /// Event handler for reg page so we could know user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegPage_Closed(object sender, EventArgs e)
        {
            IsEnabled = true;
            if (Customer == null)
            {
                BuildForWorker();
                return;
            }
            Login.Content = Customer.Login;
            foreach (Order order in Shop.Orders.Where(x => x.Cust == Customer))
            {
                Orders.Items.Add(order);
            }
        }
        /// <summary>
        /// Change window to worker type.
        /// </summary>
        private void BuildForWorker()
        {
            try
            {
                WorkersWindow.Worker = Worker;
                WorkersWindow.Shop = Shop;
                WorkersWindow window = new WorkersWindow();
                window.Show();
                Close();
            }
            catch { }
        }
        /// <summary>
        /// Serializing into file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("shop.bin", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Shop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Reset selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Products.SelectedItem = null;
        }
        /// <summary>
        /// Adding product to cart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Products.SelectedItems.Count != 1 || !int.TryParse(AmountBox.Text, out int amount) || amount <= 0)
            {
                MessageBox.Show("Выберете пожалуйста только один товар и введите правильное количество", "Error");
                return;
            }
            Picker.Items.Add(new Piece((Products.SelectedItem as Product).Name, (Products.SelectedItem as Product).Price * amount, amount));
        }
        /// <summary>
        /// Creating order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (Picker.Items.Count == 0)
                return;
            Order order = new Order(new List<Piece>(), ++Shop.LastOrderId, DateTime.Now, Customer);
            foreach (Piece el in Picker.Items)
            {
                order.OrderedProducts.Add(el);
            }
            Shop.Orders.Add(order);
            Picker.Items.Clear();
            Orders.Items.Add(order);
        }
        /// <summary>
        /// Mark order as payed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(Order order in Orders.Items)
            {
                if ((order.Status & Status.Processed) == Status.Processed)
                {
                    order.Status |= Status.Payed;
                }
                else
                    MessageBox.Show("Оплатить можно только обработанный заказ","Error");
            }
            Orders.Items.Clear();
            foreach (var order in Shop.Orders.Where(x => x.Cust == Customer))
            {
                Orders.Items.Add(order);
            }
        }
        /// <summary>
        /// Open window for user confs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            Configure window = new Configure(Customer);
            this.IsEnabled = false;
            window.Closed += new EventHandler((e,ee) => this.IsEnabled = true);
            
            window.Show();
            window.Setup();
        }
    }
}
