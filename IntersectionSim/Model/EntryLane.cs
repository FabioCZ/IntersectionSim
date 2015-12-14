using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    public enum EntryPosition { North, West, South, East }
    public class EntryLane
    {
        public  List<Car> CarsToSpawn { get; private set; }
        public List<Car> QueuedCars { get; set; }
        EntryPosition EntryPosition;
        private TrafficPattern Pattern;

        public bool AreCarsWaiting => QueuedCars.Any();

        public string QueuedCarsMin1
        {
            get
            {
                if (QueuedCars.Count == 0) return "+" + 0;
                return "+" + (QueuedCars.Count - 1);
            }
        }

        public EntryLane(TrafficPattern pattern)
        {
            EntryPosition = pattern.Position;
            Pattern = pattern;
            CarsToSpawn = new List<Car>();
            QueuedCars = new List<Car>();
            PopulateCarsToSpawn();
        }

        public Car GetNextCar()
        {
            if (AreCarsWaiting)
            {
                var car = QueuedCars[0];
                QueuedCars.RemoveAt(0);
                return car;
            }
            return null;
        }


        private void PopulateCarsToSpawn()
        {
            var from = EntryPosition;
            var totalCars = (int) (((double) Pattern.CarsPerMin/60)*Roundabout.SimulationDuration);
            for (var i = 0; i < totalCars; i++)
            {
                EntryPosition to;
                var dirInt = Tools.RandomGen.Next(0, 100);
                if (dirInt <= Pattern.ToNorthPerc)
                {
                    to = EntryPosition.North;
                }
                else if (dirInt <= Pattern.ToWestPerc)
                {
                    to = EntryPosition.West;
                }
                else if (dirInt <= Pattern.ToSouthPerc)
                {
                    to = EntryPosition.South;
                }
                else
                {
                    to = EntryPosition.East;
                }

                
                var time = (int) (Roundabout.SimulationDuration*Tools.RandomGen.NextDouble());
                var timeCollisions = from a in CarsToSpawn where a.EntryTime == time select a;
                while (timeCollisions.Any())
                {
                    time = (int)(Roundabout.SimulationDuration * Tools.RandomGen.NextDouble());
                    timeCollisions = from a in CarsToSpawn where a.EntryTime == time select a;
                }

                CarsToSpawn.Add(new Car(time,from,to));
            }
        }

        public void UpdateQueue(int curentTime)
        {
            var carsToAdd = from c in CarsToSpawn where c.EntryTime == curentTime select c;
            var carsToAdd2 = carsToAdd.ToList();
            if (carsToAdd2.Count > 0)
            {
                foreach (var a in carsToAdd2)
                {
                    QueuedCars.Add(a);
                    CarsToSpawn.Remove(a);
                }
            }

        }

        public Car PeekAtQueue()
        {
            if (QueuedCars.Any())
                return QueuedCars[0];
            var nextCarMaybe = from a in CarsToSpawn where a.EntryTime == (Roundabout.MainCurrTime + 2) select a;
            if(nextCarMaybe.Count() > 1)
                throw new Exception("There was a car time collision.");
            if (nextCarMaybe.Count() == 1)
            {
                return nextCarMaybe.Single();
            }
            return null;
        }

        public EntryLane Clone()
        {
            return new EntryLane(this.Pattern.Clone())
            {
                CarsToSpawn = this.CarsToSpawn.Select(e => e.Clone()).ToList(),
                EntryPosition = this.EntryPosition,
                QueuedCars = this.QueuedCars.Select(e => e.Clone()).ToList()

            };
        }
    }
}
