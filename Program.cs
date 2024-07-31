using System.Diagnostics;

namespace Csharp核心实践
{



    internal class Program
    {

        static void Main(string[] args)
        {
            GameStartScence gameStartScence = new GameStartScence();
            GamePlayScence playScence = new GamePlayScence();

            GameScene.SwitchScene(0);
            GameScene gameScene;
            float FPS = 1000 / 5f;
            float previousTimeout = Environment.TickCount;
            float crurenttime = 0;
            float elapsedTime = 0;
            while (true)
            {
                FrameToolkit.InputUpdate();
                gameScene = GameScene.currentScene;
                crurenttime = Environment.TickCount;
                elapsedTime = crurenttime - previousTimeout;
                gameScene.OnGetInput();
                if (elapsedTime >= FPS)
                {

                    gameScene.Update();
                    gameScene.Render();
                    gameScene.OnEndUpdate();
                    previousTimeout = crurenttime;
                }



            }


        }


    }
}
