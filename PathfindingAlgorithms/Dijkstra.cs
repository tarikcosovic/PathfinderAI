using System;
using System.Collections.Generic;
using System.Linq;

namespace PathfinderAI.PathfindingAlgorithms
{
    /*
    
    Dijkstra's Algorithm Steps

    1. Set the ShortestDistanceFromStart for starting Node to 0
    2. Visit the Node with shortest ShortestDistanceFromStart
    3. Get Nodes' distance to each unvisited neighbour
    4. If the distance is shorter than the ShortestDistanceFromSmart update value and prevNode field
    5. Add the isVisited flag of the current Node

     */

    public class Dijkstra<T> : IPathfindingAlgorithm<T> where T : Node
    {
        private List<T> _graph = null;
        private List<T> _result = null;

        public List<Path<T>> GetAllPaths(T start, T target)
        {
            throw new NotImplementedException();
        }

        public Path<T> GetShortestPath(T start, T target, List<T> graph = null)
        {
            if (!CheckIfNodeExistsInGraph(target, graph))
                throw new ArgumentException("The targeted node does not exist in the current graph!");

            start.ShortestDistanceFromStart = 0;
            this._graph = graph;
            this._result = new List<T>();

            while (_graph.Count > 0)
            {
                T next = GetShortestDistanceNode(start);

                GetShortestPathHelper(next);
            }

            return GetShortestPathResult(target);
        }

        public bool HasPath(T start, T target)
        {
            throw new NotImplementedException();
        }

        private Path<T> GetShortestPathResult(T target)
        {
            var path = new Path<T>();

            if (_result.Count > 0)
            {
                var result = _result.Where(x => x.id == target.id).FirstOrDefault();

                while (result != null)
                {
                    path.Nodes.Add(result);
                    path.TotalWeight += result.ShortestDistanceFromStart;
                    result = (T)result.prev;
                }
            }

            return path;
        }

        private void GetShortestPathHelper(T start)
        {

            foreach(var neighbor in start.GetNeighbors())
            {
                if (!neighbor.Key.isVisited)
                {
                    if ((neighbor.Value + start.ShortestDistanceFromStart) < neighbor.Key.ShortestDistanceFromStart)
                    {
                        neighbor.Key.ShortestDistanceFromStart = neighbor.Value;
                        neighbor.Key.prev = start;
                    }
                }
            }

            start.isVisited = true;
            _graph.Remove(start);
            _result.Add(start);
        }

        private T GetShortestDistanceNode(T start)
        {
            T next = _graph.Where(x => x.id != start.id).FirstOrDefault();

            foreach (var node in _graph)
                if (node.ShortestDistanceFromStart < next.ShortestDistanceFromStart)
                    next = node;

            return next;
        }

        private bool CheckIfNodeExistsInGraph(T node, List<T> graph)
        {
            if (graph == null)
                throw new ArgumentException("Graph can not be null!");

            foreach (var vertice in graph)
                if (vertice.id == node.id)
                    return true;
            return false;
        }
    }
}
