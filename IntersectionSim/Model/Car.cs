using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    public class Car
    {
        public string Id { get; private set; }
        public int EntryTime { get; private set; }
        public int ExitTime { get; set; }

        public Brush Color { get; private set; }
        public EntryPosition From { get; private set; }
        public EntryPosition To { get; private set; }

        public Car(int entryTime, EntryPosition from, EntryPosition to)
        {
            Id = Tools.NexCarId;
            EntryTime = entryTime;
            From = from;
            To = to;
            Color = Tools.GetRandomBrush();
        }

    }
}
