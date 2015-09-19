using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    class Gold : ICreature
    {

        public string GetImageFileName()
        {
            return "Gold.png";
        }
        public int GetDrawingPriority()
        {
            return 1;
        }
        public CreatureCommand Act(int x, int y)
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
