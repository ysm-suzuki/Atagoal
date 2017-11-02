using System;

namespace Atagoal
{
    namespace Core
    {
        public class Point
        {
            public float x;
            public float y;

            public Point()
            {
                x = float.NaN;
                y = float.NaN;
            }
            public Point(float argX, float argY)
            {
                x = argX;
                y = argY;
            }

            public static Point Create()
            {
                return new Point { x = 0, y = 0 };
            }

            public static Point Create(float argX, float argY)
            {
                return new Point { x = argX, y = argY };
            }

            public static Point CreateInvalidPoint()
            {
                return new Point
                {
                    x = float.NaN,
                    y = float.NaN
                };
            }

            public Point Clone()
            {
                return new Point { x = this.x, y = this.y };
            }

            public bool Equals(Point point)
            {
                if (IsInvalidPoint() && point.IsInvalidPoint())
                    return true;
                if (IsInvalidPoint() || point.IsInvalidPoint())
                    return false;

                return x == point.x
                    && y == point.y;
            }

            public bool FuzzyEquals(Point point, float threshold)
            {
                return (point.x - threshold <= x && x <= point.x + threshold)
                    && (point.y - threshold <= y && y <= point.y + threshold);
            }

            public bool IsInvalidPoint()
            {
                return float.IsNaN(x) || float.IsNaN(y);
            }

            public string Describe()
            {
                return "Point: x = " + x + ", y = " + y;
            }

            public override string ToString()
            {
                return Describe();
            }


            public static Point operator +(Point point1, Point point2)
            {
                return new Point
                {
                    x = point1.x + point2.x,
                    y = point1.y + point2.y
                };
            }

            public static Point operator +(Point point, Vector vector)
            {
                return new Point
                {
                    x = point.x + vector.x,
                    y = point.y + vector.y
                };
            }

            public static Point operator -(Point point1, Point point2)
            {
                return new Point
                {
                    x = point1.x - point2.x,
                    y = point1.y - point2.y
                };
            }

            public static Point operator -(Point point, Vector vector)
            {
                return new Point
                {
                    x = point.x - vector.x,
                    y = point.y - vector.y
                };
            }
        }
    }
}