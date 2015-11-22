using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class InlineWall : Wall
    {

        protected float top;

        public InlineWall(float top, float x, float y) : base(x, y)
        {
            this.top = top;
        }

    }
}
