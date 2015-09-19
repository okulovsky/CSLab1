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
            Game.CreateMap();
            Application.Run(new DiggerWindow());
        }
    }
}
