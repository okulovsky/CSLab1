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
            Map[0, 0] = Map.Player;

            return Map;
        }

        static Map FramedMap(int width, int height)
        {
            var map = new Map(width,height);
            for (int x = 0; x < map.Width; x++)
            {
                map[x, 0] = new Terrain();
                map[x, map.Height - 1] = new Terrain();
            }
            for (int y = 0; y < map.Height; y++)
            {
                map[0, y] = new Terrain();
                map[map.Width - 1, y] = new Terrain();
            }
            return map;
        }

        public static Map Level1()
        {
            var map = FramedMap(20, 15);
            map[1, 1] = map.Player;
            map.Description = "Размер этой карты - 20 элементов в ширину, 15 в высоту";
            map.Solution = wnd =>
                {
                    for (int x = 0; x < 20 - 2 - 1; x++) wnd.Go(Directions.Right);
                    for (int x = 0; x < 15 - 2 - 1; x++) wnd.Go(Directions.Down);
                };
            return map;
        }
    }
}
