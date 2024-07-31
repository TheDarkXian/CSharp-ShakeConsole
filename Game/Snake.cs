using Csharp核心实践.Math2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践.Game
{
    internal class Snake : SnakePoint
    {
        public Snake(int x, int y) : base(x, y, ConsoleColor.Green)
        {
            snakePoints = new TDKList<SnakePoint>();
            isalive = true;
            snakePoints.Append(this);

        }
        public Snake(Vector2 pos) : this(pos.x, pos.y) { }

        SnakePoint head
        {
            get
            {
                return snakePoints[0];
            }

        }
        public TDKList<SnakePoint> snakePoints;
        public Vector2 moveDir;
        public bool isalive;
        public void AddLenth()
        {
            Vector2 oldpos = snakePoints.GetTail().oldPos;
            SnakePoint snakePoint = new SnakePoint(oldpos);
            snakePoints.Append(snakePoint);
        }
        public void SetDir(Vector2 dir)
        {

            if (dir == (moveDir * -1))
            {
                return;
            }
            moveDir = dir;

        }
        public override void Render()
        {

            FrameToolkit.Draw(snakePoints.ToArray());
            base.Render();

        }
        public override void Update()
        {

            if (!isalive) { return; }
            base.Update();
            Vector2 newpos = this.pos;
            if (moveDir.x != 0)
            {
                newpos.x += moveDir.x;
            }
            newpos += moveDir;
            FrameToolkit.ClearCeil(0, 0, this.pos);
            this.pos = newpos;
            if (snakePoints.lenth >= 1)
            {
                for (int i = 1; i < snakePoints.lenth; i++)
                {
                    FrameToolkit.ClearCeil(0, 0, snakePoints[i].pos);
                    snakePoints[i].pos = snakePoints[i - 1].oldPos;

                }

            }


        }
        public bool IsBiteSelf()
        {

            for (int i = 1; i < snakePoints.lenth; i++)
            {
                if (this.pos == snakePoints[i].pos)
                {

                    return true;
                }
            }
            return false;
        }
        public bool IsCollison(Vector2 targetpos)
        {
            bool b = true;
            for (int i = 0; i < snakePoints.lenth; i++)
            {

                b = (b && targetpos != snakePoints[i].pos);

            }
            return b;
        }


    }

}
