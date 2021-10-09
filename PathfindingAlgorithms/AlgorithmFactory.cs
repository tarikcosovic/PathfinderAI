using PathfinderAI.PathfindingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAI
{
    public static class AlgorithmFactory<T> where T : Node
    {
        public static IPathfindingAlgorithm<T> GetAlgorithm(EnumHelper.Algorithms algorithm)
        {
            switch(algorithm)
            {
                case EnumHelper.Algorithms.BreadthFirstSearch:  return new BreadthFirstSearch<T>();
                case EnumHelper.Algorithms.DepthFirstSearch:    return new DepthFirstSearch<T>();
                case EnumHelper.Algorithms.Dijkstra:            return new Dijkstra<T>();

                default:                                        return new BreadthFirstSearch<T>();
            }
        }
    }
}
