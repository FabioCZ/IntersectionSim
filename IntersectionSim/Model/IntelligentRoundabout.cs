using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IntersectionSim.Model;

namespace IntersectionSim.Model
{
    public enum ConflictResolution { OnCarFirst, WaitingCarFirst }
    public class IntelligentRoundabout : Roundabout
    {

        public IntelligentRoundabout()
        {
        }

        /// <summary>
        /// This implements the MiniMax algorithm.
        /// </summary>
        /// <returns></returns>
        private Tuple<double,IntelligentRoundabout> GetBestNextOption()
        {
            var allCars = GetAllCarsOnRoundabout();
            if (allCars.Count == 0)
                return Tuple.Create(0.0,GetPossibleSolutionsForNextIter(this).First());

            var sols = GetPossibleSolutionsForNextIter(this);
            var bestMetric = double.MaxValue;
            IntelligentRoundabout bestSol = null;
            foreach (var sol in sols)
            {
                var copy = sol.CloneToConv();
                while (copy.GetAllCarsOnRoundabout().Count != 0)
                {
                    copy.IterateWithoutNewCars();
                }

                var thisSolVal = copy.GetAvgWaitTimeForFinished();
                if (thisSolVal < bestMetric)
                {
                    bestMetric = thisSolVal;
                    bestSol = sol;
                }
            }
            if(bestSol == null) throw new Exception("Did not find any solution better than infinity??");
            return Tuple.Create(bestMetric, bestSol);
        }

        public IntelligentRoundabout GetBestNextOptionMain()
        {
            var a = GetBestNextOption();
            var r = a.Item2;
            r.IsMainSimulation = true;
            r.OwnCurrTime = r.OwnCurrTime;
            foreach (var i in r.EntryLanes)
            {
                var b =  i.CarsToSpawn.Where(e => e.EntryTime == r.OwnCurrTime);
                Debug.WriteLine($"{r.OwnCurrTime}: {b.Count()}");
            }
            return r;
        }


