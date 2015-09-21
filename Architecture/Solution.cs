using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    partial class Solution
    {
        static DiggerWindow wnd;

        static void Go(Directions direction)
        {
            wnd.Go(direction);
        }

        [STAThread]
        static void Main()
        {
            var levelNumber = 0;
            if (RequestLevel > -1)
                levelNumber = RequestLevel;
            else
            {
                try
                {
                    levelNumber = int.Parse(File.ReadAllText("level.txt"));
                }
                catch { }
            }
            
            var method = typeof(Levels).GetMethod("Level" + levelNumber);
            if (method==null)
            {
                MessageBox.Show("Запрошенный уровень отсутствует");
                return;
            }

            var map = (Map)method.Invoke(null, new object[0]);
            map.LevelNumber=levelNumber;
            wnd = new DiggerWindow(map);
            new Action<int,string>(Solution.Play).BeginInvoke(levelNumber, map.MapInfo, null, null);
            Application.Run(wnd);
        }
    }
}
