using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    public enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }

    static partial class Solution
    {
        static int RequestLevel = 11;

        static void Level0()
        {
            Go(Directions.Right);
        }
        
        static void Play(int levelNumber, string mapInfo)
        {
            switch(levelNumber)
            {
                case 0: Level0(); return;
            }

            var dir = Directions.Right;
            while(true)
            {
                if (!Go(dir)) dir = (Directions)(((int)dir + 1) % 4);
            }
        }
    }
}
