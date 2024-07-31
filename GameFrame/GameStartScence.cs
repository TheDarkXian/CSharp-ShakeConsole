using Csharp核心实践.GameFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal class GameStartScence : GameScene
    {

        Text[] optionList;
        Text currentOption
        {
            get { return optionList[optionIndex]; }
        }
        int optionIndex;
        public override void Destroy()
        {

        }
        public override void OnUnload()
        {
            Console.Clear();
            isactive = false;

        }
        public override void ini()
        {
            Vector2 textpos = GameWindow.GetMiddle();
            Text TitleText = new Text(textpos - (4, 8), "贪吃Snake", ConsoleColor.Green);
            FrameToolkit.Draw(TitleText);
            Text option0 = new Text(textpos - (5, 4), "开始吧兄弟");
            Text option1 = new Text(textpos - (3, 2), "退出了");
            optionList = new Text[] { option0, option1 };
            optionIndex = 0;
            isactive = true;
        }
        public override void Render()
        {
            if (!isactive) { return; }
            FrameToolkit.Draw(optionList);

        }
        public override void Update()
        {

        }
        public override void OnGetInput()
        {

            currentOption.SetColor(ConsoleColor.White);
            optionIndex += FrameToolkit.GetInputWASD().y;
            FrameToolkit.CircleNum(ref optionIndex, optionList.Length);
            currentOption.SetColor(ConsoleColor.Red);
            if (FrameToolkit.GetInputBool())
            {
                if (optionIndex == 0)
                {
                    SwitchScene(GameSceneFlag.GamePlay);
                }
                if (optionIndex == 1)
                {
                    Environment.Exit(0);
                }
            }
        }
        public override void OnEndUpdate()
        {
        }
    }


}
