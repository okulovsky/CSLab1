﻿using System;
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
		static int RequestLevel = -1; //вставьте номер уровня для прямого доступа к нему

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
        }
    }
}
