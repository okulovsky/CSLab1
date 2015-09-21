using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    class Wood : ICreature
    {
        public string GetImageFileName()
        {
            return "wood.png";
        }

        public int GetDrawingPriority()
        {
            return 3;
        }
        public CreatureCommand Act(Map map, int x, int y)
        {
            return new CreatureCommand
            {
                DeltaX = 0,
                DeltaY = 0,
            };

        }


        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
    }
}
