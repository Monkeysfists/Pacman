using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{

    public enum BoxStretch { None, LeftRight, TopBottom, Corners, Total }

    public static partial class DrawHelper
    {

        private static Texture2D pixel;
        private static GraphicsDevice graphics;

        public static void Init(GraphicsDevice graphicsDevice)
        {
            graphics = graphicsDevice;
            pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
        }

        /// <summary>
        /// Gives One pixel of desired color
        /// </summary>
        /// <param name="color"></param>
        /// <returns>1 colored pixel</returns>
        public static Texture2D GetColoredPixel(Color color)
        {
            Texture2D pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new[] { color });
            return pixel;
        }
        
        public static void DrawBox(SpriteBatch spriteBatch, Texture2D sprite, Vector2 position, Vector2 size, BoxStretch stretchMode = BoxStretch.None, int leftSpacing = 0, int rightSpacing = 0, int topSpacing = 0, int bottomSpacing = 0)
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            int width = (int)size.X;
            int height = (int)size.Y;

            switch (stretchMode)
            {
                case BoxStretch.None: spriteBatch.Draw(sprite, position, Color.White); break;
                case BoxStretch.Total: spriteBatch.Draw(sprite, new Rectangle(x, y, width, height), Color.White); break;
                case BoxStretch.LeftRight:
                    spriteBatch.Draw(sprite, position, new Rectangle(0, 0, leftSpacing, sprite.Height), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x + leftSpacing, y, width - leftSpacing - rightSpacing, sprite.Height), new Rectangle(leftSpacing, 0, sprite.Width - leftSpacing - rightSpacing, sprite.Height), Color.White);
                    spriteBatch.Draw(sprite, new Vector2(x + width - rightSpacing, y), new Rectangle(sprite.Width - rightSpacing, 0, rightSpacing, sprite.Height), Color.White);
                    break;
                case BoxStretch.TopBottom:
                    spriteBatch.Draw(sprite, position, new Rectangle(0, 0, sprite.Width, topSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Rectangle(x, y + topSpacing, sprite.Width, height - topSpacing - bottomSpacing), new Rectangle(0, topSpacing, sprite.Width, sprite.Height - topSpacing - bottomSpacing), Color.White);
                    spriteBatch.Draw(sprite, new Vector2(x, y + height - bottomSpacing), new Rectangle(0, sprite.Height - bottomSpacing, sprite.Width, bottomSpacing), Color.White);
                    break;
                case BoxStretch.Corners:
                    spriteBatch.Draw(sprite, position, new Rectangle(0, 0, leftSpacing, topSpacing), Color.White);
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

    }
}
