using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class MapConstructor
    {
        Map map;
        public MapConstructor(int width, int height, string description)
        {
            map = new Map(width, height);
            map.Description = description;
        }

        public MapConstructor Frame()
        {
            for (int x = 0; x < map.Width; x++)
            {
                map[x, 0] = new Brick();
                map[x, map.Height - 1] = new Brick();
            }
            for (int y = 0; y < map.Height; y++)
            {
                map[0, y] = new Brick();
                map[map.Width - 1, y] = new Brick();
            }
            return this;
        }

        public MapConstructor Fill()
        {
            for (int x = 0; x < map.Width; x++)
                for (int y = 0; y < map.Height; y++)
                    map[x, y] = new Brick();
            return this;
        }

        int currentX;
        int currentY;

        public MapConstructor PlayFrom(int x, int y)
        {
            this.currentX=x;
            this.currentY=y;
            map[currentX,currentY]=map.Player;
            return this;
        }
        
        public MapConstructor Dig(Directions dir, int count)
        {
            for (int i=0;i<count;i++)
            {
                var nx=currentX;
                var ny=currentY;
                switch(dir)
                    {
                        case Directions.Up: ny--; break;
                        case Directions.Down: ny++; break;
                        case Directions.Left: nx--; break;
                        case Directions.Right: nx++; break;
                    }
                if (nx < 0 || nx >= map.Width) nx = currentX;
                if (ny < 0 || ny >= map.Height) ny = currentY;
                map[nx,ny]=null;
                currentX=nx;
                currentY=ny;
            }
            return this;
        }

        public Map Map { get { return map;  } }
    }
}