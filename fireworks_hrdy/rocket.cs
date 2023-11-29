using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace fireworks_hrdy
{
    internal class rocket
    {
        public Vector gravity { get; } = new Vector(0, 10); 
        public Point Location { get; set; }
        public Vector SpeedVector { get; set; }



        public void Move()
        {
            Location.Offset(SpeedVector.X, SpeedVector.Y);
            SpeedVector = Vector.Add(SpeedVector, gravity);
        }

        public void Explode()
        {

        }
    }
}
