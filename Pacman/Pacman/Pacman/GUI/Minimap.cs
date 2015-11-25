using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Minimap : GUIBox
    {

        protected int paddingX, paddingY;
        protected Texture2D minimapData;

        public Minimap(int x, int y, int paddingX, int paddingY) : base(x, y, null, BoxStretch.Total, 0, 0, 0, 0, 0, 0)
        {
            // TODO: determain if data size can be declared in constructor call or has to be made in constructor body by calling maze data (order of constructing important)

            this.paddingX = paddingX;
            this.paddingY = paddingY;

            sprite = DrawHelper.GetColoredPixel(Color.Gray); // background
            ParseMazeData();
            width = minimapData.Width + (2 * paddingX);
            height = minimapData.Height + (2 * paddingY);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ParseMazeData();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch); // draws background

            spriteBatch.Draw(minimapData, new Vector2(x + paddingX, y + paddingY), Color.White);
        }

        public void ParseMazeData()
        {
            // TODO: retrieve structural data from maze and parse it into a 2D pixel array
        }

    }
}
