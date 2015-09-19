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

        public ICreature this[int x, int y]
        {
            get { return Elements[x, y]; }
            set { Elements[x, y] = value; }
        }
        
       public Map(int width, int height)
        {
            Elements = new ICreature[width, height];
        }

    }
}
