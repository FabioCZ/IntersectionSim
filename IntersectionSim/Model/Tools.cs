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
        public  static Random RandomGen = new Random();
        private static int _carCt = 0;

        public static string NexCarId
        {
            get
            {
                _carCt++;
                return _carCt.ToString();
            }
        }
        public static Brush GetRandomBrush()
        {
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[RandomGen.Next(names.Length)];

            return new SolidBrush(Color.FromKnownColor(randomColorName));
        }

    }
}
