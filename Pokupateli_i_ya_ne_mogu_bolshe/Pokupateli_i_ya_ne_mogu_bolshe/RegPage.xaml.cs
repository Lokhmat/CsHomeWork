using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pokupateli_i_ya_ne_mogu_bolshe
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Window
    {
        public RegPage()
        {
            InitializeComponent();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(((Admin.IsChecked | Cust.IsChecked) & (Entr.IsChecked | Reg.IsChecked)) | LoginBox.Text == null | PasswordBox.Text == null) ?? true)
            {
                MessageBox.Show("Скорее всего вы что-то не заполнили", "Error");
                return;
            }
            if ((Admin.IsChecked ?? false) && (Entr.IsChecked ?? false) && MainWindow.Shop.Workers.Where(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text).Count() == 1)
            {
                MainWindow.Worker = MainWindow.Shop.Workers.Where(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text).First();
                Close();
            }
            else if ((!Admin.IsChecked ?? false) && (Entr.IsChecked ?? false) && MainWindow.Shop.Customers.Where(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text).Count() == 1)
            {
                MainWindow.Customer = MainWindow.Shop.Customers.Where(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text).First();
                Close();
            }
            else if ((Admin.IsChecked ?? false) && (!Entr.IsChecked ?? false) && MainWindow.Shop.Workers.Where(x => x.Login == LoginBox.Text).Count() == 0)
            {
                Worker worker = new Worker(LoginBox.Text, PasswordBox.Text);
                MainWindow.Worker = worker;
                MainWindow.Shop.Workers.Add(worker);
                Close();
            }
            else if ((!Admin.IsChecked ?? false) && (!Entr.IsChecked ?? false) && MainWindow.Shop.Customers.Where(x => x.Login == LoginBox.Text).Count() == 0)
            {
                Customer customer = new Customer(LoginBox.Text, "", PasswordBox.Text, "", "");
                MainWindow.Customer = customer;
                MainWindow.Shop.Customers.Add(customer);
                Close();
            }
            else
            {
                MessageBox.Show("Не удалось войти, скорее всего такого аккаунта не существует, или логин уже использован", "Error");
            }
        }
    }
}
