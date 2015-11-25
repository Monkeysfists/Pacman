using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public abstract class GUIElement
    {

        protected int x, y;
        protected string type;

        public GUIElement(int x, int y, string type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public virtual void HandleInput(InputHelper input) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        public Vector2 Position
        {
            get { return new Vector2(x, y); }
            set
            {
                x = (int)value.X;
                y = (int)value.Y;
            }
        }

        public string Type
        {
            get { return type; }
        }

    }
}
