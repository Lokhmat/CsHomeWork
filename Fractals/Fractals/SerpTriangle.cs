using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Fractals
{
    /// <summary>
    /// Класс для треугольника Серпинского.
    /// </summary>
    class SerpTriangle : Fractal
    {
        // Вершины треугольника.
        Point a, b, c;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="a"> Сторона.</param>
        /// <param name="b"> Сторона.</param>
        /// <param name="c"> Сторона.</param>
        public SerpTriangle(Point a, Point b, Point c)
        {
            this.maxRecur = 10;
            this.a = a;
            this.b = b;
            this.c = c;
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
                    var first = new SerpTriangle(a, new Point((b.X + a.X) / 2, (b.Y + a.Y) / 2), new Point((a.X + c.X) / 2, (a.Y + c.Y) / 2));
                    var second = new SerpTriangle(b, new Point((c.X + b.X) / 2, (b.Y + c.Y) / 2), new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2));
                    var third = new SerpTriangle(c, new Point((c.X + b.X) / 2, (b.Y + c.Y) / 2), new Point((a.X + c.X) / 2, (a.Y + c.Y) / 2));
                    first.Refresh(depth - 1, target);
                    second.Refresh(depth - 1, target);
                    third.Refresh(depth - 1, target);
                }
            }
            
        }
        /// <summary>
        /// Рисование треугольника.
        /// </summary>
        /// <param name="target"> Где рисовать.</param>
        /// <param name="triangle"> Треугольник что нарисовать.</param>
        private void Draw(Graphics target, SerpTriangle triangle)
        {

                target.DrawPolygon(new Pen(Color.Blue,(float)2), new Point[3] { triangle.a, triangle.b, triangle.c });
        }
    }
}
