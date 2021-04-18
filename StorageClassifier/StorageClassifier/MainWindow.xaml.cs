using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace StorageClassifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool changed = false;
        public object ProductData { get; set; }
        string newName;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void addNodeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (treeView.SelectedItem == null || nodeName.Text == null || nodeName.Text == "")
                {
                    MessageBox.Show("Выберете узел куда добавить и напишите название этого узла.", "Ошибка");
                    return;
                }
                var t = (treeView.SelectedItem as TreeViewItem).Items.OfType<TreeViewItem>();
                if (t.Select(x => x.Header).Contains(nodeName.Text))
                {
                    MessageBox.Show("В этом узле уже существует такой под. узел.", "Ошибка");
                    return;
                }
                (treeView.SelectedItem as TreeViewItem).Items.Add(new MyTreeViewItem() { Header = nodeName.Text });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка:\n{ex.Message}", "Ошибка");
            }
        }

        private void addGlobalNodeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nodeName.Text == null || nodeName.Text == "")
                {
                    MessageBox.Show("Напишите название этого узла.", "Ошибка");
                    return;
                }
                var t = treeView.Items.OfType<TreeViewItem>();
                if (t.Select(x => x.Header).Contains(nodeName.Text))
                {
                    MessageBox.Show("В этом узле уже существует такой под. узел.", "Ошибка");
                    return;
                }
                treeView.Items.Add(new MyTreeViewItem() { Header = nodeName.Text });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка:\n{ex.Message}", "Ошибка");
            }
        }

        private void deleteNode_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null && (treeView.SelectedItem as TreeViewItem).Items.Count == 0)
                if ((treeView.SelectedItem as TreeViewItem).Parent is TreeView)
                    treeView.Items.Remove(treeView.SelectedItem);
                else
                    ((treeView.SelectedItem as TreeViewItem).Parent as TreeViewItem).Items.Remove(treeView.SelectedItem);
            else
                MessageBox.Show("Раздел не выбран или не пуст", "Ошибка");
        }

        private void editNode_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem == null)
            {
                MessageBox.Show("Выберите раздел", "Ошибка");
                return;
            }
            Window window = new Window();
            window.Owner = this;
            window.Height = 100;
            window.Width = 200;
            window.Closed += ((sender, e) => IsEnabled = true);
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
            stackPanel.Children.Add(new Label { Content = "Новое название:" });
            var box = new TextBox() { Name = "newName" };
            box.TextChanged += ((sender, e) => { changed = true; newName = box.Text; });
            stackPanel.Children.Add(box);
            var button = new Button { Content = "OK" };
            button.Click += SetNewName;
            button.Click += (sender, e) => window.Close();
            stackPanel.Children.Add(button);
            window.Content = stackPanel;
            window.Show();
            IsEnabled = false;
        }
        private void SetNewName(object sender, RoutedEventArgs e)
        {
            if (changed == true && newName != null && newName != "" && (treeView.SelectedItem as TreeViewItem).Parent is TreeView)
            {
                var t = treeView.Items.OfType<TreeViewItem>();
                if (t.Select(x => x.Header).Contains(newName))
                {
                    MessageBox.Show("Узел с таким названием уже существует.", "Ошибка");
                    return;
                }
                (treeView.SelectedItem as TreeViewItem).Header = newName;
            }
            else if (changed == true && newName != null && newName != "")
            {
                var t = (treeView.SelectedItem as TreeViewItem).Items.OfType<TreeViewItem>();
                if (t.Select(x => x.Header).Contains(newName))
                {
                    MessageBox.Show("Узел с таким названием уже существует.", "Ошибка");
                    return;
                }
                (treeView.SelectedItem as TreeViewItem).Header = newName;
            }
            else
            {
                MessageBox.Show($"Следует написать новое непустое название");
            }
            changed = false;
            IsEnabled = true;
        }

        private void addLineButton_Click(object sender, RoutedEventArgs e)
        {
            ProductData = null;
            if (treeView.SelectedItem == null)
            {
                MessageBox.Show("Для того чтобы добавить товар, сначала выберете раздел", "Ошибка");
                return;
            }
            ProductCard productCard = new ProductCard();
            productCard.Owner = this;
            productCard.Closed += (sender, e) => IsEnabled = true;
            productCard.Closed += WriteProduct;
            productCard.Show();
            IsEnabled = false;
        }

        private void WriteProduct(object sender, EventArgs e)
        {
            if (ProductData != null)
            {
                (treeView.SelectedItem as MyTreeViewItem).Products.Add(ProductData as Product);
                ValidateGrid(null, null);
            }
        }
        private void ValidateGrid(object sender, EventArgs e)
        {
            if (ProductData != null)
            {
                productsGrid.Items.Clear();
                foreach (Product product in (treeView.SelectedItem as MyTreeViewItem).Products)
                {
                    productsGrid.Items.Add(product);
                }
            }
        }
        // TODO Добавить редактирование товаров
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //string output = JsonConvert.SerializeObject(treeView);
            File.AppendAllText($"save.txt", $"{JsonConvert.SerializeObject(treeView)}");
        }
    }
}
