using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSim.Model
{
    class IntelligentRoundabout : Roundabout
    {
        public IntelligentRoundabout(List<TrafficPattern> patterns) : base(patterns)
        {
        }

        public override void IterateSimaultion()
        {
            throw new NotImplementedException();
        }
    }
}
