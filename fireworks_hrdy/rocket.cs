using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace fireworks_hrdy
{
    internal class rocket
    {
        public Vector gravity { get; } = new Vector(0, 10); 
        public Point Location { get; set; }
        public Vector SpeedVector { get; set; }
        public int Level { get; set; }
        private int countdown = 60;
        
        public event Action<List<rocket>>? Exploded;

        public rocket(Point location, Vector speedVector, int level)
        {
            Location = location;
            SpeedVector = speedVector;
            Level = level;
              
        }



        public void Move()
        {
            Location.Offset(SpeedVector.X, SpeedVector.Y);
            SpeedVector = Vector.Add(SpeedVector, gravity);
            countdown--;
            if (countdown < 0) 
            {
                Exploded?.Invoke(Explode());
            }
        }

        public List<rocket> Explode()
        {
            List<rocket> rockets = new List<rocket>();
            if(Level > 0)
            {
                int count = 10;
                int angle = 360 / count;

                for(int i = 0; i < 10; i++)
                {
                    Vector v = new Vector(Math.Cos(i*angle),Math.Sin(i*angle));
                    rocket rocket = new rocket(Location, v, Level - 1);
                }
            }
            return rockets;
        }
    }
}
