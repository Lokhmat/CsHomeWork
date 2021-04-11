using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ParserLib;
using System.Windows.Media;
using System.Windows.Input;

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
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) => changed = true;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string text = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text;
            ParserLib.ParserLib.Start(text);

            foreach (var el in ParserLib.ParserLib.Coordinates)
            {
                textBox.Document.Blocks.FirstBlock.TextEffects = new TextEffectCollection();
                textBox.Document.Blocks.FirstBlock.TextEffects.Add(new TextEffect(Transform.Identity, Brushes.Red, Geometry.Empty, el.Item1, el.Item2 - el.Item1));
                /*
                var st = textBox.Document.Blocks.FirstBlock.ContentStart;
                var end = textBox.Document.Blocks.FirstBlock.ContentStart;
                for (int i = 0; i < el.Item2; i++)
                {
                    if (i < el.Item1)
                        st = st.GetNextContextPosition(LogicalDirection.Forward);

                    end = end.GetNextContextPosition(LogicalDirection.Forward);
                }
                var tr = new TextRange(st, end);
                tr.ApplyPropertyValue(TextElement­.ForegroundProperty, Brushes.Red);
                */
            }
            ParserLib.ParserLib.Coordinates.Clear();
        }

        private void textBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var newPointer = textBox.Selection.Start.InsertLineBreak();
                textBox.Selection.Select(newPointer, newPointer);
                e.Handled = true;
            }
        }
    }
}

