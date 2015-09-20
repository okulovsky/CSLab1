using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    class Levels
    {

        public static Map Level0()
        {
            var map = new MapConstructor(10, 3).Descriptions("Просто идите в направлении Right!", null).Frame().PlayFrom(1, 1);
            map.Map[8, 1] = new Door();
            return map.Map;
        }

        public static Map Level1()
        {
            var map = new MapConstructor(20, 15);
            map=map
                .Descriptions("Ширина этой карты - {0} элементов, высота - {1}", null, map.Map.Width, map.Map.Height)
                .Frame()
                .PlayFrom(1, 1);
            map.Map.Solution = wnd =>
                {
                    for (int x = 0; x < 20 - 2 - 1; x++) wnd.Go(Directions.Right);
                    for (int x = 0; x < 15 - 2 - 1; x++) wnd.Go(Directions.Down);
                };
            map.Map[18, 13] = new Door();
            return map.Map;
        }

        public static Map Level2()
        {
            var map = new MapConstructor(20, 11);
            map = map
                 .Descriptions("Ширина - {0}, высота - {1}", "Size {0} {1}", map.Map.Width, map.Map.Height)
                 .Fill()
                 .PlayFrom(1, 1);
            for (int i = 0; i < 2; i++)
                map.Dig(Directions.Right, 17).Dig(Directions.Down, 2).Dig(Directions.Left, 17).Dig(Directions.Down, 2);
            map.DoorHere();
            return map.Map;
        }

        public static Map Level3()
        {
            var map = new MapConstructor(16, 15);
            map = map
                 .Descriptions("Сделайте универсальный алгоритм для прохождения спирали. Размеры лабиринта возьмите из переменной MapInfo", "Size {0} {1}", map.Map.Width, map.Map.Height)
                 .Fill()
                 .PlayFrom(1, 1);
            for (int i = 0; i < 3; i++)
                map.Dig(Directions.Right, 13).Dig(Directions.Down, 2).Dig(Directions.Left, 13).Dig(Directions.Down, 2);
            map.DoorHere();
            return map.Map;
        }


        public static Map Level4()
        {
            var map = new MapConstructor(15, 6);
            map = map
                 .Descriptions("Попробуйте сразу найти взаимосвязь между размерами карты и кодом", "Size {0} {1}", map.Map.Width, map.Map.Height)
                 .Fill()
                 .PlayFrom(1, 1);

            for (int i = 0; i < 3; i++)
                map = map.Dig(Directions.Right, 4).Dig(Directions.Down, 1);

            map.Map.Solution = wnd =>
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++) wnd.Go(Directions.Right);
                    for (int j = 0; j < 1; j++) wnd.Go(Directions.Down);
                }
            };
            map.DoorHere();
            return map.Map;
        }

        public static Map Level5()
        {
            var map = new MapConstructor(18, 13);
            map=map
                .Descriptions("Возможно, закономерность сложнее, чем кажется", "Size {0} {1}", map.Map.Width,map.Map.Height)
                .Fill()
                .PlayFrom(1, 1);
            for (int i = 0; i < 5; i++)
                map = map.Dig(Directions.Right, 3).Dig(Directions.Down, 2);
            
            map.Map.Solution = wnd =>
                {
                    for (int i = 0; i <5; i++)
                    {
                        for (int j = 0; j < 3; j++) wnd.Go(Directions.Right);
                        for (int j = 0; j < 2; j++) wnd.Go(Directions.Down);
                    }
                };
            map.DoorHere();
            return map.Map;
        }

        public static Map Level6()
        {
            var data=new []
            {
                "  x     x   xxxx      xx      x    ",
                "   x   x    x   x    x  x    xxx   ",
                "    x x     x   x   x    x   xxx   ",
                "     x      xxxx    xxxxxx    x    ",
                "    x       x       x    x         ",
                "   x        x       x    x    x    "
            };
            
            var map = new MapConstructor(data[0].Length,data.Length).Descriptions("Вы прошли все уровни",null).Map;

            for (int x=0;x<map.Width;x++)
                for (int y=0;y<map.Height;y++)
                    map[x,y]=data[y][x]==' '?null:new Brick();

            return map;
        }




    }
}
