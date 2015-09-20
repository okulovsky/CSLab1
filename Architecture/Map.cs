using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    public class Map
    {

        public ICreature[,] Elements;
        public int Width { get { return Elements.GetLength(0); } }
        public int Height { get { return Elements.GetLength(1); } }

        public int LevelNumber { get; set; }

        public ICreature this[int x, int y]
        {
            get { return Elements[x, y]; }
            set { Elements[x, y] = value; }
        }

        public Player Player { get; private set;  }

        public string Description { get; set; }

        public string MapInfo { get; set; }

        public bool GameOver { get; set; }

        public List<string> Messages { get; private set; }

        public IEnumerable<string> AllMessages
        {
            get
            {
                yield return Description;
                if (MapInfo != null)
                    yield return "MapInfo: " + MapInfo;
                foreach (var e in Messages) yield return e;
            }
        }

        public Action<DiggerWindow> Solution { get; set; }

       public Map(int width, int height)
       {
            Elements = new ICreature[width, height];
            Player = new Player();
            Messages = new List<string>();
       }

    }
}
