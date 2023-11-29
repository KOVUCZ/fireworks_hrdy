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
        }

        public List<rocket> Explode()
        {
            List<rocket> rockets = new List<rocket>();
            if(Level > 0)
            {

            }
            return rockets;
        }
    }
}
