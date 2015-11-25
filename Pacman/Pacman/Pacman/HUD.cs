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

        public void HandleInput(InputHelper input)
        {
            foreach (GUIElement element in guiElements)
                if(element.Type == "button")
                    element.HandleInput(input);
        }

        public void Update(GameTime gameTime)
        {
            foreach (GUIElement element in guiElements)
                element.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GUIElement element in guiElements)
                element.Draw(spriteBatch);
        }

    }
}
