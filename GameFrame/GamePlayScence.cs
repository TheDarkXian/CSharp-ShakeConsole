using Csharp核心实践.Game;
using Csharp核心实践.GameFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal class GamePlayScence : GameScene
    {
        public ScorePoint ScorePoint;
        Rect PlayScenceWin;
        public Snake snake;
        public Text ScroePlane;
        public Text ScoreText;
        public static int score;
        public bool isGameOver;
        public override void Destroy()
        {


        }

        public override void ini()
        {
            //初始化墙壁
            Wall wall = new Wall(0, 0);
            Wall wall2 = new Wall(0, GameWindow.height - 1);
            Vector2 newpos = new Vector2(0, 0);
            for (int x = 0; x < GameWindow.width; x += 2)
            {
                newpos = wall.pos;
                newpos.x = x;
                wall.pos = newpos;

                newpos = wall2.pos;
                newpos.x = x;
                wall2.pos = newpos;

                FrameToolkit.Draw(wall, wall2);
            }
            wall.pos = new Vector2(0, 0);
            wall2.pos = new Vector2(GameWindow.width - 2, 0);
            for (int y = 0; y < GameWindow.height; y++)
            {
                newpos = wall.pos;
                newpos.y = y;
                wall.pos = newpos;

                newpos = wall2.pos;
                newpos.y = y;
                wall2.pos = newpos;
                FrameToolkit.Draw(wall, wall2);
            }
            PlayScenceWin = GameWindow;
            PlayScenceWin.width -= 2;
            PlayScenceWin.height -= 1;
            isGameOver = false;
            score = 0;
            ScroePlane = new Text(0, 0, "你的分数：");
            ScoreText = new Text(10, 0, "0");
            FrameToolkit.Draw(ScroePlane, ScoreText);

            //初始化完成
            //随机苹果
            Vector2 randomPos = PlayScenceWin.GetARandomPos();
            ScorePoint = new ScorePoint(randomPos);
            snake = new Snake(PlayScenceWin.GetMiddle(-1));


        }
        public void UpdateScore()
        {

            ScoreText = new Text(10, 0, score.ToString());

        }
        public override void OnGetInput()
        {

            if (!isGameOver)
            {
                Vector2 moveDir = FrameToolkit.GetInputWASD();
                if (moveDir != Vector2.zero)
                {
                    snake.SetDir(moveDir);
                }
            }
            else
            {
                if (FrameToolkit.GetInputBool())
                {
                    SwitchScene(GameSceneFlag.GameStart);
                }
            }
        }
        public override void Instance(GameObject obj)
        {
            base.Instance(obj);
        }

        public override void OnUnload()
        {
            Console.Clear();


        }

        public override void Render()
        {
            FrameToolkit.Draw(ScorePoint, ScoreText);
            snake.Render();
        }

        public override void Update()
        {

            snake.Update();

        }
        public void CollsionTest()
        {
            if (isGameOver) { return; }
            Vector2 Rigpos = snake.pos;
            bool isbiteself = snake.IsBiteSelf();
            bool isInside = PlayScenceWin.IsInside(Rigpos);
            isGameOver = isbiteself || !isInside;
            if (isGameOver)
            {
                Text over = new Text(PlayScenceWin.GetMiddle(-9, -2), "游戏结束了....死因：" + (isbiteself ? "成环" : "撞墙"), ConsoleColor.Red);
                Text continues = new Text(PlayScenceWin.GetMiddle(-5, 0), "[ J ] 继续", ConsoleColor.Red);
                FrameToolkit.Draw(over, continues);
                snake.SetDir(Vector2.zero);
                snake.isalive = false;
            }
            if (Rigpos == ScorePoint.pos)
            {

                snake.AddLenth();
                bool getpos = false;
                Vector2 randomPos = PlayScenceWin.GetARandomPos();
                while (!getpos)
                {
                    randomPos = PlayScenceWin.GetARandomPos();
                    getpos = snake.IsCollison(randomPos);

                }
                ScorePoint.pos = randomPos;
                score++;
                UpdateScore();


            }
        }

        public override void OnEndUpdate()
        {

            CollsionTest();
        }
    }
}
