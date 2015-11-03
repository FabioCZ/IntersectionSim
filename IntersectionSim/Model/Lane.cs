using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    class Lane
    {
        public LanePoint From;
        public LanePoint To;

        decimal Length
        {
            get
            {
                return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(
                    (To.X - From.X) * (To.X - From.X) + (To.Y - From.Y) * (To.Y - From.Y)
                    )));
            }
        }

        public Lane(float fromX, float fromY, float toX, float toY)
        {
            From = new LanePoint(fromX, fromY);
            To = new LanePoint(toX, toY);
        }

        public Lane(LanePoint from, LanePoint to)
        {
            From = new LanePoint(from.X, from.Y);
            To = new LanePoint(to.X,to.Y);
        }


    }
}
