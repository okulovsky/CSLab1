using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    class Levels
    {


        public static Map Level1()
        {
            var map = new MapConstructor(20, 15, "Ширина этой карты - 20 элементов, высота - 15").Frame().PlayFrom(1, 1).Map;
            map.Solution = wnd =>
                {
                    for (int x = 0; x < 20 - 2 - 1; x++) wnd.Go(Directions.Right);
                    for (int x = 0; x < 15 - 2 - 1; x++) wnd.Go(Directions.Down);
                };
            return map;
        }

        public static Map Level2()
        {
            var map = new MapConstructor(5, 4, "Ширина карты - 17, высота - 12").Fill().PlayFrom(1, 1);
            for (int i = 0; i < 1; i++)
                map = map.Dig(Directions.Right, 2).Dig(Directions.Down, 1);
            
            map.Map.Solution = wnd =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 3; j++) wnd.Go(Directions.Right);
                        for (int j = 0; j < 2; j++) wnd.Go(Directions.Down);
                    }
                };

            return map.Map;
        }

    }
}
