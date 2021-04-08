using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Form1 : Form
    {
        // Битмап для сохранения.
        private Bitmap _bitmap;
        int recur;
        // Точка смещения для поправки координат при перемещении.
        Point current = new Point(0, 0);
        // Значение для увеличения.
        int delta = 1;
        /// <summary>
        /// Конструктор.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            paintTimer.Enabled = false;
        }
        /// <summary>
        /// Загружаем форму.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }
        /// <summary>
        /// Если глубина нормальная - перезагружаем форму.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recurDepth_TextChanged(object sender, EventArgs e)
        {
            if (recurDepth.Text != "" && int.TryParse(recurDepth.Text, out this.recur) && recur >= 0)
            {
                pictureBox.Invalidate();
            }

        }
        /// <summary>
        /// Основной метод рисования фрактала в зависимости от выбранного.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics target = e.Graphics;
            Action[] funcs = new Action[5] { () => SerpTri(target), () => KohLine(target), () => SerpCarp(target), () => Tree(target), () => Kant(target) };
            target.Clear(Color.White);
            if (comboBox.SelectedItem != null)
            {
                try
                {
                    switch (comboBox.SelectedItem)
                    {
                        case "Треугольник Серпинского":
                            funcs[0]();
                            break;
                        case "Кривая Коха":
                            funcs[1]();
                            break;
                        case "Ковер Серпинского":
                            funcs[2]();
                            break;
                        case "Обдуваемое ветром фрактальное дерево":
                            funcs[3]();
                            break;
                        case "Множество Кантора":
                            funcs[4]();
                            break;
                    }
                }
                catch (ArgumentException exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка входных данных", MessageBoxButtons.OK);
                }
            }
            
        }
        /// <summary>
        /// Рисование треугольника Серпинсого.
        /// </summary>
        /// <param name="target"> Где рисовать.</param>
        private void SerpTri(Graphics target)
        {
            SetupForElse();
            var start = new Point(pictureBox.Location.X + pictureBox.Size.Width / 2, 20*delta);
            start.X += current.X;
            start.Y += current.Y;
            int len = delta*Math.Min(pictureBox.Size.Height, pictureBox.Size.Width);
            SerpTriangle fractSerpTriangle = new SerpTriangle(new Point(start.X - len / 2, Convert.ToInt32(start.Y + len * Math.Sqrt(3) / 2)), new Point(start.X + len / 2, Convert.ToInt32(start.Y + len * Math.Sqrt(3) / 2)), start);
            fractSerpTriangle.Refresh(recur, target);
        }
        /// <summary>
        /// Рисование кривой Коха.
        /// </summary>
        /// <param name="target"> Где рисовать.</param>
        private void KohLine(Graphics target)
        {
            SetupForElse();
            Point start = new Point(pictureBox.Location.X + 100, pictureBox.Location.Y + pictureBox.Size.Height / 2);
            Point end = new Point(pictureBox.Location.X + pictureBox.Size.Width - 100, pictureBox.Location.Y + pictureBox.Size.Height / 2);
            Point middle = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            start = new Point((start.X - middle.X) * delta + middle.X, (start.Y - middle.Y) * delta + middle.Y);
            start.X += current.X;
            start.Y += current.Y;
            end = new Point((end.X - middle.X) * delta + middle.X, (end.Y - middle.Y) * delta + middle.Y);
            end.X += current.X;
            end.Y += current.Y;
            Koh fractKoh = new Koh(start, end);
            fractKoh.Refresh(recur, target);
        }
        /// <summary>
        /// Рисование ковра Серпинского.
        /// </summary>
        /// <param name="target"> Где рисовать.</param>
        private void SerpCarp(Graphics target)
        {
            SetupForElse();
            SerpCarpet fractCarp = new SerpCarpet(new Point((pictureBox.Size.Width / 4 )+current.X, (pictureBox.Size.Height / 4)+current.Y), delta*Math.Min(pictureBox.Size.Height, pictureBox.Size.Width) / 3 * 2);
            fractCarp.Refresh(recur, target);
        }
        /// <summary>
        /// Рисование фрактального дерева.
        /// </summary>
        /// <param name="target"> Где рисовать.</param>
        private void Tree(Graphics target)
        {
            SetupForTree();
            if (textBox2.Text != "" && textBox1.Text != "" && textBox3.Text != "")
            {
                Point start = new Point(pictureBox.Size.Width / 2, pictureBox.Size.Height - 40);
                
                Point end = new Point(pictureBox.Size.Width / 2, (pictureBox.Size.Height - 40) - 2 * pictureBox.Size.Height / 8);
                
                Point middle = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
                start = new Point((start.X - middle.X) * delta + middle.X, (start.Y - middle.Y) * delta + middle.Y);
                start.X += current.X;
                start.Y += current.Y;
                end = new Point((end.X - middle.X) * delta + middle.X, (end.Y - middle.Y) * delta + middle.Y);
                end.X += current.X;
                end.Y += current.Y;
                FractTree fractTree = new FractTree(start, end, textBox2.Text, textBox1.Text, textBox3.Text);
                fractTree.Refresh(recur, target);
            }
        }
        /// <summary>
        /// Рисование множества Кантора.
        /// </summary>
        /// <param name="target"> Где рисовать.</param>
        private void Kant(Graphics target)
        {
            SetupForKantor();
            if (int.TryParse(textBox1.Text, out int temp) && temp > 0 && temp <= 100)
            {
                Kantor.delta = temp;
                Point start = new Point(100, 100);
                start.X += current.X;
                start.Y += current.Y;
                Point end = new Point(pictureBox.Size.Width - 100, 100);
                end.X += current.X;
                end.Y += current.Y;
                Point middle = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
                start = new Point((start.X - middle.X) * delta + middle.X, (start.Y - middle.Y) * delta + middle.Y);
                end = new Point((end.X - middle.X) * delta + middle.X, (end.Y - middle.Y) * delta + middle.Y);
                var kantorFract = new Kantor(start,end );
                kantorFract.Refresh(recur, target);
            }
            else if (textBox1.Text != "")
                throw new ArgumentException("Неправильно введено количество пикселей между прямыми");

        }
        /// <summary>
        /// Смена выбранного фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Перерисовываем фрактал и обнуляем смещение.
            pictureBox.Invalidate();
            current = new Point(0, 0);
        }
        /// <summary>
        /// Изменение размера окна - перерисовываем фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
        /// <summary>
        /// Подготовка формы для дерева.
        /// </summary>
        public void SetupForTree()
        {
            FractTree.leftConst = null;
            FractTree.rightConst = null;
            supLabel3.Text = "Отношение длин отрезков(этот/следующий):";
            supLabel1.Visible = true;
            supLabel2.Visible = true;
            supLabel3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }
        /// <summary>
        /// Подготовка формы для множества Кантора.
        /// </summary>
        public void SetupForKantor()
        {
            supLabel3.Text = "Кол-во пикселей между прямыми";
            supLabel1.Visible = false;
            supLabel2.Visible = false;
            supLabel3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }
        /// <summary>
        /// Подготовка формы для не дерева и не множества Кантора.
        /// </summary>
        public void SetupForElse()
        {
            supLabel1.Visible = false;
            supLabel2.Visible = false;
            supLabel3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }
        /// <summary>
        /// Нажатие кнопки перерисовки фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            current = new Point(0, 0);
            pictureBox.Invalidate();
        }
        /// <summary>
        /// Метод для сохранения фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFract(object sender, EventArgs e)
        {
            try
            {
                _bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                saveFileDialog1.ShowDialog();
                pictureBox.DrawToBitmap(_bitmap, pictureBox.DisplayRectangle);
                _bitmap.Save(saveFileDialog1.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка:{Environment.NewLine}{ex.Message}");
            } 
        }
        /// <summary>
        /// Метод для показа подсказки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHelp(object sender, EventArgs e)
        {
            string helpMessage = $"Для перемещения фрактала кликните по области рисования фрактала.{Environment.NewLine}Для фрактала могут существовать дополнительные параметры.{Environment.NewLine}Фрактал не рисуется пока вы их не укажите.{Environment.NewLine}При смене параметров используйте кнопку обновления фрактала. При смене глубины рекурсии фрактал перерисуется сам.{Environment.NewLine}Для дерева - отношение этот/следующий это вещественное положительное число. Угл наклона берётся в целых градусах относительно продолжения предыдущей ветви.{Environment.NewLine}Для множества Кантора - кол-во пикселей - целое число пикселей между различными итерациями.{Environment.NewLine}Реализовано 4 доп. функции из ТЗ:перемещение, увеличение, сохранение и перерисовка при масштабировании.{Environment.NewLine}При выборе глубины рекурсии больше чем возможно по ограничениям фрактал не будет рисоваться.{Environment.NewLine}Ограничения:{Environment.NewLine}Дерево - 15{Environment.NewLine}Ковёр - 7{Environment.NewLine}Кривая Коха - 9{Environment.NewLine}Треугольник - 10{Environment.NewLine}Множество Кантора - 15";
            MessageBox.Show(helpMessage, "Помощь", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Метод для обработки увеличения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (trackBar1.Value)
            {
                case 0:
                    delta = 1;
                    break;
                case 1:
                    delta = 2;
                    break;
                case 2:
                    delta = 3;
                    break;
                case 3:
                    delta = 5;
                    break;
            }
            pictureBox.Invalidate();
        }
        /// <summary>
        /// Метод для обработки перемещения по фракталу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            current = new Point( current.X + pictureBox.Size.Width/2 -coordinates.X,current.Y+ pictureBox.Size.Height/2 - coordinates.Y);
            pictureBox.Refresh();
            
        }
    }
}
