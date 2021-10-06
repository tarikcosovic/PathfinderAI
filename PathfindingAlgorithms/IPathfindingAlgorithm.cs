using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAI.PathfindingAlgorithms
{
    public interface IPathfindingAlgorithm<T> where T : Node
    {
        bool HasPath(T start, T target);
        Path<T> GetShortestPath(T start, T target);
        List<Path<T>> GetAllPaths(T start, T target);
    }
}
