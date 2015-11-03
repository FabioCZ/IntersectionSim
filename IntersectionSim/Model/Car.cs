using QuickGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    class Car
    {
        public float Speed; //meters per 100 ms
        public LanePoint Start;
        public LanePoint End;
        public int SpawnTime;
        public bool HasSpawned;
        public bool CarFinished;
        public IEnumerable<Edge<LanePoint>> TargetPath;
        private Edge<LanePoint> CurrentEdge;
        private int currEdgeIndex;
        public Dictionary<int, LanePoint> LocationHistory;
        public Brush color;

        public Car(IEnumerable<Edge<LanePoint> > targetPath, int spawnTime)
        {
            TargetPath = targetPath;
            Start = TargetPath.First().Source;
            End = TargetPath.Last().Target;
            SpawnTime = spawnTime;
            LocationHistory = new Dictionary<int, LanePoint>();
            Speed = 1;
            CarFinished = false;
            color = Tools.GetRandomBrush();
        }

        public void UpdateCar(int time)
        {
            if(time >= SpawnTime && !CarFinished)
            {
                //starting
                if(time == SpawnTime)
                {
                    currEdgeIndex = 0;
                    LocationHistory.Add(time, Start);
                    CurrentEdge = TargetPath.ElementAt(currEdgeIndex);
                    return;
                }

                //crossing between edges
                if(Tools.DistanceBetween(LocationHistory.Last().Value, CurrentEdge.Target) < Speed)
                {
                    if(TargetPath.Count() - 1 == currEdgeIndex)
                    {
                        LocationHistory.Add(time, CurrentEdge.Target);
                        CarFinished = true;
                        return;
                    }
                    else
                    {
                        var distOnNewEdge = Speed - Tools.DistanceBetween(LocationHistory.Last().Value, CurrentEdge.Target);
                        CurrentEdge = TargetPath.ElementAt(++currEdgeIndex);
                    }
                }

                    var newPoint = Tools.PointFromStart(LocationHistory.Last().Value, CurrentEdge.Target, Speed);
                    LocationHistory.Add(time, newPoint);
            }
        }




    }
}
