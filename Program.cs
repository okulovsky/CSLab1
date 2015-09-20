﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    static class Program
    {
        static Map map;
        static DiggerWindow wnd;

        static void Action()
        {
            wnd.Go(Directions.Right);
            wnd.Go(Directions.Right);
            wnd.Go(Directions.Right);
            wnd.Go(Directions.Down);
            wnd.Go(Directions.Down);
            wnd.Go(Directions.Down);
            wnd.Go(Directions.Down);
        }

        [STAThread]
        static void Main()
        {
            map = Levels.Level4();
            wnd = new DiggerWindow(map);
            wnd.Autocheck();
            Application.Run(wnd);
        }
    }
}
