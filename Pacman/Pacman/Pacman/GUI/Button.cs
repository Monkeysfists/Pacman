using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class Button : GUITextureElement
    {

        protected bool isPressed = false;

        public Button(int x, int y, Texture2D sprite) : this(x, y, sprite, Alignment.TopLeft) { }
        public Button(int x, int y, Texture2D sprite, Alignment alignment) : base(x, y, sprite, alignment) { }

        public override void HandleInput(InputHelper input)
        {
            isPressed = input.IsMouseButtonPresed(MouseButton.Left) && BoundingBox.Contains((int)input.MousePosition.X, (int)input.MousePosition.Y);
        }

        /// <summary>
        /// Creates a boundingBox on the Button
        /// </summary>
        private Rectangle BoundingBox
        {
            get
            {
                Vector2 pos = Position;
                return new Rectangle((int)pos.X, (int)pos.Y, sprite.Width, sprite.Height);
            }
        }

        /// <summary>
        /// Checks if the button is pressed
        /// </summary>
        public bool IsPressed
        {
            get { return isPressed; }
        }

    }
}
