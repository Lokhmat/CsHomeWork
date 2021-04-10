using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;


namespace XAMLRedactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string curPath;
        bool changed = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Document.Blocks.Count != 0 && curPath != null && changed)
            {
                if (MessageBox.Show("Сохранить перед сменой файла?", "Сохранить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using (var file = new StreamWriter(curPath))
                    {
                        string richText = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text;
                        file.Write(richText);

                    }
                }
            }
            OpenFileDialog dialog = new OpenFileDialog() { Filter = "XAML files | *.xaml" };
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    using (var file = new StreamReader(dialog.FileName))
                    {
                        textBox.Document.Blocks.Clear();
                        textBox.Document.Blocks.Add(new Paragraph(new Run(file.ReadToEnd())));
                        fileName.Content = dialog.SafeFileName;
                        curPath = dialog.FileName;
                    }
                    changed = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка:{Environment.NewLine}{ex.Message}", "Ошибка");
                }
            }
        }

        private void OpenAnotherButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (curPath != null)
            {
                using (var file = new StreamWriter(curPath))
                {
                    string richText = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text;
                    file.Write(richText);

                }
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
            string text = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text;

        }
    }
}
