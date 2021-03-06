﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Player : ICreature
    {
        public Directions RequestedMovement { get; set; }

       public  bool SuccessfulMovement { get; set; }
        
        public string GetImageFileName()
        {
            return "digger.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public CreatureCommand Act(Map map, int x, int y)
        {
            SuccessfulMovement = true;
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

            if (map[nx,ny] is Brick)
            {
                map.Messages.Add("Вы расшиблись о стену");
                map.GameOver = true;
                SuccessfulMovement = false;
            }
            if (map[nx,ny] is Door)
            {
                map.Messages.Add("Вы прошли уровень");
                File.WriteAllText("level.txt", (map.LevelNumber + 1).ToString());
                map.GameOver = true;
            }
            if (map[nx,ny] is Wood)
            {
                SuccessfulMovement = false;
                nx = x;
                ny = y;
            }



            return new CreatureCommand { DeltaX = nx - x, DeltaY = ny - y, TransformTo = null };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }
    }
}
