
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static int IntVal(this NumericUpDown a) => (int)a.Value;

        public static Brush GetRandomBrush()
        {
            //KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            //KnownColor randomColorName = names[RandomGen.Next(names.Length)];
            //while (randomColorName == KnownColor.InactiveCaptionText || randomColorName == KnownColor.InfoText || randomColorName == KnownColor.Black || randomColorName == KnownColor.Beige)
            //{
            //    names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            //    randomColorName = names[RandomGen.Next(names.Length)];
            //    new SolidBrush(Color.FromKnownColor(randomColorName))
            //}
            //return new SolidBrush(Color.FromKnownColor(randomColorName));
            
            var R = RandomGen.Next(0, 255);
            var G = RandomGen.Next(0, 255);
            var B = RandomGen.Next(0, 255);
            while (R < 20 && G < 20 && B < 20)
            {
                R = RandomGen.Next(0, 255);
                G = RandomGen.Next(0, 255);
                B = RandomGen.Next(0, 255);
            }
            return new SolidBrush(Color.FromArgb(R,G,B));
        }

        /// <summary>
        /// Gets the random int in range.
        /// </summary>
        /// <returns>The random int in range.</returns>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static int GetRandomIntInRange(int min, int max)
        {
            return RandomGen.Next((max - min) + 1) + min;
        }

        public static Tuple<int, int, int, int> GetRandomDestinations()
        {
            int n = GetRandomIntInRange(10, 32);
            int w = GetRandomIntInRange(10, 32);
            int s = GetRandomIntInRange(10, 32);
            int e = 100 - n - w - s;
            return Tuple.Create(n, w, s, e);
        }

    }
}
