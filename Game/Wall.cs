using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Csharp核心实践.Game
{
    internal class Wall : GameObject
    {
        public Wall(int x, int y, ConsoleColor consoleColor = ConsoleColor.Red)
        : base(x, y, "■", consoleColor)
        {

        }
    }
}
