using QuickGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    static class Tools
    {
        static Random randomGen = new Random();

        public static float DistanceBetween(LanePoint a, LanePoint b)
        {
            return Convert.ToSingle(Math.Sqrt(Math.Pow((b.X - a.X),2) + Math.Pow((b.Y - a.Y), 2)));
        }

        public static LanePoint PointFromStart(LanePoint from, LanePoint to, float dist)
        {
            var length = DistanceBetween(from, to);
            Tuple<float, float> unitVector = Tuple.Create
                (
                    (to.X - from.X) / length,
                    (to.Y - from.Y) / length
                );
            return new LanePoint(from.X + dist * unitVector.Item1, from.Y + dist * unitVector.Item2);
        }

        public static Brush GetRandomBrush()
        {
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];

            return new SolidBrush(Color.FromKnownColor(randomColorName));
        }

    }
}
