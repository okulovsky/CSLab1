using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
	public class DiggerWindow : Form
    {
        const int ElementSize = 32;
        Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        static List<CreatureAnimation> animations = new List<CreatureAnimation>();
        Map map;
        

        public DiggerWindow(Map map)
        {
            this.map = map;
            ClientSize = new Size(ElementSize * map.Width, ElementSize * map.Height + ElementSize);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Text = "Digger";
            DoubleBuffered = true;

            var imagesDirectory = new DirectoryInfo("Images");
            foreach(var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name]=(Bitmap)Bitmap.FromFile(e.FullName);
            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += TimerTick;
            timer.Start();
        }

        void Act()
        {
            animations.Clear();
            for (int x = 0; x < map.Width; x++)
                for (int y = 0; y < map.Height; y++)
                {
                    var creature = map[x, y];
                    if (creature == null) continue;
                    var command = creature.Act(map,x,y);
                    animations.Add(new CreatureAnimation
                    {
                        Command=command,
                        Creature = creature,
                        Location = new Point(x * ElementSize, y * ElementSize)
                    });
                }
            animations = animations.OrderByDescending(z => z.Creature.GetDrawingPriority()).ToList();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0,ElementSize);
            e.Graphics.FillRectangle(Brushes.Black,0,0,ElementSize*map.Width,ElementSize*map.Height);
            foreach(var a in animations)
                e.Graphics.DrawImage(bitmaps[a.Creature.GetImageFileName()],a.Location);
            e.Graphics.ResetTransform();
        }

        int tickCount = 0;

        void TimerTick(object sender, EventArgs args)
        {
            if (tickCount == 0) Act();
            foreach (var e in animations)
                e.Location = new Point(e.Location.X + 4*e.Command.DeltaX, e.Location.Y + 4*e.Command.DeltaY);
            if (tickCount==7)
            {
                for (int x=0;x<map.Width;x++) for (int y=0;y<map.Height;y++) map[x,y]=null;
                foreach(var e in animations)
                {
                    var x=e.Location.X/32;
                    var y=e.Location.Y/32;
                    var nextCreature = e.Command.TransformTo == null ? e.Creature : e.Command.TransformTo;
                    if (map[x, y] == null) map[x, y] = nextCreature;
                    else
                    {
                        bool newDead = nextCreature.DeadInConflict(map[x, y]);
                        bool oldDead = map[x, y].DeadInConflict(nextCreature);
                        if (newDead && oldDead)
                            map[x, y] = null;
                        else if (!newDead && oldDead)
                            map[x, y] = nextCreature;
                        else if (!newDead && !oldDead)
                            throw new Exception(string.Format("Существа {0} и {1} претендуют на один и тот же участок карты", nextCreature.GetType().Name, map[x, y].GetType().Name));
                    }
                }
            }
            tickCount++;
            if (tickCount == 8)
            {
                tickCount = 0;
                turnOver = true;
            }
            Invalidate();
        }

        bool turnOver = false;
      
        public void Go(Directions direction)
        {
            map.Player.RequestedMovement = direction;
            while (!turnOver) System.Threading.Thread.Sleep(1);
            turnOver = false;
            map.Player.RequestedMovement = Directions.None;
        }

        public void Autocheck()
        {
            if (map.Solution!=null)
                map.Solution.BeginInvoke(this, null, null);
        }
    }
}
