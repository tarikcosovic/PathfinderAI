using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAI
{
    public class Node
    {
        public Guid id { get; set; }
        public bool isVisited { get; set; }
        private Dictionary<Node, double> _neighbors { get; set; }
        internal Node prev { get; set; }

        public Node()
        {
            id = Guid.NewGuid();
            isVisited = false;
            _neighbors = new Dictionary<Node, double>();
            prev = null;
        }


        public Node AddNeighbor(Node neighbor, double pathWeight)
        {
            if (neighbor == null) throw new ArgumentNullException("Neighbor Must Not Be Null!");
            if (pathWeight <= 0) throw new ArgumentException("PathWeight must be greater than 0!");

            if (!HasNeighbor(neighbor))
                _neighbors.Add(neighbor, pathWeight);

            return this;
        }

        public Node AddNeighborReverse(Node neighbor, double pathWeight)
        {
            if (neighbor == null) throw new ArgumentNullException("Neighbor Must Not Be Null!");
            if (pathWeight <= 0) throw new ArgumentException("PathWeight must be greater than 0!");

            if (!HasNeighbor(neighbor))
                _neighbors.Add(neighbor, pathWeight);

            if (!neighbor.HasNeighbor(this))
                neighbor._neighbors.Add(this, pathWeight);

            return this;
        }

        public Node AddNeighbors(Dictionary<Node, double> paths)
        {
            foreach(var node in paths)
                this.AddNeighbor(node.Key, node.Value);

            return this;
        }

        public Node AddNeighborsReverse(Dictionary<Node, double> paths)
        {
            foreach (var node in paths)
                this.AddNeighborReverse(node.Key, node.Value);

            return this;
        }


        public Node RemoveNeighbor(Node neighbor)
        {
            if (neighbor == null) throw new ArgumentNullException("Neighbor Must Not Be Null!");
            if (_neighbors.Count == 0) throw new Exception("Node Does Not Contain Neighbors!");

            if (HasNeighbor(neighbor))
                _neighbors.Remove(neighbor);
            else throw new ArgumentException("Node is not an neighbor!");

            return this;
        }

        public bool HasNeighbor(Node neighbor)
        {
            if (_neighbors.Count == 0 && neighbor == null) return false;

            bool isNeighbor = false;

            foreach (var node in _neighbors)
                if (node.Key.id == neighbor.id)
                    isNeighbor = true;

            return isNeighbor;
        }

        public Dictionary<Node, double> GetNeighbors() => _neighbors;

        public void ClearFlags()
        {
            this.isVisited = false;
            this.prev = null;
        }
    }
}
