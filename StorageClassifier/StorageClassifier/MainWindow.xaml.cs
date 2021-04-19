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
using Microsoft.Win32;

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
        MyItem backupTree;
        public MainWindow()
        {
            InitializeComponent();
            backupTree = new MyItem();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += CheckFields;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dispatcherTimer.Start();
        }

        private void CheckFields(object sender, EventArgs e)
        {
            if (productsGrid.SelectedItems.Count != 1)
            {
                deleteProduct.IsEnabled = false;
                editProduct.IsEnabled = false;
            }
            else
            {
                deleteProduct.IsEnabled = true;
                editProduct.IsEnabled = true;
            }
            if (!int.TryParse(lowValue.Text, out _))
                exportButton.IsEnabled = false;
            else
                exportButton.IsEnabled = true;
            if (nodeName.Text != "")
            {
                if (treeView.SelectedItem != null)
                {
                    addLineButton.IsEnabled = true;
                    addNodeButton.IsEnabled = true;
                }
                else
                {
                    addNodeButton.IsEnabled = false;
                    addLineButton.IsEnabled = false;
                }
                addGlobalNodeButton.IsEnabled = true;
            }
            else
            {
                if (treeView.SelectedItem == null)
                    addLineButton.IsEnabled = false;
                addNodeButton.IsEnabled = false;
                addGlobalNodeButton.IsEnabled = false;
                addLineButton.IsEnabled = false;
            }
            CheckForDuplicateNodes();
        }

        private void CheckForDuplicateNodes()
        {
            var t = treeView.Items.OfType<TreeViewItem>();
            if (t.Select(x => x.Header).Contains(nodeName.Text))

                addGlobalNodeButton.IsEnabled = false;
            else
                addGlobalNodeButton.IsEnabled = true;
            if (treeView.SelectedItem != null)
            {
                t = (treeView.SelectedItem as TreeViewItem).Items.OfType<TreeViewItem>();
                if (t.Select(x => x.Header).Contains(nodeName.Text))
                    addNodeButton.IsEnabled = false;
                else
                    addNodeButton.IsEnabled = true;
            }
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
                var node = new MyTreeViewItem() { Header = nodeName.Text };
                (treeView.SelectedItem as TreeViewItem).Items.Add(node);

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
                var node = new MyTreeViewItem() { Header = nodeName.Text };
                treeView.Items.Add(node);
                backupTree.Items.Add(new MyItem() { prototype = node, Header = node.Header.ToString() });
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
                if ((treeView.SelectedItem as MyTreeViewItem).Products.Select(x => x.Name).Contains((ProductData as Product).Name))
                {
                    MessageBox.Show("Введённое название товара в этом разделе не уникально", "Ошибка");
                    return;
                }
                (ProductData as Product).Path = string.Join('/', AncestorsAndSelf(treeView.SelectedItem as MyTreeViewItem));
                (treeView.SelectedItem as MyTreeViewItem).Products.Add(ProductData as Product);
                ValidateGrid(null, null);
            }
        }
        private void ValidateGrid(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (ProductData != null)
            {
                productsGrid.Items.Clear();
                foreach (Product product in (treeView.SelectedItem as MyTreeViewItem).Products)
                {
                    productsGrid.Items.Add(product);
                }
                productsGrid.Items.Add(new Product() { Name = "___ Товары в подразделах __", Code = "_____"});
                foreach (MyTreeViewItem item in (treeView.SelectedItem as MyTreeViewItem).Items)
                    GoDownTree(item);
            }
        }

        private void GoDownTree(MyTreeViewItem node)
        {
            foreach (Product product in node.Products)
            {
                productsGrid.Items.Add(product);
            }
            foreach (MyTreeViewItem item in node.Items)
            {
                GoDownTree(item);
            }
        }


        // TODO Добавить редактирование товаров
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((treeView.Items[0] as TreeViewItem).Items[0] as TreeViewItem);
            /*
            // Тут не подходит сериализация 
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            File.AppendAllText($"save.txt", $"{JsonConvert.SerializeObject(treeView.Items, settings)}");
            // Я не знаю, работает это или нет
            /*
            try
            {
                using (Stream stream = File.Open("storage.bin", FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, treeView.Items.Cast<MyTreeViewItem>().ToList());
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }*/
            RelDict.SerializeTree(treeView);

        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            //RelDict.DeserializeTree("storage.bin");
        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem == null || productsGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать раздел и товар", "Ошибка");
                return;
            }
            var clickedProduct = productsGrid.SelectedItem as Product;
            if(!(treeView.SelectedItem as MyTreeViewItem).Products.Remove(clickedProduct))
            {
                foreach(MyTreeViewItem item in (treeView.SelectedItem as MyTreeViewItem).Items)
                {
                    DeleteDown(item, clickedProduct);
                }
            }
            ValidateGrid(null, null);
        }

        private void DeleteDown(MyTreeViewItem tree, Product product)
        {
            if (tree.Products.Remove(product))
                return;
            foreach(MyTreeViewItem item in tree.Items)
            {
                DeleteDown(item, product);
            }
        }

        private void editProduct_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem == null || productsGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать раздел и товар", "Ошибка");
                return;
            }
            ProductData = null;
            Product curProduct = productsGrid.SelectedItem as Product;
            ProductCard productCard = new ProductCard(curProduct);
            productCard.Owner = this;
            productCard.Closed += (sender, e) => IsEnabled = true;
            productCard.Closed += EditProduct;
            productCard.Show();
            IsEnabled = false;
            ValidateGrid(null, null);
        }
        private void EditProduct(object sender, EventArgs e)
        {
            if (ProductData != null)
            {
                Product curProduct = productsGrid.SelectedItem as Product;
                if ((treeView.SelectedItem as MyTreeViewItem).Products.Select(x => x.Name).Contains((ProductData as Product).Name) && (ProductData as Product).Name != curProduct.Name)
                {
                    MessageBox.Show("Введённое название товара в этом разделе не уникально", "Ошибка");
                    return;
                }
                List<Product> products = new List<Product>();
                FindProduct(treeView.SelectedItem as MyTreeViewItem, curProduct, products);
                if (products.Count == 1)
                {
                    var change = products[0];
                    change.Name = (ProductData as Product).Name;
                    change.Price = (ProductData as Product).Price;
                    change.Code = (ProductData as Product).Code;
                    change.Left = (ProductData as Product).Left;
                    ValidateGrid(null, null);
                }
            }
        }

        private void FindProduct(MyTreeViewItem tree, Product product, List<Product> findProduct)
        {
            var cur = tree.Products.Find(x => x.Path == product.Path);
            if (cur != null)
                findProduct.Add(cur);
            foreach(MyTreeViewItem item in tree.Items)
            {
                FindProduct(item, product, findProduct);
            }
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Файлы CSV | *.csv";
                if (fileDialog.ShowDialog() == true)
                {
                    using (StreamWriter stream = new StreamWriter(fileDialog.FileName))
                    {
                        foreach (MyTreeViewItem item in treeView.Items)
                        {
                            GoThrough(item, sb);
                        }
                        stream.Write(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка:\n{ex.Message}", "Ошибка");
            }
        }

        private void GoThrough(MyTreeViewItem tree, StringBuilder sb)
        {
            foreach (var product in tree.Products)
            {
                if (int.TryParse(lowValue.Text, out int left) && product.Left < left)
                {
                    sb.Append($"{string.Join('/', AncestorsAndSelf(tree))};{product.Code};{product.Name};{product.Left}{Environment.NewLine}");
                }
            }
            foreach (MyTreeViewItem item in tree.Items)
            {
                GoThrough(item, sb);
            }
        }

        private List<string> AncestorsAndSelf(MyTreeViewItem tree)
        {
            List<string> items = new List<string>();
            var cur = tree;
            while (cur != null)
            {
                items.Add(cur.Header.ToString());
                if (cur.Parent == null)
                    cur = null;
                else
                    cur = cur.Parent as MyTreeViewItem;
            }

            items.Reverse();
            return items;
        }
    }
}
