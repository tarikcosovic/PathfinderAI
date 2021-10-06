# PathfinderAI

PathfinderAI is a C# library with a programmatic approach to graph-based operations.

## Installation

Download and reference the solution or dll in your project.


## Usage
In this example we are creating a graph of airports.

1. The graph takes a generic parameter for the node data which is user-defined (Airport).
2. The graph can be populated manually via method chaining or through reading a .json file.
3. Find desired nodes through lambda expressions and connect them with others via method chaining.
4. Use the built-in pathfinding algorithms to traverse the graph.

```python
class Main
{
        public void InitializeGraph()
        {
            var Graph = new Graph<Airport>();

            string graphDataPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "GraphData.json");
            Graph.ReadFromJson(graphDataPath);

            var sarajevo = Graph.GetNode(x => x.City == "Sarajevo");
            var belgrade = Graph.GetNode(x => x.City == "Belgrade");
            var zagreb = Graph.GetNode(x => x.City == "Zagreb");
            var rome = Graph.GetNode(x => x.City == "Rome");

            zagreb.AddNeighbor(rome, 44);
            sarajevo.AddNeighbor(zagreb, 25).AddNeighborReverse(belgrade, 23);

            var path = Graph.GetShortestPath(belgrade, rome, EnumHelper.Algorithms.DepthFirstSearch);

        }
}
```

## Contributing
Pull requests are more than welcome, this is my first library project and any form of feedback is welcome. 
  <br/> For major changes, please open an issue first to discuss what you would like to change.



## License
[MIT](https://choosealicense.com/licenses/mit/)
