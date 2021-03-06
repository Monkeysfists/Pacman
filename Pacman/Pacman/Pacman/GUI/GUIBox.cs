﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class GUIBox : GUITextureElement
    {

        protected int width, height,
                      leftSpacing, rightSpacing, topSpacing, bottomSpacing;
        protected BoxStretch stretchMode;

        public GUIBox(int x, int y, Texture2D sprite)
            : this(x, y, sprite, BoxStretch.None, 0, 0, 0, 0, sprite.Width, sprite.Height) { }

        public GUIBox(int x, int y, Texture2D sprite, BoxStretch stretchMode, int leftSpacing, int rightSpacing, int topSpacing, int bottomSpacing, int width, int height) : base(x, y, sprite)
        {
            this.leftSpacing = leftSpacing;
            this.rightSpacing = rightSpacing;
            this.topSpacing = topSpacing;
            this.bottomSpacing = bottomSpacing;
            this.stretchMode = stretchMode;
            this.width = width;
            this.height = height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (stretchMode == BoxStretch.None)
                DrawHelper.DrawBox(spriteBatch, sprite, Position, Vector2.Zero);
            else
                DrawHelper.DrawBox(spriteBatch, sprite, Position, Size, stretchMode, leftSpacing, rightSpacing, topSpacing, bottomSpacing); // TODO: fix position for these modes
        }

        /// <summary>
        /// Returns Width
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Returns Height
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Returns Size/ Set Size
        /// </summary>
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
