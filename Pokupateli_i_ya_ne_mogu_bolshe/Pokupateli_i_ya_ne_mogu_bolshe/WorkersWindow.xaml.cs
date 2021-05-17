using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Логика взаимодействия для WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        Customer cust;
        public static Store Shop { get; set; }
        public static Worker Worker { get; set; }
        public WorkersWindow()
        {
            InitializeComponent();
            Closing += WorkersWindow_Closing;
            Refresh(Active.IsChecked ?? false);
            ValidateCustomers();
        }
        /// <summary>
        /// Serializing shop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkersWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// Refreshing customers section.
        /// </summary>
        private void ValidateCustomers()
        {
            Customers.Items.Clear();
            foreach (var customer in Shop.Customers)
            {
                Customers.Items.Add(customer);
            }
        }
        /// <summary>
        /// Mark as processed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Processed_Click(object sender, RoutedEventArgs e)
        {
            if (Orders.SelectedItems.Count == 1 && (Orders.SelectedItem as Order).Status == null)
                (Orders.SelectedItem as Order).Status = Status.Processed;
            else
                MessageBox.Show("Выберете один необработанный заказ и нажмите кнопку","Error");
            Refresh(Active.IsChecked ?? false);
        }
        /// <summary>
        /// Refresh orders desk.
        /// </summary>
        /// <param name="done"> Picture only done tasks or not.</param>
        private void Refresh(bool done)
        {
            Orders.Items.Clear();
            if (cust == null)
            {
                foreach (var order in Shop.Orders)
                {
                    if (done && ((order.Status & Status.Done) != Status.Done))
                        Orders.Items.Add(order);
                    else if (!done)
                        Orders.Items.Add(order);
                }
            }
            else
            {
                foreach (var order in Shop.Orders)
                {
                    if (done && ((order.Status & Status.Done) != Status.Done) && order.Cust == cust)
                        Orders.Items.Add(order);
                    else if (!done && order.Cust == cust)
                        Orders.Items.Add(order);
                }
            }
        }
        /// <summary>
        /// Mark as shipped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shipped_Click(object sender, RoutedEventArgs e)
        {
            if (Orders.SelectedItems.Count == 1 && (Orders.SelectedItem as Order).Status != null)
                (Orders.SelectedItem as Order).Status |= Status.Shipped;
            else
                MessageBox.Show("Выберете один неотправленный заказ и нажмите кнопку", "Error");
            Refresh(Active.IsChecked ?? false);
        }
        /// <summary>
        /// Marked as done.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (Orders.SelectedItems.Count == 1 && (Orders.SelectedItem as Order).Status != null)
                (Orders.SelectedItem as Order).Status |= Status.Done;
            else
                MessageBox.Show("Выберете один невыполненный заказ и нажмите кнопку", "Error");
            Refresh(Active.IsChecked ?? false);
        }
        /// <summary>
        /// Refreshing if want to see only acive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Active_Click(object sender, RoutedEventArgs e)
        {
            Refresh(Active.IsChecked ?? false);
        }
        /// <summary>
        /// Refreshing if want to see all orders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAll_Click(object sender, RoutedEventArgs e)
        {
            cust = null;
            Refresh(Active.IsChecked ?? false);
        }
        /// <summary>
        /// Refresh if want to see only one user orders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenOne_Click(object sender, RoutedEventArgs e)
        {
            if (Customers.SelectedItems.Count == 1)
            {
                cust = Customers.SelectedItem as Customer;
                Refresh(Active.IsChecked ?? false);
            }
            else
                MessageBox.Show("Выберете одного покупателя","Error");
            
        }
    }
}
