using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Platform : Block
    {

        protected float bottom, top;

        public Platform(float bottom, float top, float x, float y, float z = 0) : base(x, y, z)
        {
            this.bottom = bottom;
            this.top = top;
        }

    }
}
