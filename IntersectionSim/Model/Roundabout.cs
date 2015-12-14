using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{

    public abstract class Roundabout
    {
        public static int MainCurrTime { get; protected set; }
        public static int SimulationDuration;


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

        public bool IsMainSimulation;

        private int _ownCurrTime;
        public int OwnCurrTime
        {
            get { return _ownCurrTime; }
            set
            {
                _ownCurrTime = value;
                if (IsMainSimulation)
                {
                    MainCurrTime = _ownCurrTime;
                }
            }
        }

        public bool SimulationFinished
        {
            get
            {
                if (OwnCurrTime < SimulationDuration) return false;
                for (int i = 0; i < 8; i++)
                {
                    if (Circle[i] != null) return false;
                    if (OuterCircle[i] != null) return false;
                }
                return true;
            }
        }

        protected Roundabout()
        {

        }

        public void Init(List<TrafficPattern> patterns)
        {
            IsMainSimulation = true;
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
            MainCurrTime = 0;
            OwnCurrTime = 0;
        }

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
                entryLane.UpdateQueue(OwnCurrTime);
            }
        }

        public List<Car> GetAllCarsOnRoundabout()
        {
            List<Car> allCars = new List<Car>();
            allCars.AddRange(Circle.Where(e => e != null));
            allCars.AddRange(OuterCircle.Where(e => e != null));
            foreach (var a in EntryLanes)
            {
                allCars.AddRange(a.QueuedCars);
            }
            return allCars;
        }

        public IntelligentRoundabout CloneToIntl()
        {
            return new IntelligentRoundabout()
            {
                _ownCurrTime = this.OwnCurrTime,
                Circle = this.Circle.Select(e => e?.Clone()).ToList(),
                EntryLanes = this.EntryLanes.Select(e => e?.Clone()).ToList(),
                FinishedCars = this.FinishedCars.Select(e => e?.Select(f => f?.Clone()).ToList()).ToList(),
                IsMainSimulation = false,
                OuterCircle = this.OuterCircle.Select(e => e?.Clone()).ToList(),
            };
        }

        public ConventionalRoundabout CloneToConv()
        {
            return new ConventionalRoundabout()
            {
                _ownCurrTime = this.OwnCurrTime,
                Circle = this.Circle.Select(e => e?.Clone()).ToList(),
                EntryLanes = this.EntryLanes.Select(e => e?.Clone()).ToList(),
                FinishedCars = this.FinishedCars.Select(e => e?.Select(f => f?.Clone()).ToList()).ToList(),
                IsMainSimulation = false,
                OuterCircle = this.OuterCircle.Select(e => e?.Clone()).ToList(),
            };
        }

        public double GetAvgWaitTimeForFinished()
        {
            var allCars = new List<Car>();
            for (int i = 0; i < 4; i++)
            {
                allCars.AddRange(FinishedCars[i]);
            }
            return allCars.Average(e => e.TimeWaiting);
        }

        public double GetMaxWaitTime()
        {
            var allCars = new List<Car>();
            for (int i = 0; i < 4; i++)
            {
                allCars.AddRange(FinishedCars[i]);
            }
            return allCars.Max(e => e.TimeWaiting);
        }
    }
}
