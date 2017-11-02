using System;

namespace Atagoal
{
    namespace Core
    {
        public class Vector
        {
            public float x = 0;
            public float y = 0;

            public Vector() { }
            public Vector(Point from, Point to)
            {
                x = to.x - from.x;
                y = to.y - from.y;
            }
            public Vector(float argX, float argY)
            {
                x = argX;
                y = argY;
            }


            public static Vector Create()
            {
                return new Vector { x = 0, y = 0 };
            }

            public static Vector Create(Point from, Point to)
            {
                return new Vector { x = to.x - from.x, y = to.y - from.y };
            }

            public static Vector Create(float argX, float argY)
            {
                return new Vector { x = argX, y = argY };
            }

            public double GetPower()
            {
                return x * x + y * y;
            }

            public float GetLength()
            {
                return (float)System.Math.Sqrt(GetPower());
            }

            public Vector GetUnit()
            {
                float length = GetLength();
                return new Vector
                {
                    x = x / length,
                    y = y / length
                };
            }

            public Vector Rotate(float radian)
            {
                var sin = System.Math.Sin(radian);
                var cos = System.Math.Cos(radian);

                var unitVector = GetUnit();
                var rotatedVector = Vector.Create(
                                (float)(unitVector.x * cos - unitVector.y * sin),
                                (float)(unitVector.x * sin + unitVector.y * cos))
                                 * GetLength();

                x = rotatedVector.x;
                y = rotatedVector.y;

                return this;
            }

            public Vector Clone()
            {
                return new Vector { x = this.x, y = this.y };
            }

            public bool Equals(Vector vector)
            {
                return x == vector.x
                    && y == vector.y;
            }

            public string Describe()
            {
                return "Vector: x = " + x + ", y = " + y;
            }

            public override string ToString()
            {
                return Describe();
            }

            public static Vector operator +(Vector vector1, Vector vector2)
            {
                return new Vector
                {
                    x = vector1.x + vector2.x,
                    y = vector1.y + vector2.y
                };
            }

            public static Vector operator -(Vector vector1, Vector vector2)
            {
                return new Vector
                {
                    x = vector1.x - vector2.x,
                    y = vector1.y - vector2.y
                };
            }

            public static Vector operator *(Vector vector1, float scale)
            {
                return new Vector
                {
                    x = vector1.x * scale,
                    y = vector1.y * scale
                };
            }

            public static Vector operator /(Vector vector1, float scale)
            {
                return new Vector
                {
                    x = vector1.x / scale,
                    y = vector1.y / scale
                };
            }
        }
    }
}