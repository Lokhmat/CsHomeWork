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

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Логика взаимодействия для Configure.xaml
    /// </summary>
    public partial class Configure : Window
    {
        public Customer Cust { get; set; }
        public Configure()
        {
            InitializeComponent();
        }
        public Configure(Customer cust)
        {
            InitializeComponent();
            Cust = cust;
            Setup();
        }
        /// <summary>
        /// Setting previous values.
        /// </summary>
        public void Setup()
        {
            FIO.Text = Cust.Name ?? "";
            Adress.Text = Cust.Adress ?? "";
            Phone.Text = Cust.Phone ?? "";
        }
        /// <summary>
        /// Save changes/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Cust.Name = FIO.Text;
            Cust.Adress = Adress.Text;
            Cust.Phone = Phone.Text;
            Close();
        }
    }
}
