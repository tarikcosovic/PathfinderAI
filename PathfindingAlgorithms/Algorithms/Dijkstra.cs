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

        public bool HasPath(T start, T target, List<T> graph = null)
        {
            throw new NotImplementedException("Dijkstra is not recommended for searching for existing path..");
        }

        public Path<T> GetShortestPath(T start, T target, List<T> graph = null)
        {
            InitializeVariables(start, target, graph);

            while (_graph.Count > 0)
            {
                T next = GetShortestDistanceNode(start);

                GetShortestPathHelper(next);
            }

            return GetShortestPathResult(start, target);
        }

        public List<Path<T>> GetAllPaths(T start, T target, List<T> graph = null)
        {
            InitializeVariables(start, target, graph);

            while (_graph.Count > 0)
            {
                T next = GetShortestDistanceNode(start);

                GetShortestPathHelper(next);
            }

            return GetAllPathsResult(start); ;
        }


        #region HelperMethods

        private void InitializeVariables(T start, T target, List<T> graph)
        {
            if (!CheckIfNodeExistsInGraph(target, graph))
                throw new ArgumentException("The targeted node does not exist in the current graph!");

            this._graph = graph ?? throw new ArgumentException("Parameter graph must not be null!");
            this._result = new List<T>();
            start.ShortestDistanceFromStart = 0;
        }
        private void GetShortestPathHelper(T start)
        {
            foreach(var neighbor in start.GetNeighbors())
            {
                if (!neighbor.Key.isVisited)
                {
                    if ((neighbor.Value + start.ShortestDistanceFromStart) < neighbor.Key.ShortestDistanceFromStart)
                    {
                        neighbor.Key.ShortestDistanceFromStart = neighbor.Value + start.ShortestDistanceFromStart;
                        neighbor.Key.prev = start;
                    }
                }
            }
            start.isVisited = true;
            _graph.Remove(start);
            _result.Add(start);
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
        private T GetShortestDistanceNode(T start)
        {
            T next = _graph.Where(x => x.id != start.id).FirstOrDefault();

            foreach (var node in _graph)
                if (node.ShortestDistanceFromStart < next.ShortestDistanceFromStart)
                    next = node;

            return next;
        }
        private List<Path<T>> GetAllPathsResult(T start)
        {
            List<Path<T>> allPaths = new List<Path<T>>();

            foreach (var node in _result)
            {
                Path<T> path = new Path<T>();

                var result = node;

                while (result.prev != null)
                {
                    path.Nodes.Add(result);
                    result = (T)result.prev;
                }
                path.Nodes.Add(result);

                path.Start = start;
                path.Target = node;
                path.TotalWeight += node.ShortestDistanceFromStart;

                if (path.Nodes.Count > 1)
                {
                    path.Nodes.Reverse();
                    allPaths.Add(path);
                }
            }

            return allPaths;
        }
        private Path<T> GetShortestPathResult(T start, T target)
        {
            var path = new Path<T>();

            if (_result.Count > 0)
            {
                var result = _result.Where(x => x.id == target.id).FirstOrDefault();

                path.Start = start;
                path.Target = target;
                path.TotalWeight += result.ShortestDistanceFromStart;

                while (result != null)
                {
                    path.Nodes.Add(result);
                    result = (T)result.prev;
                }

                path.Nodes.Reverse();
            }

            return path;
        }

        #endregion
    }
}
