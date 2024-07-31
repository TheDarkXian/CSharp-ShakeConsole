using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践
{
    internal class GameObject
    {
        Vector2 _pos;
        public Vector2 oldPos;
        public Vector2 pos
        {
            set
            {
                oldPos = _pos;
                _pos = value;
            }
            get
            { return _pos; }
        }
        public Sprite render;
        public GameObject(Vector2 position, Sprite render)
        {
            _pos = position;
            this.pos = position;
            this.render = render;

        }
        public GameObject(int x, int y, Sprite render) : this(new Vector2(x, y), render)
        { }
        public GameObject(int x, int y, string render, ConsoleColor consoleColor = ConsoleColor.White) : this(new Vector2(x, y), new Sprite(render, consoleColor))
        { }
        public GameObject(Vector2 position, string render, ConsoleColor consoleColor = ConsoleColor.White)
        : this(position, new Sprite(render, consoleColor))
        { }
        public GameObject() : this(new Vector2(0, 0), new Sprite(""))
        { }

        public virtual void Render()
        {
            FrameToolkit.Draw(this);


        }
        public virtual void Update()
        {

        }

    }
}
