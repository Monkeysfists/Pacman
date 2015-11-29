using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public abstract class GUITextureElement : GUIElement
    {

        protected Texture2D sprite;

        public GUITextureElement(int x, int y, Texture2D sprite) : this(x, y, sprite, Alignment.TopLeft) { }

        public GUITextureElement(int x, int y, Texture2D sprite, Alignment alignment) : base(alignment)
        {
            if (sprite != null)
            {
                this.sprite = sprite;
                Origin = new Vector2(x, y);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Position, Color.White);
        }

        public override Vector2 Origin
        {
            get
            {
                switch (alignment)
                {
                    case Alignment.TopLeft: return new Vector2(x, y);
                    case Alignment.TopMiddle: return new Vector2(x + sprite.Width / 2, y);
                    case Alignment.TopRight: return new Vector2(x + sprite.Width, y);
                    case Alignment.CentreLeft: return new Vector2(x, y + sprite.Height / 2);
                    case Alignment.CentreMiddle: return new Vector2(x + sprite.Width / 2, y + sprite.Height / 2);
                    case Alignment.CentreRight: return new Vector2(x + sprite.Width, y + sprite.Height / 2);
                    case Alignment.BottomLeft: return new Vector2(x, y + sprite.Height);
                    case Alignment.BottomMiddle: return new Vector2(x + sprite.Width / 2, y + sprite.Height);
                    case Alignment.BottomRight: return new Vector2(x + sprite.Width, y + sprite.Height);
                    default: return Vector2.Zero;
                }
            }
            set
            {
                switch (alignment)
                {
                    case Alignment.TopLeft:
                        x = (int)value.X;
                        y = (int)value.Y;
                        break;
                    case Alignment.TopMiddle:
                        x = (int)value.X - sprite.Width / 2;
                        y = (int)value.Y;
                        break;
                    case Alignment.TopRight:
                        x = (int)value.X - sprite.Width;
                        y = (int)value.Y;
                        break;
                    case Alignment.CentreLeft:
                        x = (int)value.X;
                        y = (int)value.Y - sprite.Height / 2;
                        break;
                    case Alignment.CentreMiddle:
                        x = (int)value.X - sprite.Width / 2;
                        y = (int)value.Y - sprite.Height / 2;
                        break;
                    case Alignment.CentreRight:
                        x = (int)value.X - sprite.Width;
                        y = (int)value.Y - sprite.Height / 2;
                        break;
                    case Alignment.BottomLeft:
                        x = (int)value.X;
                        y = (int)value.Y - sprite.Height;
                        break;
                    case Alignment.BottomMiddle:
                        x = (int)value.X - sprite.Width / 2;
                        y = (int)value.Y - sprite.Height;
                        break;
                    case Alignment.BottomRight:
                        x = (int)value.X - sprite.Width;
                        y = (int)value.Y - sprite.Height;
                        break;
                }
            }
        }

        public virtual Vector2 SpriteSize
        {
            get { return new Vector2(sprite.Width, sprite.Height); }
        }
    }
}
