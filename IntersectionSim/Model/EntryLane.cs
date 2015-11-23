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
        private  List<Car> CarsToSpawn;
        private Queue<Car> QueuedCars;
        EntryPosition EntryPosition;
        private TrafficPattern Pattern;

        public bool AreCarsWaiting => QueuedCars.Any();

        public Car NextCar => QueuedCars.Dequeue();

        public EntryLane(TrafficPattern pattern)
        {
            EntryPosition = pattern.Position;
            Pattern = pattern;
            CarsToSpawn = new List<Car>();
            QueuedCars = new Queue<Car>();
            PopulateCarsToSpawn();
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
                    QueuedCars.Enqueue(a);
                    CarsToSpawn.Remove(a);
                }
            }

        }

        public Car PeekAtQueue()
        {
            if (QueuedCars.Any())
                return QueuedCars.Peek();
            var nextCarMaybe = from a in CarsToSpawn where a.EntryTime == (Roundabout.CurrTime + 2) select a;
            if(nextCarMaybe.Count() > 1)
                throw new Exception("There was a car time collision.");
            if (nextCarMaybe.Count() == 1)
            {
                return nextCarMaybe.Single();
            }
            return null;
        }
    }
}
