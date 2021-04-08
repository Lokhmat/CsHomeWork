using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Fractals
{
    /// <summary>
    /// Класс для ковра Серпинского.
    /// </summary>
    class SerpCarpet : Fractal
    {
        // Верхний левый угол и длина стороны.
        Point leftTop;
        int side;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="leftTop"> Левая верхняя вершина.</param>
        /// <param name="side"> Длина стороны.</param>
        public SerpCarpet(Point leftTop, int side)
        {
            this.maxRecur = 7;
            this.leftTop = leftTop;
            this.side = side;
        }
        /// <summary>
        /// Функция для пересовки фрактала.
        /// </summary>
        /// <param name="depth"> Глубина рекурсии.</param>
        /// <param name="target"> Где рисовать.</param>
        public override void Refresh(int depth, Graphics target)
        {

            target.FillRectangle(new SolidBrush(Color.Blue), leftTop.X, leftTop.Y, side, side);
            if (depth <= maxRecur && depth > 0)
            {
                // Закрашиваем центр белым и вызываем остальные квадраты.
                target.FillRectangle(new SolidBrush(Color.White), leftTop.X + side / 3, leftTop.Y + side / 3, side / 3, side / 3);
                List<SerpCarpet> carpets = new List<SerpCarpet>();
                carpets.Add(new SerpCarpet(leftTop, side / 3));
                carpets.Add(new SerpCarpet(new Point(leftTop.X + side / 3, leftTop.Y), side / 3));
                carpets.Add(new SerpCarpet(new Point(leftTop.X + 2 * side / 3, leftTop.Y), side / 3));
                carpets.Add(new SerpCarpet(new Point(leftTop.X, leftTop.Y + side / 3), side / 3));
                carpets.Add(new SerpCarpet(new Point(leftTop.X + 2 * side / 3, leftTop.Y + side / 3), side / 3));
                carpets.Add(new SerpCarpet(new Point(leftTop.X, leftTop.Y + 2 * side / 3), side / 3));
                carpets.Add(new SerpCarpet(new Point(leftTop.X + side / 3, leftTop.Y + 2 * side / 3), side / 3));
                carpets.Add(new SerpCarpet(new Point(leftTop.X + 2 * side / 3, leftTop.Y + 2 * side / 3), side / 3));
                foreach(var carpet in carpets)
                    carpet.Refresh(depth-1,target);
            }

        }
    }
}
