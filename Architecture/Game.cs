using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    public class Game
    {

        public static ICreature[,] Map;
        public static int MapWidth;
        public static int MapHeight;
        public static int Scores;
        public static bool IsOver;


        public static void CreateMap()
        {
            //TODO: Инициализируйте здесь карту
            MapWidth = 20;
            MapHeight = 20;
            Map = new ICreature[MapWidth, MapHeight];
            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                    Map[x, y] = new Terrain();
            Map[0, 0] = new Player();

            Map[1, 10] = new Sack();
        }

    }
}
