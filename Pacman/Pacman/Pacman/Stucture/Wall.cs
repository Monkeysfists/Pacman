﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public abstract class Wall : Block
    {

        public Wall(float x, float y) : base(x, y, 0)
        {

        }

    }
}
