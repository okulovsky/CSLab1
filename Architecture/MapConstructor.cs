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
        public MapConstructor(int width, int height)
        {
            map = new Map(width, height);
            this.currentX = 1;
            this.currentY = 1;
            map[currentX, currentY] = map.Player;
        }

        public MapConstructor Descriptions(string descFormat, string infoFormat, params object[] data)
        {
            map.Description = string.Format(descFormat, data);
            if (infoFormat!=null)
                map.MapInfo = string.Format(infoFormat, data);
            return this;
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

        public MapConstructor Fill<T>()
            where T : ICreature, new()
        {
            for (int x = 0; x < map.Width; x++)
                for (int y = 0; y < map.Height; y++)
                    if (map[x,y]==null) map[x, y] = new T();
            return this;
        }

        int currentX;
        int currentY;

       
        
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
                map[nx,ny]=null;
                currentX=nx;
                currentY=ny;
            }
            return this;
        }

        public MapConstructor DoorHere()
        {
            map[currentX, currentY] = new Door();
            return this;
        }
        public Map Map { get { return map;  } }
    }
}