using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践.Game
{
    internal class ScorePoint : GameObject
    {
        public ScorePoint(int x, int y) : base(x, y, "◆", ConsoleColor.Yellow)
        {

        }

        public ScorePoint(Vector2 pos) : this(pos.x, pos.y)
        {

        }

    }



}
