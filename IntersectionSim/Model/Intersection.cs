using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Algorithms;

namespace IntersectionSim.Model
{
    class Intersection
    {
        public LanePoint a = new LanePoint(5.0f, 110.0f);
        LanePoint b = new LanePoint(100.0f, 110.0f);
        LanePoint c = new LanePoint(130.0f, 110.0f);
        public LanePoint d = new LanePoint(225.0f, 110.0f);

        LanePoint e = new LanePoint(225.0f, 100.0f);
        LanePoint f = new LanePoint(130.0f, 100.0f);
        LanePoint g = new LanePoint(100.0f, 100.0f);
        LanePoint h = new LanePoint(5.0f, 100.0f);

        LanePoint i = new LanePoint(110.0f, 5.0f);
        LanePoint j = new LanePoint(110.0f, 90.0f);
        LanePoint k = new LanePoint(110.0f, 120.0f);
        LanePoint l = new LanePoint(110.0f, 200.0f);

        LanePoint m = new LanePoint(120.0f, 200.0f);
        LanePoint n = new LanePoint(120.0f, 120.0f);
        LanePoint o = new LanePoint(120.0f, 90.0f);
        LanePoint p = new LanePoint(120.0f, 5.0f);

        public List<Car> Cars;
        public AdjacencyGraph<LanePoint, Edge<LanePoint> > IntersectionGraph;

        //Other fields
        public int CurrentTime;
        public int FinishTime;

 
        public Intersection()
        {
            CurrentTime = 0;
            IntersectionGraph = new AdjacencyGraph<LanePoint, Edge<LanePoint>>();
            IntersectionGraph.AddVertex(a);
            IntersectionGraph.AddVertex(b);
            IntersectionGraph.AddVertex(c);
            IntersectionGraph.AddVertex(d);
            IntersectionGraph.AddVertex(e);
            IntersectionGraph.AddVertex(f);
            IntersectionGraph.AddVertex(g);
            IntersectionGraph.AddVertex(h);
            IntersectionGraph.AddVertex(i);
            IntersectionGraph.AddVertex(j);
            IntersectionGraph.AddVertex(k);
            IntersectionGraph.AddVertex(l);
            IntersectionGraph.AddVertex(m);
            IntersectionGraph.AddVertex(n);
            IntersectionGraph.AddVertex(o);
            IntersectionGraph.AddVertex(p);

            IntersectionGraph.AddEdge(new Edge<LanePoint>(a, b));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(b, c));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(c, d));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(b, o));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(b, k));

            IntersectionGraph.AddEdge(new Edge<LanePoint>(e, f));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(f, g));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(g, h));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(f, o));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(f, k));

            IntersectionGraph.AddEdge(new Edge<LanePoint>(i, j));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(j, k));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(k, l));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(j, g));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(j, c));

            IntersectionGraph.AddEdge(new Edge<LanePoint>(m, n));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(n, o));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(o, p));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(n, c));
            IntersectionGraph.AddEdge(new Edge<LanePoint>(n, g));

            Cars = new List<Car>()
            {
                new Car(CalculatePathsFromTo(a,d),20),
                new Car(CalculatePathsFromTo(i,l),20),
                new Car(CalculatePathsFromTo(i,h),30),
                new Car(CalculatePathsFromTo(e,l),10),
                new Car(CalculatePathsFromTo(e,p),1),

            };
        }

        public IEnumerable<Edge<LanePoint>> CalculatePathsFromTo(LanePoint from, LanePoint to)
        {
            Func<Edge<LanePoint>, double> edgeCost = e => 1; // constant cost

            // compute shortest paths
            var tryGetPaths = IntersectionGraph.ShortestPathsDijkstra(edgeCost, from);

            // query path for given vertices
            LanePoint target = to;
            IEnumerable<Edge<LanePoint>> path;
            if (tryGetPaths(target, out path))
                return path;
            else return null;
        }

        public void CalculateSimulation()
        {
            while(!AllCarsFinished())
            {
                CurrentTime++;
                foreach (var item in Cars)
                {
                    item.UpdateCar(CurrentTime);
                }
            }
            if(AllCarsFinished())
            {
                FinishTime = CurrentTime;
                /*
                foreach (var item in Cars[0].LocationHistory)
                {
                    Console.WriteLine(item.Key + " : " + item.Value.X + ", " + item.Value.Y);
                }
                */
            }

        }

        public bool AllCarsFinished()
        {
            foreach (var item in Cars)
            {
                if (!item.CarFinished)
                    return false;
            }
            return true;
        }

    }
}
