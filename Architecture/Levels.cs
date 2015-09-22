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
            var map = new MapConstructor(10, 3).Descriptions("Просто идите в направлении Right!", null).Frame();
            map.Map[8, 1] = new Door();
            return map.Map;
        }

        public static Map Level1()
        {
            var map = new MapConstructor(20, 15);
            map=map
                .Descriptions("Ширина этой карты - {0} элементов, высота - {1}", null, map.Map.Width, map.Map.Height)
                .Frame();
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
                 .Fill<Brick>();
            for (int i = 0; i < 2; i++)
                map.Dig(Directions.Right, 17).Dig(Directions.Down, 2).Dig(Directions.Left, 17).Dig(Directions.Down, 2);
            map.DoorHere();
            return map.Map;
        }

      

        public static Map Level3()
        {
            var map = new MapConstructor(16, 15);
            map = map
                 .Descriptions("Сделайте общий алгоритм для прохождения змейки. Размеры лабиринта возьмите из переменной MapInfo", "Size {0} {1}", map.Map.Width, map.Map.Height)
                 .Fill<Brick>();
            for (int i = 0; i < 3; i++)
                map.Dig(Directions.Right, 13).Dig(Directions.Down, 2).Dig(Directions.Left, 13).Dig(Directions.Down, 2);
            map.DoorHere();
            return map.Map;
        }

        public static Map Level4()
        {
            var map = new MapConstructor(21, 11);
            map = map
                 .Descriptions("Как пройти этот уровень с минимальными усилиями? Размер поля {0} на {1}", null, map.Map.Width, map.Map.Height)
                 .Fill<Brick>()
                 .Dig(Directions.Right, 1);
            for (int i = 0; i < 2; i++)
                map.Dig(Directions.Right, 17).Dig(Directions.Down, 2).Dig(Directions.Left, 17).Dig(Directions.Down, 2);
            map.DoorHere();
            return map.Map;
        }


        public static Map Level5()
        {
            var map = new MapConstructor(22, 11)
                .Descriptions("Как элегантно решить эту задачу с помощью foreach и массивов? Размеры этажей: 5, 2, 7, 5", "Levels 5 2 7 5")
                .Fill<Brick>()
                .Dig(Directions.Right, 5)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Right, 2)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Right, 7)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Right, 5)
                .Dig(Directions.Down, 2)
                .DoorHere();
            return map.Map;
        }

        public static Map Level6()
        {
            var map = new MapConstructor(13, 11)
                .Descriptions("А если так?", "Levels 5 -2 7 -5")
                .Fill<Brick>()
                .Dig(Directions.Right, 5)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Left, 2)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Right, 7)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Left, 5)
                .Dig(Directions.Down, 2)
                .DoorHere();
            return map.Map;
        }

        public static Map Level7()
        {
            var map = new MapConstructor(13, 11)
                .Descriptions("Не нашли ли вы закономерность, которой на самом деле нет?", "Levels 10 -2 -2 -5")
                .Fill<Brick>()
                .Dig(Directions.Right, 10)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Left, 2)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Left, 2)
                .Dig(Directions.Down, 2)
                .Dig(Directions.Left, 5)
                .Dig(Directions.Down, 2)
                .DoorHere();
            return map.Map;
        }



        public static Map Level8()
        {
            var map = new MapConstructor(15, 6);
            map = map
                 .Descriptions("Попробуйте сразу найти взаимосвязь между размерами карты и кодом", "Size {0} {1}", map.Map.Width, map.Map.Height)
                 .Fill<Brick>()
                ;

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

        public static Map Level9()
        {
            var map = new MapConstructor(18, 13);
            map=map
                .Descriptions("Возможно, закономерность сложнее, чем кажется", "Size {0} {1}", map.Map.Width,map.Map.Height)
                .Fill<Brick>()
                ;
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

        public static Map Level10()
        {
            var map = new MapConstructor(21,16);
            map = map
                .Descriptions("Найдите общее решение для произвольного лабиринта такой формы", "Size {0} {1}", map.Map.Width, map.Map.Height)
                .Fill<Brick>()
                .Dig(Directions.Right, 18)
                .Dig(Directions.Down, 13)
                .Dig(Directions.Left, 18)
                .Dig(Directions.Up, 11)
                .Dig(Directions.Right, 16)
                .Dig(Directions.Down, 9)
                .Dig(Directions.Left, 14)
                .Dig(Directions.Up, 7)
                .Dig(Directions.Right, 12)  
                .Dig(Directions.Down, 5)
                .Dig(Directions.Left, 10)
                .Dig(Directions.Up, 3)
                .Dig(Directions.Right, 8)
                .Dig(Directions.Down, 1);

            return map.Map;
        }

        public static Map Level11()
        {
            var map = new MapConstructor(18, 14)
                .Descriptions("В деревянные стены безопасно врезаться. Метод Go возвращает false, если перемещение сделать не получилось. В этом лабиринте надо поворачивать направо, упершись в стену", null)
                .Fill<Wood>()
                .Dig(Directions.Right, 5)
                .Dig(Directions.Down, 7)
                .Dig(Directions.Left, 3)
                .Dig(Directions.Up, 3)
                .Dig(Directions.Right, 7)
                .Dig(Directions.Down, 7)
                .Dig(Directions.Left, 9)
                .Dig(Directions.Up,9)
                .Dig(Directions.Right,15)
                .Dig(Directions.Down, 9)
                .Dig(Directions.Left,4)
                .Dig(Directions.Up,11)
                .Dig(Directions.Right,2)
                .Dig(Directions.Down,9)
                .DoorHere();

            return map.Map;
        }

        public static Map Level12()
        {
            
            var data = new[] { 
                "                              ",
                " XXXXXXXXXXXXXXXXXX XXXXXXX X ",
                "  X   X      X    X X       X ",
                "  X X X XXXX XXXX X X X XXX X ",
                "  X XXX X X  X    X X X X   X ",
                "  X     X X  X XXXX XXX XXXXX ",
                " XXXXXXXX X       X X X X X X ",
                "          X  X XXXXXX XXX X X ",
                "  XXXXXXXXX  X            X X ",
                "  X     X    XXXXXXXXXXXXXX X ",
                "  X XXXXX                 X X ",
                "  X   X X   XXXXXXXXXXXX  X X ",
                "  X   X X           X  XXXX X ",
                "  X       X                 X  ",
                "  XXXXXXXXXXXXXXXXXXXXXXXXX X ",
                "                              ",
            };
            var map = new MapConstructor(data[0].Length, data.Length).Descriptions("А теперь выберетесь из настоящего лабиринта. Это просто - нужно всегда поворачивать в одну и ту же сторону...", null).Map;

            for (int x = 0; x < map.Width; x++)
                for (int y = 0; y < map.Height; y++)
                    map[x, y] = data[y][x] == ' ' ? new Wood() : null;
            map[1, 1] = map.Player;
            map[map.Width - 2, map.Height - 2] = new Door();
            return map;
        }

        //public static Map Level12()
        //{
        //    var map = new MapConstructor(19, 12)
        //        .Descriptions("На первом перекрестке поверните направо, на втором - пройдите прямо, на третьем - налево", null)
        //        .Fill<Wood>()
        //        .Dig(Directions.Right, 14)
        //        .Dig(Directions.Down, 4)
        //        .CrossHere(2)
        //        .Dig(Directions.Left, 6)
        //        .CrossHere(2)
        //        .Dig(Directions.Left, 6)
        //        .CrossHere(2)
        //        .Dig(Directions.Down, 2)
        //        .DoorHere();
        //    return map.Map;

        // }
        public static Map Level13()
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
            map[1, 1] = new Player();
            return map;
        }




    }
}
