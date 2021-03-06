using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAI.PathfindingAlgorithms
{
    public class BreadthFirstSearch<T> : IPathfindingAlgorithm<T> where T : Node
    {
        internal Queue<T> queue = new Queue<T>();

        public bool HasPath(T start, T target, List<T> graph = null)
        {
            InitializeVariables(start);

            while (queue.Count > 0)
            {
                if (HasPathBfs(queue.Dequeue(), target))
                    return true;
            }

            return false;
        }
        
        public Path<T> GetShortestPath(T start, T target, List<T> graph = null)
        {
            InitializeVariables(start);

            while (queue.Count > 0)
            {
                var result = GetShortestPathBfs(queue.Dequeue(), target);

                if (result != null)
                    return GetPathResult(result);
            }

            return null;
        }

        public List<Path<T>> GetAllPaths(T start, T target, List<T> graph = null)
        {
            throw new NotImplementedException("Using Breadth-first Search to find all possible paths is not supported.");
        }


        #region HelperMethods

        private void InitializeVariables(T start)
        {
            queue.Clear();
            queue.Enqueue(start);
            start.isVisited = true;
        }
        private bool HasPathBfs(T x, T target)
        {
            if (x.id == target.id)
                return true;
            else
            {
                var neighbors = x.GetNeighbors().Keys;

                foreach (var node in neighbors)
                {
                    if (!node.isVisited)
                    {
                        node.isVisited = true;
                        queue.Enqueue((T)node);
                    }
                }
                return false;
            }
        }
        private T GetShortestPathBfs(T x, T target)
        {
            if (x.id == target.id)
                return x;
            else
            {
                var neighbors = x.GetNeighbors().Keys;

                foreach (var node in neighbors)
                {
                    if (!node.isVisited)
                    {
                        node.isVisited = true;
                        node.prev = x;
                        queue.Enqueue((T)node);
                    }
                }
                return null;
            }
        }
        private Path<T> GetPathResult(T result)
        {
            var path = new Path<T>();

            while (result != null)
            {
                path.Nodes.Add(result);

                result = (T)result.prev;
            }

            return path;
        }

        #endregion

    }
}
