using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    class ConventionalRoundabout : Roundabout
    {
        public ConventionalRoundabout(List<TrafficPattern> patterns) : base(patterns)
        {
        }

        public override void IterateSimaultion()
        {
            CurrTime++;
            UpdateWaitQueues();

            //pop cars that are done
            if (Circle[NorthOut]?.To == EntryPosition.North)
            {
                Circle[NorthOut].ExitTime = CurrTime + 1;
                FinishedCars[(int)EntryPosition.North].Add(Circle[NorthOut]);
                Circle[NorthOut] = null;
            }
            if (Circle[WestOut]?.To == EntryPosition.West)
            {
                Circle[WestOut].ExitTime = CurrTime + 1;
                FinishedCars[(int)EntryPosition.North].Add(Circle[WestOut]);
                Circle[WestOut] = null;
            }
            if (Circle[SouthOut]?.To == EntryPosition.South)
            {
                Circle[SouthOut].ExitTime = CurrTime + 1;
                FinishedCars[(int)EntryPosition.North].Add(Circle[SouthOut]);
                Circle[SouthOut] = null;
            }
            if (Circle[EastOut]?.To == EntryPosition.East)
            {
                Circle[EastOut].ExitTime = CurrTime + 1;
                FinishedCars[(int)EntryPosition.North].Add(Circle[EastOut]);
                Circle[EastOut] = null;
            }

            //Add new cars from entry lanes
            if (Circle[NorthOut] == null && EntryLanes[(int)EntryPosition.North].AreCarsWaiting)
            {
                Circle[NorthOut] = EntryLanes[(int) EntryPosition.North].NextCar;
            }
            if (Circle[WestOut] == null && EntryLanes[(int)EntryPosition.West].AreCarsWaiting)
            {
                Circle[WestOut] = EntryLanes[(int)EntryPosition.West].NextCar;
            }
            if (Circle[SouthOut] == null && EntryLanes[(int)EntryPosition.South].AreCarsWaiting)
            {
                Circle[SouthOut] = EntryLanes[(int)EntryPosition.South].NextCar;
            }
            if (Circle[EastOut] == null && EntryLanes[(int)EntryPosition.East].AreCarsWaiting)
            {
                Circle[EastOut] = EntryLanes[(int)EntryPosition.East].NextCar;
            }

            //Rotate Roundabout
            RotateCircle();


        }
    }
}
