using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{

    public enum Alignment { TopLeft, TopMiddle, TopRight, CentreLeft, CentreMiddle, CentreRight, BottomLeft, BottomMiddle, BottomRight }

    public abstract class GUIElement
    {

        protected int x, y;
        protected bool isButton;
        protected Alignment alignment;

        public GUIElement(int x, int y, bool isButton) : this(x, y, Alignment.TopLeft, isButton) { }

        public GUIElement(int x, int y, Alignment alignment, bool isButton)
        {
            this.x = x;
            this.y = y;
            this.isButton = isButton;
            this.alignment = alignment;
        }

        public virtual void HandleInput(InputHelper input) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        public abstract Vector2 Position { get; set; }
        public abstract Alignment Alignment { get; set; }

        public bool IsButton
        {
            get { return isButton; }
        }

    }
}
