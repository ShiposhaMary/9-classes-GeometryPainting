using System;
using System.Drawing;

namespace GeometryPainting
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLengthVector(this);
        }

        public Vector Add(Vector a)
        {
            return Geometry.Add(this, a);
        }

        public bool Belongs(Segment a)
        {
            return Geometry.IsVectorInSegment(this, a);
        }
    }

    public class Segment
    {  
        public Vector Begin;
        public Vector End;
        
       

        public bool Contains(Vector a)
        {
            return Geometry.IsVectorInSegment(a, this);
        }
    }

    public class Geometry
    {
        /// <summary>
        /// Возвращает длину вектора
        /// </summary>
        /// <param name="a">Вектор, длину которого вы хотите узнать</param>
        /// <returns>Длина вектора </returns>
        public static double GetLengthVector(Vector a)
        {
            return Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        /// <summary>
        /// Возвращает вектор, являющийся суммой векторов
        /// </summary>
        /// <param name="a">Первый вектор</param>
        /// <param name="b">Второй вектор</param>
        /// <returns>Вектор-сумма</returns>
        public static Vector Add(Vector a, Vector b)
        {
            return new Vector { X = a.X + b.X, Y = a.Y + b.Y };
        }

        /// <summary>
        /// Возвращает длину сегмента
        /// </summary>
        /// <param name="a">Сегмент, длину которого необходимо найти</param>
        /// <returns>Длина сегмента</returns>
        public static double GetLengthSegment(Segment a)
        {
            var vectorDiff = new Vector { X = a.End.X - a.Begin.X, Y = a.End.Y - a.Begin.Y };
            return GetLengthVector(vectorDiff);
        }
        /// <summary>
        /// Определяет, принадлежит ли точка, задаваемая вектором, сегменту
        /// </summary>
        /// <param name="c">ТВектор, задающий точку</param>
        /// <param name="ab">Сегмент</param>
        /// <returns>Принадлженость точки отрезку</returns>
        public static bool IsVectorInSegment(Vector c, Segment ab)
        {
            var acVector = new Vector { X = c.X - ab.Begin.X, Y = c.Y - ab.Begin.Y };
            var bcVector = new Vector { X = c.X - ab.End.X, Y = c.Y - ab.End.Y };
            var ac = GetLengthVector(acVector);
            var bc = GetLengthVector(bcVector);

            return Math.Abs(ac + bc - GetLengthSegment(ab)) < 1e-9;
        }
    }
}