        public List<IntelligentRoundabout> GetPossibleSolutionsForNextIter(Roundabout roundaboutState)
        {
            var conflicts = FindConflictPoints();
            switch (conflicts.Count)
            {
                case 0:
                    return new List<IntelligentRoundabout>() { GetStateWithParams(new Dictionary<int, ConflictResolution>()) };
                case 1:
                    return new List<IntelligentRoundabout>()
                    {
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>(){ {conflicts[0],ConflictResolution.OnCarFirst} })

                    };
                case 2:
                    return new List<IntelligentRoundabout>()
                    {
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>(){ {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>(){ {conflicts[0],ConflictResolution.OnCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>(){ {conflicts[0],ConflictResolution.OnCarFirst},{conflicts[1],ConflictResolution.OnCarFirst} })
                    };
                case 3:
                    return new List<IntelligentRoundabout>()
                    {
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.OnCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.OnCarFirst},{conflicts[2],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.OnCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.OnCarFirst},{conflicts[2],ConflictResolution.OnCarFirst} }),
                    };
                case 4:
                    return new List<IntelligentRoundabout>()
                    {
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.OnCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.OnCarFirst },{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.OnCarFirst },{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.WaitingCarFirst},{conflicts[1],ConflictResolution.OnCarFirst },{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }),

                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst},{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.WaitingCarFirst},{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.OnCarFirst},{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.OnCarFirst },{conflicts[2],ConflictResolution.WaitingCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.OnCarFirst },{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.WaitingCarFirst} }),
                        GetStateWithParams(new Dictionary<int, ConflictResolution>() { {conflicts[0],ConflictResolution.OnCarFirst },{conflicts[1],ConflictResolution.OnCarFirst },{conflicts[2],ConflictResolution.OnCarFirst},{conflicts[3],ConflictResolution.OnCarFirst} }), };
                default:
                    throw new Exception("Error getting possible solutions: invalid number of conflict points;");
            }
        }

        public IntelligentRoundabout GetStateWithParams(Dictionary<int, ConflictResolution> resolutions)
        {
            var round = this.CloneToIntl();
            round.OwnCurrTime++;
            for (int i = 0; i < 4; i++)
            {
                int helperIndex = i == 3 ? 0 : i + 1;
                if (round.Circle[(i * 2) + 1]?.To == (EntryPosition)helperIndex)
                {
                    round.Circle[(i * 2) + 1].ExitTime = round.OwnCurrTime;
                    round.FinishedCars[i].Add(round.Circle[(i * 2) + 1]);
                    round.Circle[(i * 2) + 1] = null;
                }
            }
            //round.RotateCircle();
            var waits = Enumerable.Repeat(false, 8).ToList();
            foreach (var kv in resolutions.Where(kv => kv.Value == ConflictResolution.WaitingCarFirst))
            {
                var keyHelper = kv.Key == 0 ? 7 : (kv.Key*2) - 1;
                waits[keyHelper] = true;
            }
            round.RotateWithWaits(waits);
            foreach (var kv in resolutions)
            {
                if (kv.Value == ConflictResolution.WaitingCarFirst)
                {
                    round.Circle[kv.Key * 2] = round.EntryLanes[kv.Key].GetNextCar();
                }
                else
                {
                    round.OuterCircle[kv.Key*2].TimeWaiting++;
                    round.EntryLanes[kv.Key].QueuedCars.ForEach(e => e.TimeWaiting++);
                }
            }

            //insert cars into roundabout
            for (int i = 0; i < 4; i++)
            {
                if (resolutions.ContainsKey(i)) continue;   //this is a conflict resolved above
                if (round.EntryLanes[i].AreCarsWaiting && round.Circle[i * 2] == null)
                {
                    round.Circle[i * 2] = round.EntryLanes[i].GetNextCar();
                }
                else if (round.EntryLanes[i].AreCarsWaiting)
                {

                    round.EntryLanes[i].QueuedCars[0].TimeWaiting++;
                }
            }
            round.UpdateWaitQueues(); //TODO figure out if we want this or not


            for (int i = 0; i < 4; i++)
            {
                //add cars from queue to outer circle

                if (round.EntryLanes[i].AreCarsWaiting)
                {
                    round.OuterCircle[i * 2] = round.EntryLanes[i].PeekAtQueue();
                }
                else
                {
                    round.OuterCircle[i * 2] = null;
                }

                //add finished cars to outer circle
                if (round.FinishedCars[i].Any() && round.FinishedCars[i].Last().ExitTime == round.OwnCurrTime)
                {
                    round.OuterCircle[(i * 2) + 1] = round.FinishedCars[i].Last();
                }
                else
                {
                    round.OuterCircle[(i * 2) + 1] = null;
                }
            }
            return round;
        }

        public void RotateWithWaits(List<bool> waiting)
        {
            if (waiting.Count(e => !e) == 8)
            {
                RotateCircle();
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                if (!WillWait(waiting, i) && Circle[i] != null)
                {
                    var car = Circle[i];
                    Circle[i] = null;
                    var indexPlusOne = i == 7 ? 0 : i + 1;
                    if (Circle[indexPlusOne] != null)
                        throw new Exception("You screwed up.");
                    Circle[indexPlusOne] = car;
                }
                else
                {
                    if(Circle[i] != null)
                        Circle[i].TimeWaiting++;
                }
            }
        }

        public bool WillWait(List<bool> waiting, int index)
        {
            if (Circle[index] == null)
                return false;
            var indexPlusOne = index == 7 ? 0 : index + 1;
            if (waiting[index] || waiting[indexPlusOne])
                return true;
            if (Circle[indexPlusOne] == null && !WillWait(waiting, indexPlusOne))
                return false;
            return true;
        }

        public List<int> FindConflictPoints()
        {
            var points = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                var helperIndex = i == 0 ? 7 : (i*2) - 1;
                if (EntryLanes[i].AreCarsWaiting && Circle[helperIndex] != null && Circle[helperIndex].To != (EntryPosition)i)
                {
                    points.Add(i);
                }
            }
            return points;
        }

        /// <summary>
        /// Uses median. The lower the better.
        /// </summary>
        /// <param name="roundabout"></param>
        /// <returns></returns>
        public int WaitTimeMetric(Roundabout roundabout)
        {
            var allCars = GetAllCarsOnRoundabout();

            if (allCars.Count == 0) return 0;
            var ordered = allCars.OrderBy(e => e.TimeWaiting);
            var median = ordered.ToArray()[ordered.Count() / 2];
            return median.TimeWaiting;
        }




    }
}
