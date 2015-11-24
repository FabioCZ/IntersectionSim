using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph.Collections;

namespace IntersectionSim.Model
{

    internal abstract class Roundabout : ICloneable
    {
        public readonly int NorthIn = 0;
        public readonly int WestOut = 1;
        public readonly int WestIn = 2;
        public readonly int SouthOut = 3;
        public readonly int SouthIn = 4;
        public readonly int EastOut = 5;
        public readonly int EastIn = 6;
        public readonly int NorthOut = 7;

        public List<Car> Circle;
        public List<Car> OuterCircle;
        public List<List<Car>> FinishedCars;
        public List<EntryLane> EntryLanes; 

        public static int SimulationDuration = 60;  //TODO change to bind to field in UI

        public static int CurrTime { get; protected set; }

        public bool SimulationFinished
        {
            get
            {
                if (CurrTime < SimulationDuration) return false;
                for (int i = 0; i < 8; i++)
                {
                    if (Circle[i] != null) return false;
                    if (OuterCircle[i] != null) return false;
                }
                return true;
            }
        }

        protected Roundabout(List<TrafficPattern> patterns)
        {
            if (patterns.Count != 4)
                throw new ArgumentException("Traffic pattern array should have 4 elems");

            FinishedCars = new List<List<Car>>(4)
            {
                new List<Car>(),
                new List<Car>(),
                new List<Car>(),
                new List<Car>()
            };

            EntryLanes = new List<EntryLane>(4)
            {
                new EntryLane(patterns[0]),
                new EntryLane(patterns[1]),
                new EntryLane(patterns[2]),
                new EntryLane(patterns[3])
            };

            Circle = new List<Car>(8);
            OuterCircle = new List<Car>(8);
            for (var i = 0; i < 8; i++)
            {
                Circle.Add(null);
                OuterCircle.Add(null);
            }
            CurrTime = 0;
        }

        public abstract void IterateSimaultion();

        public void RotateCircle()
        {
            var c = Circle[7];
            Circle.RemoveAt(7);
            Circle.Insert(0,c);
        }

        public void UpdateWaitQueues()
        {
            foreach (var entryLane in EntryLanes)
            {
                entryLane.UpdateQueue(CurrTime);
            }
        }

        public object Clone()
        {
            return this.Copy();
        }
    }
}
