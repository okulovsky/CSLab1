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

    enum MovementRequest
    {
        No,
        Given,
        Taken,
        Processed
    }

	public class DiggerWindow : Form
    {
        const int MessagesWidth = 200;
        const int ElementSize = 32;
        Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        static List<CreatureAnimation> animations = new List<CreatureAnimation>();
        Map map;

        
        

        public DiggerWindow(Map map)
        {
            this.map = map;
            ClientSize = new Size(ElementSize * map.Width + MessagesWidth, ElementSize * map.Height);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Text = "Digger";
            DoubleBuffered = true;

            var imagesDirectory = new DirectoryInfo("..\\..\\Images");
            foreach(var e in imagesDirectory.GetFiles())
                if (e.Extension==".png")
                 bitmaps[e.Name.ToLower()]=(Bitmap)Bitmap.FromFile(e.FullName);
            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += TimerTick;
            timer.Start();
        }

        void Act()
        {
            bool skip = false;
            if (request == MovementRequest.No || request == MovementRequest.Processed)
                skip = true;
            else if (request == MovementRequest.Given)
                request = MovementRequest.Taken;
            else throw new Exception("Wrong request state "+request);

            animations.Clear();
            for (int x = 0; x < map.Width; x++)
                for (int y = 0; y < map.Height; y++)
                {
                    var creature = map[x, y];
                    if (creature == null) continue;
                    CreatureCommand command;
                    if (!map.GameOver && !skip)
                        command = creature.Act(map, x, y);
                    else
                        command = new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = null };
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
            e.Graphics.FillRectangle(Brushes.Black,0,0,ElementSize*map.Width,ElementSize*map.Height);
            foreach(var a in animations)
            {
                var name = a.Creature.GetImageFileName().ToLower();
                if (!bitmaps.ContainsKey(name))
                    Console.WriteLine();
                var bmp=bitmaps[name];
                e.Graphics.DrawImage(bmp,new Rectangle(a.Location.X,a.Location.Y,ElementSize,ElementSize));
            }
                
            e.Graphics.ResetTransform();

            e.Graphics.TranslateTransform(ElementSize*map.Width,0);
            var messages = map.AllMessages.Aggregate((a, b) => a + "\r\n\r\n" + b);
            e.Graphics.DrawString(messages, new Font("Courier", 12), Brushes.Black, new Rectangle(0, 0, MessagesWidth, ClientSize.Width));
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
                if (request == MovementRequest.Taken) request = MovementRequest.Processed;
            }
            Invalidate();
        }

        MovementRequest request;
      
        public bool Go(Directions direction)
        {
            map.Player.RequestedMovement = direction;
            request = MovementRequest.Given;
            while (request!= MovementRequest.Processed) System.Threading.Thread.Sleep(1);
            request = MovementRequest.No;
            return map.Player.SuccessfulMovement;
        }

        public void Autocheck()
        {
            if (map.Solution!=null)
                map.Solution.BeginInvoke(this, null, null);
        }
    }
}
