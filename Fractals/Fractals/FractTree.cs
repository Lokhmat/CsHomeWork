using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractals
{
    /// <summary>
    /// Класс реализующий фрактальное дерево.
    /// </summary>
    class FractTree : Fractal
    {   // Константа на которую сдвигать отрезок.
        public static double? leftConst=null,rightConst=null;
        // Точки начала и конца, углы и отношение отрезков.
        Point start, end;
        double leftAngle, rightAngle;
        double ratio;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="start"> Точка старта.</param>
        /// <param name="end"> Точка конца.</param>
        /// <param name="leftAngle"> Угол левого отрезка.</param>
        /// <param name="rightAngle"> Угол правого отрезка.</param>
        /// <param name="ratio"> Отношение отрезков.</param>
        public FractTree(Point start, Point end, string leftAngle, string rightAngle, string ratio)
        {
            this.maxRecur = 15;
            this.start = start;
            this.end = end;
            if (!double.TryParse(leftAngle, out this.leftAngle) || !double.TryParse(rightAngle, out this.rightAngle) || !double.TryParse(ratio, out this.ratio) || this.ratio<=0)
                throw new ArgumentException("Неправильно введены вспомагательные данные. Посмотрите вкладку help");
            if(leftConst==null && rightConst == null)
            {
                leftConst = this.leftAngle;
                rightConst = this.rightAngle;
            }
        }
        /// <summary>
        /// Метод для отрисовки фрактала.
        /// </summary>
        /// <param name="depth"> Глубина рекурсии.</param>
        /// <param name="target"> Место где рисовать.</param>
        public override void Refresh(int depth, Graphics target)
        {
            target.DrawLine(new Pen(Color.Blue), start, end);
            if (depth <= maxRecur && depth > 0)
            {
                // Считаем новые координаты отрезка с учётом поворота прямой.
                var newLen = Math.Sqrt((end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y)) / ratio;
                var leftLine = new FractTree(end, new Point(end.X - Convert.ToInt32(newLen * Math.Sin(this.leftAngle * Math.PI / 180)), end.Y - Convert.ToInt32(newLen * Math.Cos(leftAngle * Math.PI / 180))), (leftAngle + leftConst).ToString(), (rightAngle - leftConst).ToString(), ratio.ToString());
                var rightLine = new FractTree(end, new Point(end.X + Convert.ToInt32(newLen * Math.Sin(this.rightAngle * Math.PI / 180)), end.Y - Convert.ToInt32(newLen * Math.Cos(rightAngle * Math.PI / 180))), (leftAngle - rightConst).ToString(), (rightAngle + rightConst).ToString(), ratio.ToString());
                leftLine.Refresh(depth - 1, target);
                rightLine.Refresh(depth - 1, target);
            }
        }
    }
}
