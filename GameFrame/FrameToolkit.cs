using Csharp核心实践.Math2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal static class FrameToolkit
    {
        public static void SetPos(Vector2 vector2)
        {
            SetPos(vector2.x, vector2.y);
        }
        public static void SetPos(int x, int y)
        {
            if (x >= GameScene.GameWindow.width || x < 0)
            {
                return;
            }
            if (y >= GameScene.GameWindow.height || y < 0)
            {
                return;
            }
            Console.SetCursorPosition(x, y);

        }

        public static void Draw(int offsetx, int offsety, params GameObject[] obj)
        {
            Vector2 oldpos = new Vector2(Console.GetCursorPosition());
            ConsoleColor oldColor = Console.ForegroundColor;
            foreach (var obj2 in obj)
            {
                SetPos(obj2.pos.x + offsetx, obj2.pos.y + offsety);
                Console.ForegroundColor = obj2.render.Color;
                Console.Write(obj2.render.Img);
            }
            SetPos(oldpos);
            Console.ForegroundColor = oldColor;
        }

        public static void ClearCeil(int offsetx, int offsety, params Vector2[] vector2List)
        {
            foreach (Vector2 i in vector2List)
            {
                SetPos(i.x + offsetx, i.y + offsety);
                Console.Write("  ");
            }

        }
        public static void Draw(params GameObject[] obj)
        {
            Draw(0, 0, obj);
        }

        public static ConsoleKey InputUpdate()
        {
            Key = ConsoleKey.None;
            if (Console.KeyAvailable)
            {
                Key = Console.ReadKey(true).Key;
            }
            return Key;
        }
        static ConsoleKey Key;
        public static Vector2 GetInputWASD()
        {
            Vector2 Dir = new Vector2(0, 0);
            if (Key == ConsoleKey.W)
            {
                Dir.y = -1;
            }
            if (Key == ConsoleKey.S)
            {
                Dir.y = 1;
            }
            if (Key == ConsoleKey.A)
            {
                Dir.x = -1;
            }
            if (Key == ConsoleKey.D)
            {
                Dir.x = 1;
            }
            return Dir;
        }

        public static bool GetInputBool()
        {
            bool re = false;
            if (Key == ConsoleKey.J)
            {
                re = true;
            }
            return re;
        }
        public static int CircleNum(ref int source, int maxStep)
        {
            int result = 0;
            source *= source < 0 ? -1 : 1;
            source %= maxStep;
            result = source;
            return result;
        }




    }


}
