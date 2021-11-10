using Jil;
using PathfinderAI.Interfaces;
using PathfinderAI.PathfindingAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;

namespace PathfinderAI
{
    public class Graph<T> :IGraph<T> where T : Node
    {
        public List<T> _vertices { get; internal set; }

        public Graph()
        {
            _vertices = new List<T>();
        }

  
        public Graph<T> AddNode(T node)
        {
            _vertices.Add(node);

            return this;
        }


        public Graph<T> AddNode(List<T> nodes)
        {
            if (nodes == null) throw new NullReferenceException("Nodes Array Must Not Be Null!");

            _vertices.AddRange(nodes);

            return this;
        }


        public Graph<T> RemoveNode(T node)
        {
            _vertices.Remove(node);

            return this;
        }


    
        public T GetNode(Predicate<T> expression)
        {
            foreach(var node in _vertices)
                if (expression(node))
                    return node;

            return null;
        }


        public T GetNode(string value)
        {
            foreach (var node in _vertices)
            {
                var properties = typeof(T).GetProperties();

                foreach (var property in properties)
                    if (property.GetValue(node).ToString() == value)
                        return node;
            }

            return null;
        }



        public void ReadFromJson(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException(path);
                }

                if(typeof(T) != null)
                    this._vertices.AddRange(JSON.Deserialize<List<T>>(File.ReadAllText(path)));

            }
            catch (Exception ex)
            {
                throw new Exception("Unhandled exception while reading from json file with message: " + ex.Message);
            }
        }

        public Graph<T> LoadDefaultData()
        {
            string graphDataPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "GraphData.json");

            this.ReadFromJson(graphDataPath);

            return this;
        }


        
        public bool HasPath(T start, T target, EnumHelper.Algorithms algorithm)
        {
            bool hasPath = false;

            try
            {
                var service = AlgorithmFactory<T>.GetAlgorithm(algorithm);

                hasPath = service.HasPath(start, target, _vertices);
            }
            catch(Exception ex)
            {
                throw new Exception("Exception on HasPath method with message: " + ex);
            }
            finally
            {
                ResetNodeStates();
            }

            return hasPath;
        }

        
        public Path<T> GetShortestPath(T start, T target, EnumHelper.Algorithms algorithm)
        {
            Path<T> path = null;

            try
            {
                var service = AlgorithmFactory<T>.GetAlgorithm(algorithm);

                path = service.GetShortestPath(start, target, _vertices);
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandled exception with message:" + ex.Message);
            }
            finally
            {
                ResetNodeStates();
            }

            return path;
        }

       
        public List<Path<T>> GetAllPaths(T start, T target, EnumHelper.Algorithms algorithm)
        {
            List<Path<T>> path = null;

            try
            {
                var service = AlgorithmFactory<T>.GetAlgorithm(algorithm);

                path = service.GetAllPaths(start, target, _vertices);
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandled exception with message:" + ex.Message);
            }
            finally
            {
                ResetNodeStates();
            }

            return path;
        }


        private void ResetNodeStates()
        {
            foreach (var node in _vertices)
                node.ClearFlags();
        }

    }
}
