using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Fractals
{
    /// <summary>
    /// Шаблон для всех фракталов.
    /// </summary>
    abstract class Fractal
    {
        // Максимальная глубина рекурсии.
        public int maxRecur;
        /// <summary>
        /// Функция для отрисовки прямой.
        /// </summary>
        /// <param name="depth"> Глубина рекурсии.</param>
        /// <param name="target"> Где рисовать.</param>
        public abstract void Refresh(int depth, Graphics target);


    }
}
