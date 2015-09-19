using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var map = Levels.TestLevel();
            Application.Run(new DiggerWindow(map));
        }
    }
}
