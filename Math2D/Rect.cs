using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal struct Rect

    {
        public Vector2 pos;
        public int width;
        public int height;
        public Rect(int x, int y, int w, int h) : this(new Vector2(x, y), w, h)
        {
        }
        public Rect(Vector2 pos, int w, int h)
        {
            this.pos = pos;
            width = w; height = h;
        }
        public bool IsInside(Vector2 point)
        {
            bool temp = false;
            if (point.x > pos.x && point.x < pos.x + width
            && point.y > pos.y && point.y < pos.y + height)
            {
                temp = true;
            }
            return temp;

        }

        public Vector2 GetMiddle(int ox = 0, int oy = 0)
        {
            int offsetX = width / 2;
            int offsetY = height / 2;
            return new Vector2(offsetX + ox, oy + offsetY) + pos;

        }

        public static Vector2 GetARandomPos(Rect rect)
        {
            Vector2 vector2 = new Vector2(0, 0);
            Random random = new Random();
            int stepOff = random.Next(1, rect.width / 2);
            vector2.x = stepOff * 2;
            vector2.y = random.Next(1, rect.height);
            return vector2;
        }
        public Vector2 GetARandomPos()
        {
            Vector2 vector2 = new Vector2(0, 0);
            Random random = new Random();
            int stepOff = random.Next(1, this.width / 2);
            vector2.x = stepOff * 2;
            vector2.y = random.Next(1, this.height);
            return vector2;
        }

    }

}
