using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAI.PathfindingAlgorithms
{
    public class DepthFirstSearch<T> : IPathfindingAlgorithm<T> where T : Node
    {
        private Path<T> path = null;

        public bool HasPath(T start, T target, List<T> graph = null)
        {
            InitializeVariables(start);

            return HasPathDfs(start, target);
        }

        public Path<T> GetShortestPath(T start, T target, List<T> graph = null)
        {

            return GetShortestPathBfs(start, target) ? path : null;
        }

        public List<Path<T>> GetAllPaths(T start, T target, List<T> graph = null)
        {
            throw new NotImplementedException("Using Depth-first Search to find all possible paths is not supported.");
        }


        #region HelperMethods

        private void InitializeVariables(T start)
        {
            path = new Path<T>();
            start.isVisited = true;
        }

        private bool HasPathDfs(T start, T target)
        {
            if(start.id == target.id)
                return true;
            else
            {
                foreach(var node in start.GetNeighbors().Keys)
                {
                    if(!node.isVisited)
                    {
                        node.isVisited = true;
                        var foundPath = HasPathDfs((T)node, target);

                        if (foundPath)
                            return true;
                    }
                }
            }
            return false;
        }

        private bool GetShortestPathBfs(T start, T target)
        {
            if (start.id == target.id)
            {
                path.Nodes.Add(start);
                return true;
            }
            else
            {
                foreach (var node in start.GetNeighbors())
                {
                    if (!node.Key.isVisited)
                    {
                        node.Key.isVisited = true;
                        var foundPath = GetShortestPathBfs((T)node.Key, target);

                        if (foundPath)
                        {
                            path.Nodes.Add(start);
                            path.TotalWeight += node.Value;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion
    }
}
