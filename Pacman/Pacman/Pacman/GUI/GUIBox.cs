using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{

    public enum GUIBoxStretch { None, LeftRight, TopBottom, Corners }

    public class GUIBox
    {

        protected int x, y,
                      width, height,
                      leftSpacing, rightSpacing, topSpacing, bottomSpacing;
        protected GUIBoxStretch stretchMode;
        protected Texture2D sprite;

        public GUIBox(int x, int y, Texture2D sprite)
            : this(x, y, sprite, GUIBoxStretch.None, 0, 0, 0, 0, sprite.Width, sprite.Height) { }

        public GUIBox(int x, int y, Texture2D sprite, GUIBoxStretch stretchMode, int leftSpacing, int rightSpacing, int topSpacing, int bottomSpacing, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.leftSpacing = leftSpacing;
            this.rightSpacing = rightSpacing;
            this.topSpacing = topSpacing;
            this.bottomSpacing = bottomSpacing;
            this.stretchMode = stretchMode;
            this.sprite = sprite;
            this.width = width;
            this.height = height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (stretchMode)
            {
                case GUIBoxStretch.None: spriteBatch.Draw(sprite, Position, Color.White); break;
                case GUIBoxStretch.LeftRight:
                    spriteBatch.Draw(sprite, Position, new Rectangle(0, 0, leftSpacing, sprite.Height), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x + leftSpacing, y, width - leftSpacing - rightSpacing, sprite.Height), new Rectangle(leftSpacing, 0, sprite.Width - leftSpacing - rightSpacing, sprite.Height), Color.White);
                    spriteBatch.Draw(sprite, new Vector2(x + width - rightSpacing, y), new Rectangle(sprite.Width - rightSpacing, 0, rightSpacing, sprite.Height), Color.White);
                    break;
                case GUIBoxStretch.TopBottom:
                    spriteBatch.Draw(sprite, Position, new Rectangle(0, 0, sprite.Width, topSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x, y + topSpacing, sprite.Width, height - topSpacing - bottomSpacing), new Rectangle(0, topSpacing, sprite.Width, sprite.Height - topSpacing - bottomSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Vector2(x, y + height - bottomSpacing), new Rectangle(0, sprite.Height - bottomSpacing, sprite.Width, bottomSpacing), Color.White);
                    break;
                case GUIBoxStretch.Corners:
                    spriteBatch.Draw(sprite, Position, new Rectangle(0, 0, leftSpacing, topSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x + leftSpacing, y, width - leftSpacing - rightSpacing, topSpacing), new Rectangle(leftSpacing, 0, sprite.Width - leftSpacing - rightSpacing, topSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Vector2(x + width - rightSpacing, y), new Rectangle(sprite.Width - rightSpacing, 0, rightSpacing, topSpacing), Color.White);

                    spriteBatch.Draw(sprite, new Rectangle(x, y + topSpacing, leftSpacing, height - topSpacing - bottomSpacing), new Rectangle(0, topSpacing, leftSpacing, sprite.Height - topSpacing - bottomSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x + leftSpacing, y + topSpacing, width - leftSpacing - rightSpacing, height - topSpacing - bottomSpacing), new Rectangle(leftSpacing, topSpacing, sprite.Width - leftSpacing - rightSpacing, sprite.Height - topSpacing - bottomSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x + width - rightSpacing, y + height - bottomSpacing, rightSpacing, height - topSpacing - bottomSpacing), new Rectangle(sprite.Width - rightSpacing, topSpacing, rightSpacing, sprite.Height - topSpacing - bottomSpacing), Color.White);

                    spriteBatch.Draw(sprite, new Vector2(x, y + height - bottomSpacing), new Rectangle(0, sprite.Height - bottomSpacing, leftSpacing, bottomSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x + leftSpacing, y + height - bottomSpacing, width - leftSpacing - rightSpacing, bottomSpacing), new Rectangle(leftSpacing, sprite.Height - bottomSpacing, sprite.Width - leftSpacing - rightSpacing, bottomSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Vector2(x + width - rightSpacing, y + height - bottomSpacing), new Rectangle(sprite.Width - rightSpacing, sprite.Height - bottomSpacing, rightSpacing, bottomSpacing), Color.White);
                    break;
            }
        }

        public Vector2 Position
        {
            get { return new Vector2(x, y); }
            set
            {
                x = (int)value.X;
                y = (int)value.Y;
            }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Vector2 Size
        {
            get { return new Vector2(width, height); }
            set
            {
                width = (int)value.X;
                height = (int)value.Y;
            }
        }

        public GUIBoxStretch StretchMode
        {
            get { return stretchMode; }
            set { stretchMode = value; }
        }

    }
}
