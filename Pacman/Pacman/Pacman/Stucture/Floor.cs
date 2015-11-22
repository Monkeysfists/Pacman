using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class Floor : Block
    {

        protected float top;

        public Floor(float x, float y, float top) : base(x, y)
        {
            this.top = top;
        }

    }
}
