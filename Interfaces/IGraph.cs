using PathfinderAI.PathfindingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAI.Interfaces
{
    /// <summary>
    /// The Graph Interface contains a collection of core graph-related methods which are essential for its' proper functioning.
    /// </summary>
    /// <typeparam name="T">T is a user-type which contains details about the Node in the graph.</typeparam>
    public interface IGraph<T> where T : Node
    {

        /// <summary>
        /// Adds specified node to graph.
        /// </summary>
        /// <param name="node">Indicates the node that will be added to the graph.</param>
        /// <returns>Returns the graph in current context.</returns>
        Graph<T> AddNode(T node);

        /// <summary>
        /// Adds a specified list of nodes to graph.
        /// </summary>
        /// <param name="node">Indicates the nodes that will be added to the graph.</param>
        /// <returns>Returns the graph in current context.</returns>
        Graph<T> AddNode(List<T> nodes);

        /// <summary>
        /// Remove a specified node from graph.
        /// </summary>
        /// <param name="node">Indicates the nodes that will be removed from the graph.</param>
        /// <returns>Returns the graph in current context.</returns>
        Graph<T> RemoveNode(T node);

        /// <summary>
        /// Returns the first node that matches the expression otherwise returns null.
        /// </summary>
        /// <param name="expression">Indicates the expression by which the node will be searched.</param>
        /// <returns>Returns the T type object or null.</returns>
        T GetNode(Predicate<T> expression);

        /// <summary>
        /// Returns the first node who has a property with given value otherwise returns null.
        /// </summary>
        /// <param name="value">Indicates the value by which the node will be queried.</param>
        /// <returns>Returns the T type object or null.</returns>
        T GetNode(string value);



        /// <summary>
        /// Reads the graph data from a .json file.
        /// </summary>
        /// <param name="path">Path to .json file containing the graph data.</param>
        void ReadFromJson(string path);



        /// <summary>
        /// Checks whether the specified nodes have a valid path.
        /// </summary>
        /// <param name="start">Starting Node</param>
        /// <param name="target">Targeted Node</param>
        /// <param name="algorithm">Describes which algorithm to use for the traversal, use the "EnumHelper.Algorithms" enumerator to see available options.</param>
        /// <returns> Returns true if the path exists.</returns>
        bool HasPath(T start, T target, EnumHelper.Algorithms algorithm);

        /// <summary>
        /// Gets the shortest path.
        /// </summary>
        /// <param name="start">Starting Node</param>
        /// <param name="target">Targeted Node</param>
        /// <param name="algorithm">Describes which algorithm to use for the traversal, use the "EnumHelper.Algorithms" enumerator to see available options.</param>
        /// <returns> Returns the path or list of nodes if one exists.</returns>
        Path<T> GetShortestPath(T start, T target, EnumHelper.Algorithms algorithm);

        /// <summary>
        /// Gets all possible paths to target.
        /// </summary>
        /// <param name="start">Starting Node</param>
        /// <param name="target">Targeted Node</param>
        /// <param name="algorithm">Describes which algorithm to use for the traversal, use the "EnumHelper.Algorithms" enumerator to see available options.</param>
        /// <returns> Returns the path or list of nodes if one exists.</returns>
        List<Path<T>> GetAllPaths(T start, T target, EnumHelper.Algorithms algorithm);

    }
}
