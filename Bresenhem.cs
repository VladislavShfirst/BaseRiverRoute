using System;
using System.Collections.Generic;
using System.Text;

namespace BaseRiverBridge
{
    class Bresenhem
    {
        int x0, x1, y0, y1;
        public Bresenhem ()
        {
            x0 = 0;
            x1 = 0;
            y0 = 0;
            y1 = 0;

        }
        public void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        void DrawPoint(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
        public void BresenhemLine(int x0, int y0, int x1, int y1,char c)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0); // Проверяем рост отрезка по оси икс и по оси игрек
                                                               // Отражаем линию по диагонали, если угол наклона слишком большой
            if (steep)
            {
                Swap(ref x0, ref y0); // Перетасовка координат вынесена в отдельную функцию для красоты
                Swap(ref x1, ref y1);
            }
            // Если линия растёт не слева направо, то меняем начало и конец отрезка местами
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2; // Здесь используется оптимизация с умножением на dx, чтобы избавиться от лишних дробей
            int ystep = (y0 < y1) ? 1 : -1; // Выбираем направление роста координаты y
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                DrawPoint(steep ? y : x, steep ? x : y,c); // Не забываем вернуть координаты на место
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }
    }
}
