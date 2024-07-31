using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal struct Vector2
    {
        public static Vector2 zero = new Vector2(0, 0);
        public int x;
        public int y;
        public static Vector2 RandomDir()
        {
            Random random = new Random();
            int x = random.Next(-1, 1);
            int y = random.Next(-1, 1);
            return new Vector2(x * 2, y);
        }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2((int x, int y) pos)
        {
            this.x = pos.x;
            this.y = pos.y;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {

            return new Vector2(a.x + b.x, a.y + b.y);

        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {

            return new Vector2(a.x - b.x, a.y - b.y);

        }
        public static Vector2 operator *(Vector2 a, int b)
        {

            return new Vector2(a.x * b, a.y * b);

        }
        public static Vector2 operator +(Vector2 a, (int x, int y) pos)
        {

            return new Vector2(a.x + pos.x, a.y + pos.y);

        }
        public static Vector2 operator -(Vector2 a, (int x, int y) pos)
        {

            return new Vector2(a.x - pos.x, a.y - pos.y);

        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            if (a.x == b.x && b.y == a.y)
            {
                return true;
            }
            return false;

        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            if (a.x != b.x || b.y != a.y)
            {
                return true;
            }
            return false;

        }
    }
}
