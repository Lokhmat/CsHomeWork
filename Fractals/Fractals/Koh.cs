using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Fractals
{
    /// <summary>
    /// Класс для кривой Коха.
    /// </summary>
    class Koh : Fractal
    {
        // Начало и конец прямой.
        Point start;
        Point end;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="start"> Точка начала прямой.</param>
        /// <param name="end"> Точка окончания прямой.</param>
        public Koh(Point start, Point end)
        {
            this.maxRecur = 9;
            this.start = start;
            this.end = end;
        }
        /// <summary>
        /// Функция для отрисовки прямой.
        /// </summary>
        /// <param name="depth"> Глубина рекурсии.</param>
        /// <param name="target"> Где рисовать.</param>
        public override void Refresh(int depth, Graphics target)
        {
            Draw(target, this);
            if (depth <= maxRecur)
            {

                if (depth > 0)
                {
                    // Считаем вершину треугольника, закрашиваем центр и рекурсино вызываем от двух каждых соседних вершин.
                    Point firstThird = new Point((2*start.X + end.X) / 3, (2*start.Y + end.Y) / 3);
                    Point secondThird = new Point((start.X + 2*end.X) / 3, (start.Y + 2*end.Y) / 3);
                    target.DrawLine(new Pen(Color.White, 4), firstThird, secondThird);
                    Point newDot = new Point(Convert.ToInt32((secondThird.X - firstThird.X) * Math.Cos(-Math.PI/3) - (secondThird.Y - firstThird.Y) * Math.Sin(-Math.PI/3) + firstThird.X), Convert.ToInt32((secondThird.X - firstThird.X) * Math.Sin(-Math.PI / 3) + (secondThird.Y - firstThird.Y) * Math.Cos(-Math.PI / 3) + firstThird.Y));
                    var first = new Koh(start,firstThird);
                    var second = new Koh(firstThird,newDot);
                    var third = new Koh(newDot,secondThird);
                    var fourth = new Koh(secondThird,end);
                    first.Refresh(depth - 1, target);
                    second.Refresh(depth - 1, target);
                    third.Refresh(depth - 1, target);
                    fourth.Refresh(depth - 1, target);
                }
            }


        }
        /// <summary>
        /// Функция для рисования прямой.
        /// </summary>
        /// <param name="target"> Где рисовать.</param>
        /// <param name="line"> Прямая которую рисовать.</param>
        private void Draw(Graphics target, Koh line)
        {
            target.DrawLine(new Pen(Color.Blue,2),line.start, line.end);
        }
    }
}
