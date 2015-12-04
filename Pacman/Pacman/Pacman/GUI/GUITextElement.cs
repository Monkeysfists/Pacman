using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class GUITextElement : GUIElement
    {
        
        protected string text;
        protected SpriteFont font;

        public GUITextElement(int x,int y, string text, SpriteFont font) : this(x, y, Alignment.TopLeft, text, font) { }

        public GUITextElement(int x, int y, Alignment alignment, string text, SpriteFont font) : base(alignment)
        {
            this.text = text;
            this.font = font;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, Position, Color.White);
        }

        /// <summary>
        /// Get/Set the origin of the given alignment (Top: Left/Middle/Right Centre: Left/Middle/Right Bottom: Left/Middle/Right
        /// </summary>
        public override Vector2 Origin
        {
            get
            {
                Vector2 size = TextSize;
                switch (alignment)
                {
                    case Alignment.TopLeft: return new Vector2(x, y);
                    case Alignment.TopMiddle: return new Vector2(x + size.X / 2, y);
                    case Alignment.TopRight: return new Vector2(x + size.X, y);
                    case Alignment.CentreLeft: return new Vector2(x, y + size.Y / 2);
                    case Alignment.CentreMiddle: return new Vector2(x + size.X / 2, y + size.Y / 2);
                    case Alignment.CentreRight: return new Vector2(x + size.X, y + size.Y / 2);
                    case Alignment.BottomLeft: return new Vector2(x, y + size.Y);
                    case Alignment.BottomMiddle: return new Vector2(x + size.X / 2, y + size.Y);
                    case Alignment.BottomRight: return new Vector2(x + size.X, y + size.Y);
                    default: return Vector2.Zero;
                }
            }
            set
            {
                Vector2 size = TextSize;
                switch (alignment)
                {
                    case Alignment.TopLeft:
                        x = (int)value.X;
                        y = (int)value.Y;
                        break;
                    case Alignment.TopMiddle:
                        x = (int)(value.X - size.X / 2);
                        y = (int)value.Y;
                        break;
                    case Alignment.TopRight:
                        x = (int)(value.X - size.X);
                        y = (int)value.Y;
                        break;
                    case Alignment.CentreLeft:
                        x = (int)value.X;
                        y = (int)(value.Y - size.Y / 2);
                        break;
                    case Alignment.CentreMiddle:
                        x = (int)(value.X - size.X / 2);
                        y = (int)(value.Y - size.Y / 2);
                        break;
                    case Alignment.CentreRight:
                        x = (int)(value.X - size.X);
                        y = (int)(value.Y - size.Y / 2);
                        break;
                    case Alignment.BottomLeft:
                        x = (int)value.X;
                        y = (int)(value.Y - size.Y);
                        break;
                    case Alignment.BottomMiddle:
                        x = (int)(value.X - size.X / 2);
                        y = (int)(value.Y - size.Y);
                        break;
                    case Alignment.BottomRight:
                        x = (int)(value.X - size.X);
                        y = (int)(value.Y - size.Y);
                        break;
                }
            }
        }

        /// <summary>
        /// Sets or returns the vertical distance in pixels betweeen two consecutive lines of text
        /// </summary>
        public int LineSpacing
        {
            get { return font.LineSpacing; }
            set
            {
                Vector2 pos = Origin;
                font.LineSpacing = value;
                Origin = pos;
            }
        }

        /// <summary>
        /// Measures the Size of the given string (Width & Height)
        /// </summary>
        public virtual Vector2 TextSize
        {
            get { return font.MeasureString(text); }
        }

    }
}
