using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class GUIBox : GUIElement
    {

        protected int width, height,
                      leftSpacing, rightSpacing, topSpacing, bottomSpacing;
        protected BoxStretch stretchMode;
        protected Texture2D sprite;

        public GUIBox(int x, int y, Texture2D sprite)
            : this(x, y, sprite, BoxStretch.None, 0, 0, 0, 0, sprite.Width, sprite.Height) { }

        public GUIBox(int x, int y, Texture2D sprite, BoxStretch stretchMode, int leftSpacing, int rightSpacing, int topSpacing, int bottomSpacing, int width, int height) : base(x,y,"box")
        {
            this.leftSpacing = leftSpacing;
            this.rightSpacing = rightSpacing;
            this.topSpacing = topSpacing;
            this.bottomSpacing = bottomSpacing;
            this.stretchMode = stretchMode;
            this.sprite = sprite;
            this.width = width;
            this.height = height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (stretchMode == BoxStretch.None)
                DrawHelper.DrawBox(spriteBatch, sprite, Position, Vector2.Zero);
            else
                DrawHelper.DrawBox(spriteBatch, sprite, Position, Size, stretchMode, leftSpacing, rightSpacing, topSpacing, bottomSpacing);
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

        public BoxStretch StretchMode
        {
            get { return stretchMode; }
            set { stretchMode = value; }
        }

    }
}
