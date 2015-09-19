using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Digger
{
    class Player : ICreature
    {

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }


        public CreatureCommand Act(int x, int y)
        {
            var cmd= new CreatureCommand();
            if (Keyboard.IsKeyDown(Key.Up)) cmd.DeltaY = -1; 
            if (Keyboard.IsKeyDown(Key.Down)) cmd.DeltaY = 1; 
            if (Keyboard.IsKeyDown(Key.Left)) cmd.DeltaX = -1;
            if (Keyboard.IsKeyDown(Key.Right)) cmd.DeltaX = 1;
            return cmd;
        }


        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Sack) return true;
            return false;
        }
    }
}
