using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class Maze
    {
        List<Block>[,] structure;
        /*List<Pickup>[,] pickups;
        List<Ghost> ghosts;
        Pacman pacman;*/

        public Maze(string constructFile)
        {
            StreamReader bluePrint = new StreamReader(constructFile);
            List<string> lines = new List<string>();
            string nextLine = bluePrint.ReadLine();
            while (nextLine != null)
            {
                lines.Add(nextLine);
                nextLine = bluePrint.ReadLine();
            }

            // TODO: parce data

        }

    }
}
