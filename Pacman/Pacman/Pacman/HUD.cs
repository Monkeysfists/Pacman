using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class HUD
    {

        List<GUIElement> guiElements;

        public HUD()
        {
            guiElements.Add(new Minimap(200, 200, 3, 3));
        }

        /// <summary>
        /// Loops over all GUI Elements in the List and handles input
        /// </summary>
        /// <param name="input"></param>
        public void HandleInput(InputHelper input)
        {
            foreach (GUIElement element in guiElements)
                element.HandleInput(input);
        }

        /// <summary>
        /// Updates all GUI Elemenets in the List (loop)
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            foreach (GUIElement element in guiElements)
                element.Update(gameTime);
        }

        /// <summary>
        /// Draws all GUI Elemtns in the list (loop)
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GUIElement element in guiElements)
                element.Draw(spriteBatch);
        }

    }
}
