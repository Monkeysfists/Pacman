using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman.Structure
{
    public class Slope : Floor
    {

        protected float bottom;

        public Slope(float x, float y, float bottom, float top) : base(x, y, top)
        {
            this.bottom = bottom;
        }

    }
}
