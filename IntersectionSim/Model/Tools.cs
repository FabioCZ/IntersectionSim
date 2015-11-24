using QuickGraph;
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

    }
}
