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
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += CheckFields;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dispatcherTimer.Start();
        }
        /// <summary>
        /// Check if we could unlock some buttons to user if he changed smth.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Another method for checking, only in order to fit every in 40 lines.
        /// </summary>
        private void CheckForDuplicateNodes()
        {
            var t = treeView.Items.OfType<TreeViewItem>();
            if (t.Select(x => x.Header).Contains(nodeName.Text))
                addGlobalNodeButton.IsEnabled = false;
            else if (nodeName.Text != "")
                addGlobalNodeButton.IsEnabled = true;
            if (treeView.SelectedItem != null)
            {
                t = (treeView.SelectedItem as TreeViewItem).Items.OfType<TreeViewItem>();
                if (t.Select(x => x.Header).Contains(nodeName.Text))
                    addNodeButton.IsEnabled = false;
                else if (nodeName.Text != "")
                    addNodeButton.IsEnabled = true;
                if (treeView.SelectedItem != null)
                {
                    addLineButton.IsEnabled = true;
                }
                else
                {
                    addLineButton.IsEnabled = false;
                }
            }
        }
        /// <summary>
        /// Adding sub node to another node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Add global node to treeView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка:\n{ex.Message}", "Ошибка");
            }
        }
        /// <summary>
        /// Deleting node fron treeView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteNode_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null && (treeView.SelectedItem as TreeViewItem).Items.Count == 0 && (treeView.SelectedItem as MyTreeViewItem).Products.Count == 0)
                if ((treeView.SelectedItem as TreeViewItem).Parent is TreeView)
                    treeView.Items.Remove(treeView.SelectedItem);
                else
                    ((treeView.SelectedItem as TreeViewItem).Parent as TreeViewItem).Items.Remove(treeView.SelectedItem);
            else
                MessageBox.Show("Раздел не выбран или не пуст", "Ошибка");
        }
        /// <summary>
        /// Handler of edit button for node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Handles result from edit node window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Handler of addition of new product, makes new window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Writes product to treeView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteProduct(object sender, EventArgs e)
        {
            if (ProductData != null && (treeView.SelectedItem as MyTreeViewItem) != null)
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
        /// <summary>
        /// Redrawing grid if smth changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateGrid(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (treeView.SelectedItem as MyTreeViewItem != null)
            {
                productsGrid.Items.Clear();
                foreach (Product product in (treeView.SelectedItem as MyTreeViewItem).Products)
                {
                    productsGrid.Items.Add(product);
                }
                productsGrid.Items.Add(new Product() { Name = "___ Товары в подразделах __", Code = "_____" });
                foreach (MyTreeViewItem item in (treeView.SelectedItem as MyTreeViewItem).Items)
                    GoDownTree(item);
            }
        }
        /// <summary>
        /// Recursive method for wathkthrough tree.
        /// </summary>
        /// <param name="node"> Another node.</param>
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

        /// <summary>
        /// Handler of serializing treeView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Файлы bin | *.bin";
                if (fileDialog.ShowDialog() == true)
                {
                    using (Stream stream = File.Open(fileDialog.FileName, FileMode.Create))
                    {
                        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        MyItem tree = new MyItem();
                        foreach (MyTreeViewItem item in treeView.Items)
                        {
                            MyItem newItem = new MyItem() { Products = item.Products, Header = item.Header.ToString(), Parent = tree };
                            tree.Items.Add(newItem);
                            TreeBuilder(item, newItem);
                        }
                        binaryFormatter.Serialize(stream, tree);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка:\n{ex.Message}", "Ошибка");
            }

        }
        /// <summary>
        /// Build tree in order to serialize.
        /// </summary>
        /// <param name="tree"> UI tree.</param>
        /// <param name="receiveTree"> Serializable tree.</param>
        private void TreeBuilder(MyTreeViewItem tree, MyItem receiveTree)
        {
            foreach (MyTreeViewItem item in tree.Items)
            {
                MyItem newItem = new MyItem() { Products = item.Products, Header = item.Header.ToString(), Parent = receiveTree };
                receiveTree.Items.Add(newItem);
                TreeBuilder(item, newItem);
            }

        }
        /// <summary>
        /// Handler of load button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Файлы bin | *.bin";
                if (fileDialog.ShowDialog() == true)
                {
                    using (Stream stream = File.Open(fileDialog.FileName, FileMode.Open))
                    {
                        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        MyItem tree = binaryFormatter.Deserialize(stream) as MyItem;
                        treeView.Items.Clear();
                        foreach (MyItem item in tree.Items)
                        {
                            MyTreeViewItem newItem = new MyTreeViewItem() { Products = item.Products, Header = item.Header.ToString() };
                            treeView.Items.Add(newItem);
                            Rebuild(item, newItem);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка:\n{ex.Message}", "Ошибка");
            }
        }
        /// <summary>
        /// Rebuilding deserialized tree from file to UI.
        /// </summary>
        /// <param name="tree"> Tree from file.</param>
        /// <param name="uiTree"> Tree to paste in UI.</param>
        private void Rebuild(MyItem tree, MyTreeViewItem uiTree)
        {
            foreach (MyItem item in tree.Items)
            {
                MyTreeViewItem newItem = new MyTreeViewItem() { Products = item.Products, Header = item.Header.ToString() };
                uiTree.Items.Add(newItem);
                TreeBuilder(newItem, item);
            }
        }
        /// <summary>
        /// Handler of deletion of a Product.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem == null || productsGrid.SelectedItem == null)
            {
                MessageBox.Show("Вы должны выбрать раздел и товар", "Ошибка");
                return;
            }
            var clickedProduct = productsGrid.SelectedItem as Product;
            if (!(treeView.SelectedItem as MyTreeViewItem).Products.Remove(clickedProduct))
            {
                foreach (MyTreeViewItem item in (treeView.SelectedItem as MyTreeViewItem).Items)
                {
                    DeleteDown(item, clickedProduct);
                }
            }
            ValidateGrid(null, null);
        }
        /// <summary>
        /// Another walkthrough tree in order to delete correct product.
        /// </summary>
        /// <param name="tree"> Another tree node.</param>
        /// <param name="product"> Product to delete.</param>
        private void DeleteDown(MyTreeViewItem tree, Product product)
        {
            if (tree.Products.Remove(product))
                return;
            foreach (MyTreeViewItem item in tree.Items)
            {
                DeleteDown(item, product);
            }
        }
        /// <summary>
        /// Handler of editing product.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        }
        /// <summary>
        /// Editing product and updating window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditProduct(object sender, EventArgs e)
        {
            if (ProductData != null && treeView.SelectedItem != null && productsGrid.SelectedItem as Product != null)
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
        /// <summary>
        /// Find product in all tree.
        /// </summary>
        /// <param name="tree"> Tree to find into.</param>
        /// <param name="product"> Product to find.</param>
        /// <param name="findProduct"> List of acceptable products.</param>
        private void FindProduct(MyTreeViewItem tree, Product product, List<Product> findProduct)
        {
            var cur = tree.Products.Find(x => x.Path == product.Path);
            if (cur != null)
                findProduct.Add(cur);
            foreach (MyTreeViewItem item in tree.Items)
            {
                FindProduct(item, product, findProduct);
            }
        }
        /// <summary>
        /// Export ot CSV handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Another walkthrough tree(Building path of node).
        /// </summary>
        /// <param name="tree"> Tree to walk.</param>
        /// <param name="sb"> String to build path.</param>
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
        /// <summary>
        /// Get all Anscestors of a node and a node itself.
        /// </summary>
        /// <param name="tree"> Node of a tree.</param>
        /// <returns> List of anscestors and node itself.</returns>
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
        /// <summary>
        /// Show FAQ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void faqButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Привет!" +
                "В программе реализован весь обязательный функционал + 1 доп. функция\n" +
                "Я не очень хорошо отдебажил, тк не успевал, так что существует вероятность что упадёт, буду рад услышать коменты что забыл.\n" +
                "На TreeView и DataGrid есть контекстные меню чтобы удалить/изменить элементы\n" +
                "Чтобы разблокировались кнопки надо выполнить то, что для них нужно(Например чтобы добавить узел напишите название узла, для экспорта напишите маленькое кол-во из тз)");
        }
    }
}
