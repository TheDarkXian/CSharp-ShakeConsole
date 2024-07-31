using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践.Game
{
    internal class SnakePoint : GameObject
    {
        public SnakePoint(int x, int y, ConsoleColor consoleColor = ConsoleColor.White) : this(new Vector2(x, y), consoleColor)
        {

        }
        public SnakePoint(Vector2 vector2, ConsoleColor consoleColor = ConsoleColor.White) : base(vector2, "■", consoleColor)
        {
        }



    }
}
