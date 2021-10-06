using System.Collections.Generic;

namespace PathfinderAI
{
    public class Path<T> where T : Node
    {
        public List<T> Nodes { get; internal set; }
        public double TotalWeight { get; internal set; }

        public Path()
        {
            this.Nodes = new List<T>();
            this.TotalWeight = 0;
        }

        public Path(List<T> nodes, double totalWeight)
        {
            this.Nodes = nodes;
            this.TotalWeight = totalWeight;
        }
    }
}