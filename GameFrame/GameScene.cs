using Csharp核心实践.Math2D;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal abstract class GameScene
    {
        public static Rect GameWindow = new Rect(0, 0, 80, 40);
        public static GameSceneFlag currentSceneFlag;
        public static void SwitchScene(GameSceneFlag index)
        {
            currentScene.OnUnload();
            currentSceneFlag = index;
            currentScene.ini();

        }
        public static GameScene currentScene
        {
            get
            {

                return gameSceneList[(int)currentSceneFlag];

            }
        }

        protected static TDKList<GameScene> gameSceneList;

        static GameScene()
        {
            Console.SetWindowSize(GameWindow.width, GameWindow.height);
            Console.SetBufferSize(GameWindow.width, GameWindow.height);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
            gameSceneList = new TDKList<GameScene>();

        }
        public TDKList<GameObject> gameobjList;
        protected bool isactive;

        public GameScene()
        {
            AddaScne(this);
            gameobjList = new TDKList<GameObject>();




        }
        public abstract void ini();
        public abstract void Render();
        public virtual void Instance(GameObject obj)
        {
            gameobjList.Append(obj);
        }
        public virtual void Destroy()
        {


        }
        public abstract void OnUnload();
        public abstract void Update();
        public abstract void OnGetInput();
        public abstract void OnEndUpdate();
        public static void AddaScne(GameScene newScene)
        {
            gameSceneList.Append(newScene);
        }

        public enum GameSceneFlag
        {
            GameStart,
            GamePlay,
        }


    }
}
