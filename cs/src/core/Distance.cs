using System;

namespace Atagoal
{
    namespace Core
    {
        public class Distance
        {
            public float x = 0;
            public float y = 0;

            public Distance() { }
            public Distance(float argX, float argY)
            {
                x = argX;
                y = argY;
            }
            public Distance(Point from, Point to)
            {
                x = to.x - from.x;
                y = to.y - from.y;
            }

            public static Distance Create()
            {
                return new Distance { x = 0, y = 0 };
            }

            public static Distance Create(Point from, Point to)
            {
                return new Distance
                {
                    x = to.x - from.x,
                    y = to.y - from.y
                };
            }

            public float GetPower()
            {
                return x * x + y * y;
            }

            public Distance Clone()
            {
                return new Distance { x = this.x, y = this.y };
            }

            public bool Equals(Distance distance)
            {
                return GetPower() == distance.GetPower();
            }

            public bool FuzzyEquals(Distance distance, float threshold)
            {
                float pow = GetPower();
                float targetPow = distance.GetPower();
                return targetPow - threshold <= pow
                    && pow <= targetPow + threshold;
            }

            public string Describe()
            {
                return "Distance: x = " + x + ", y = " + y;
            }

            public static bool operator >(Distance distance1, Distance distance2)
            {
                return distance1.GetPower() > distance2.GetPower();
            }

            public static bool operator >=(Distance distance1, Distance distance2)
            {
                return distance1.GetPower() >= distance2.GetPower();
            }

            public static bool operator <(Distance distance1, Distance distance2)
            {
                return distance1.GetPower() < distance2.GetPower();
            }

            public static bool operator <=(Distance distance1, Distance distance2)
            {
                return distance1.GetPower() <= distance2.GetPower();
            }
        }
    }
}