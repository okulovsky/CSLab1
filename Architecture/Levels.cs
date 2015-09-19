using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    class Levels
    {
        public static Map TestLevel()
        {
            var Map = new Map(20, 20);
            for (int x = 0; x < Map.Width; x++)
                for (int y = 0; y < Map.Height; y++)
                    Map[x, y] = new Terrain();
            Map[0, 0] = new Player();

            return Map;
        }
    }
}
