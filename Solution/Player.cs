using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Player : ICreature
    {
        public Directions RequestedMovement { get; set; }
        
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public CreatureCommand Act(Map map, int x, int y)
        {
            int nx=x;
            int ny=y;
            switch(RequestedMovement)
            {
                case Directions.Up: ny--; break;
                case Directions.Down: ny++; break;
                case Directions.Left: nx--; break;
                case Directions.Right: nx++; break;
            }
            if (nx < 0 || nx >= map.Width) nx = x;
            if (ny < 0 || ny >= map.Height) ny = y;
            return new CreatureCommand { DeltaX = nx - x, DeltaY = ny - y, TransformTo = null };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }
    }
}
