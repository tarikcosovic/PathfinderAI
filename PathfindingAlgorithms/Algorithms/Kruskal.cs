using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAI.PathfindingAlgorithms
{
    public class Kruskal<T> : IPathfindingAlgorithm<T> where T : Node
    {
        //Kruskal' Algorithm will convert the graph into a bi-directional graph if not already.
        public List<Path<T>> GetAllPaths(T start, T target, List<T> graph = null)
        {
            throw new NotImplementedException();
        }

        public Path<T> GetShortestPath(T start, T target, List<T> graph = null)
        {
            throw new NotImplementedException();
        }

        public bool HasPath(T start, T target, List<T> graph = null)
        {
            throw new NotImplementedException();
        }
    }
}
