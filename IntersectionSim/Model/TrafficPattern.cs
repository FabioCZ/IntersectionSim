using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntersectionSim.Model
{
    public struct TrafficPattern
    {
        public EntryPosition Position;
        public int CarsPerMin;
        public int ToNorthPerc;
        public int ToWestPerc;
        public int ToSouthPerc;
        public int ToEastPerc;

        public TrafficPattern(EntryPosition position, int carsPerMin, int toNorthPerc, int toEastPerc, int toSouthPerc, int toWestPerc)
        {
            Position = position;
            CarsPerMin = carsPerMin;
            ToNorthPerc = toNorthPerc;
            ToEastPerc = toEastPerc;
            ToSouthPerc = toSouthPerc;
            ToWestPerc = toWestPerc;
        }

        public TrafficPattern(EntryPosition position)
        {
            CarsPerMin = 10;
            Position = position;
            switch (Position)
            {
                case EntryPosition.North:
                    ToNorthPerc = 10;
                    ToEastPerc = 30;
                    ToSouthPerc = 30;
                    ToWestPerc = 30;
                    break;
                case EntryPosition.West:
                    ToNorthPerc = 30;
                    ToEastPerc = 30;
                    ToSouthPerc = 30;
                    ToWestPerc = 10;
                    break;
                case EntryPosition.South:
                    ToNorthPerc = 30;
                    ToEastPerc = 30;
                    ToSouthPerc = 10;
                    ToWestPerc = 30;
                    break;
                case EntryPosition.East:
                    ToNorthPerc = 30;
                    ToEastPerc = 10;
                    ToSouthPerc = 30;
                    ToWestPerc = 30;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ToWestPerc += ToNorthPerc;
            ToSouthPerc += ToWestPerc;
            ToEastPerc += ToSouthPerc;
            if (ToEastPerc != 100)
            {
                MessageBox.Show($"Percentages don't add up to 100 for {position}");
                throw new ArgumentOutOfRangeException($"Percentages don't add up to 100 for {position}");
            }
        }

        public TrafficPattern Clone()
        {
            return new TrafficPattern(this.Position)
            {
                CarsPerMin = this.CarsPerMin,
                ToNorthPerc = this.ToNorthPerc,
                ToWestPerc = this.ToWestPerc,
                ToSouthPerc = this.ToSouthPerc,
                ToEastPerc = this.ToEastPerc
            };
        }
    }
}
