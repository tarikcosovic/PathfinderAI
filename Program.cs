using PathfinderAI.PathfindingAlgorithms;
using System;
using System.IO;


namespace PathfinderAI
{
    public class Airport : Node
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Airport()
        {

        }
    }

    class Program
    {
        public static Graph<Airport> Graph = null;

        static void Main(string[] args)
        {
            InitializeGraph();
        }

        static void InitializeGraph()
        {
            Graph = new Graph<Airport>();

            string graphDataPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "GraphData.json");

            Graph.ReadFromJson(graphDataPath);

            var sarajevo = Graph.GetNode(x => x.City == "Sarajevo");
            var belgrade = Graph.GetNode(x => x.City == "Belgrade");
            var zagreb = Graph.GetNode(x => x.City == "Zagreb");
            var rome = Graph.GetNode(x => x.City == "Rome");

            sarajevo.AddNeighborReverse(belgrade, 23).AddNeighbor(zagreb, 25);
            zagreb.AddNeighbor(rome, 44);

            var path = Graph.GetShortestPath(belgrade, rome, EnumHelper.Algorithms.Dijkstra);

            foreach(var node in path.Nodes)
                Console.Write(node.City + " - ");

            Console.WriteLine("Total Distance: " + path.TotalWeight);

            Console.ReadKey();
        }

    }
}
