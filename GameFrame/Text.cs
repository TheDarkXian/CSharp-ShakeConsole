using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践.GameFrame
{
    internal class Text : GameObject
    {
        new Sprite render;
        public string text
        {
            set
            {
                base.render.Img = value;
            }
            get
            {
                return base.
                    render.Img;
            }
        }
        public Text(int x, int y, string render, ConsoleColor consoleColor = ConsoleColor.White) : base(x, y, new Sprite(render, consoleColor))
        {
        }

        public Text(Vector2 position, string render, ConsoleColor consoleColor = ConsoleColor.White) : base(position, render, consoleColor)
        {
        }
        public void SetColor(ConsoleColor consoleColor)
        {
            base.render.Color = consoleColor;
        }

    }
}
