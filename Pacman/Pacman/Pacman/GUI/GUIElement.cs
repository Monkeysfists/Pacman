using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{

    public enum Alignment { TopLeft, TopMiddle, TopRight, CentreLeft, CentreMiddle, CentreRight, BottomLeft, BottomMiddle, BottomRight }

    public abstract class GUIElement
    {

        protected int x, y;
        protected Alignment alignment;

        public GUIElement(Alignment alignment)
        {
            this.alignment = alignment;
        }

        public virtual void HandleInput(InputHelper input) { }
        public virtual void Update(GameTime gameTime) { }

        public abstract void Draw(SpriteBatch spriteBatch);
        
        public abstract Vector2 Origin { get; set; }

        
        public Vector2 Position
        {
            get { return new Vector2(x, y); }
        }

        public Alignment Alignment
        {
            get { return alignment; }
            set
            {
                Vector2 pos = Origin;
                alignment = value;
                Origin = pos;
            }
        }

    }
}
