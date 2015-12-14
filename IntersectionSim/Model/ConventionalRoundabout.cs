using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    public class ConventionalRoundabout : Roundabout
    {
        public ConventionalRoundabout()
        {
        }

        public void IterateSimaultion()
        {
            OwnCurrTime++;
            //Rotate Roundabout

            //pop off finished cars
            for (int i = 0; i < 4; i++)
            {
                int helperIndex = i == 3 ? 0 : i + 1;
                if (Circle[(i *2) + 1]?.To == (EntryPosition)helperIndex)
                {
                    Circle[(i * 2) + 1].ExitTime = OwnCurrTime;
                    FinishedCars[i].Add(Circle[(i *2) + 1]);
                    Circle[(i * 2) + 1] = null;
                }
            }
            RotateCircle();

            //insert cars into roundabout
            for (int i = 0; i < 4; i++)
            {
                if (EntryLanes[i].AreCarsWaiting && Circle[i*2] == null)
                {
                    Circle[i*2] = EntryLanes[i].GetNextCar();
                }
                else if(EntryLanes[i].AreCarsWaiting)
                {

                    EntryLanes[i].QueuedCars.ForEach(e => e.TimeWaiting++);
                }
            }
            UpdateWaitQueues();


            for (int i = 0; i < 4; i++)
            {
                //add cars from queue to outer circle

                if (EntryLanes[i].AreCarsWaiting)
                {
                    OuterCircle[i*2] = EntryLanes[i].PeekAtQueue();
                }
                else
                {
                    OuterCircle[i*2] = null;
                }

                //add finished cars to outer circle
                if (FinishedCars[i].Any() && FinishedCars[i].Last().ExitTime == OwnCurrTime)
                {
                    OuterCircle[(i*2) + 1] = FinishedCars[i].Last();
                }
                else
                {
                    OuterCircle[(i*2) + 1] = null;
                }
            }
        }

        public void IterateWithoutNewCars()
        {
            OwnCurrTime++;
            //Rotate Roundabout

            //pop off finished cars
            for (int i = 0; i < 4; i++)
            {
                int helperIndex = i == 3 ? 0 : i + 1;
                if (Circle[(i * 2) + 1]?.To == (EntryPosition)helperIndex)
                {
                    Circle[(i * 2) + 1].ExitTime = OwnCurrTime;
                    FinishedCars[i].Add(Circle[(i * 2) + 1]);
                    Circle[(i * 2) + 1] = null;
                }
            }
            RotateCircle();

            //insert cars into roundabout
            for (int i = 0; i < 4; i++)
            {
                if (EntryLanes[i].AreCarsWaiting && Circle[i * 2] == null)
                {
                    Circle[i * 2] = EntryLanes[i].GetNextCar();
                }
                else if (EntryLanes[i].AreCarsWaiting)
                {

                    EntryLanes[i].QueuedCars[0].TimeWaiting++;
                }
            }
            //UpdateWaitQueues();


            for (int i = 0; i < 4; i++)
            {
                //add cars from queue to outer circle

                if (EntryLanes[i].AreCarsWaiting)
                {
                    OuterCircle[i * 2] = EntryLanes[i].PeekAtQueue();
                }
                else
                {
                    OuterCircle[i * 2] = null;
                }

                //add finished cars to outer circle
                if (FinishedCars[i].Any() && FinishedCars[i].Last().ExitTime == OwnCurrTime)
                {
                    OuterCircle[(i * 2) + 1] = FinishedCars[i].Last();
                }
                else
                {
                    OuterCircle[(i * 2) + 1] = null;
                }
            }
        }
    }
}
