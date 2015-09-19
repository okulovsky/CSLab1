using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    class Sack : ICreature
    {
        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        bool falling = false;

        public bool Free(int x, int y)
        {
            if (y >= Game.MapHeight) return false;
            if (Game.Map[x, y] == null) return true;
            var tp=Game.Map[x, y ];
            if (tp is Terrain) return false;
            if (!falling && (tp is Player)) return false;
            return true;

        }

        static CreatureCommand Lay()
        {
            return new CreatureCommand
            {
                DeltaX = 0,
                DeltaY = 0,
            };
        }

        static CreatureCommand Fall()
        {
            return new CreatureCommand
            {
                DeltaX = 0,
                DeltaY = 1,
            };
        }

        static CreatureCommand Break()
        {
            return new CreatureCommand
            {
                DeltaX = 0,
                DeltaY = 0,
                TransformTo = new Gold()
            };
        }

        public CreatureCommand Act(int x, int y)
        {
            if (!falling)
            {
                if (!Free(x, y + 1)) return Lay();
            }
            falling = true;
            if (!Free(x, y + 1)) return Break();
            return Fall();
            

        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

    }
}
