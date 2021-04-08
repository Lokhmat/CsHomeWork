using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Fractals
{
    class Kantor : Fractal
    {
        Point start, end;
        public static int delta;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="start"> Начало прямой.</param>
        /// <param name="end"> Конец прямой.</param>
        public Kantor(Point start, Point end)
        {
            this.maxRecur = 15;
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
            target.DrawLine(new Pen(Color.Blue, 4), start, end);
            if (depth <= maxRecur && depth > 0)
            {
                var left = new Kantor(new Point(start.X,start.Y+delta), new Point((2 * start.X + end.X) / 3, end.Y + delta));
                var right = new Kantor(new Point((start.X + 2 * end.X) / 3, end.Y + delta), new Point(end.X,end.Y+delta));
                left.Refresh(depth - 1, target);
                right.Refresh(depth - 1, target);
            }
        }
    }
}
