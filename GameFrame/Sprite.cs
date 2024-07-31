using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal class Sprite
    {
        public string Img;
        public ConsoleColor Color;
        public Sprite(string img, ConsoleColor consoleColor = ConsoleColor.White)
        {
            this.Img = img;
            this.Color = consoleColor;
        }

    }
}
