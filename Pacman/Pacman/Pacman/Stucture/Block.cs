using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public enum Enclosure { Free, Edge, Corner, Side, Middle, Centre }; // used te determain which part of a block should never be drawn, because another block ocupies it's entire side

    public abstract class Block
    {

        protected float x, y, z;
        protected Model model;
        protected Matrix world, view, projection;
        protected Enclosure enclosure;

        public Block(float x, float y, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            // set placeholder matrices till first camera update
            // TODO: move view and projection matrixes to camera class
            world = Matrix.CreateWorld(Position, new Vector3(1, 0, 0), new Vector3(1, 0, 0));
            view = Matrix.CreateLookAt(Vector3.Zero, new Vector3(1, 0, 0), new Vector3(1, 0, 0));
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(30), PacmanGame.AspectRatio, 10, 100);
        }

        public void Render()
        {
            model.Draw(world, view, projection);
        }

        public Vector3 Position
        {
            get { return new Vector3(x, y, z); }
        }

    }
}
