using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class AutoScaleButton : GUIBox
    {
        
        // TODO: finish auto scale with text and the relevant properties

        public AutoScaleButton(int x, int y, Texture2D sprite, string buttonText, SpriteFont font) : base(x,y,sprite,true)
        {

        }

        public AutoScaleButton(int x,int y,Texture2D sprite, string buttonText, SpriteFont font, BoxStretch stretchMode, int leftSpacing, int rightSpacing, int topSpacing, int bottomSpacing) : base(x, y, sprite, true, stretchMode, leftSpacing, rightSpacing, topSpacing, bottomSpacing, 0, 0)
        {

        }

    }
}
