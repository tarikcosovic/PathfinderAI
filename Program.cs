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

            var sarajevo = Graph.GetNode(x => x.City == "Sarajevo");
            var belgrade = Graph.GetNode(x => x.City == "Belgrade");
            var zagreb = Graph.GetNode(x => x.City == "Zagreb");
            var rome = Graph.GetNode(x => x.City == "Rome");

            sarajevo.AddNeighborReverse(belgrade, 23).AddNeighbor(zagreb, 25);
            zagreb.AddNeighbor(rome, 44);

            // Get All Paths Unit Test 01

            //var paths = Graph.GetAllPaths(belgrade, rome, EnumHelper.Algorithms.Dijkstra);

            //foreach (var path in paths)
            //    Console.WriteLine(path.ToString(x => x.City));



            // Get Shortest Path Unit Test 01

            var path = Graph.GetShortestPath(belgrade, rome, EnumHelper.Algorithms.Dijkstra);

            Console.WriteLine(path.ToString(x => x.City));


            Console.ReadKey();
        }

        private static void InitializeGraph()
        {
            Graph = new Graph<Airport>();

            string graphDataPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "GraphData.json");

            Graph.ReadFromJson(graphDataPath);
        }
    }
}
