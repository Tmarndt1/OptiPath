using OptiPath.Interfaces;
using System;
using System.Collections.Generic;

namespace OptiPath
{
    /// <summary>
    /// Represents a map with nodes and edges for finding the most optimal route.
    /// </summary>
    public class Map<TNode, TEdge>
        where TNode : class, INode
        where TEdge : class, IEdge<TNode>
    {
        private readonly Graph<TNode, TEdge> _graph = new Graph<TNode, TEdge>();

        public void AddNode(TNode node)
        {
            _graph.AddNode(node);
        }

        public void AddEdge(TEdge edge)
        {
            _graph.AddEdge(edge);
        }

        public Route<TNode> FindFastestRoute(TNode start, TNode end)
        {
            if (!_graph.ContainsKey(start))
            {
                throw new ArgumentException("Map does not contain the source Node.");
            }

            if (!_graph.ContainsKey(end))
            {
                throw new ArgumentException("Map does not contain the target Node.");
            }

            Dictionary<TNode, int> distances = new Dictionary<TNode, int>();

            Dictionary<TNode, TNode> previous = new Dictionary<TNode, TNode>();

            List<TNode> unvisitedNodes = new List<TNode>();

            foreach (TNode node in _graph.Keys)
            {
                distances[node] = int.MaxValue;
                
                previous[node] = null;

                unvisitedNodes.Add(node);
            }

            distances[start] = 0;

            while (unvisitedNodes.Count > 0)
            {
                TNode currentNode = null;

                foreach (TNode node in unvisitedNodes)
                {
                    if (currentNode == null || distances[node] < distances[currentNode])
                    {
                        currentNode = node;
                    }
                }

                unvisitedNodes.Remove(currentNode);

                if (currentNode == end)
                {
                    break;
                }

                if (_graph[currentNode] != null)
                {
                    foreach (TNode neighbor in _graph[currentNode].Keys)
                    {
                        int distance = distances[currentNode] + _graph.GetWeight(currentNode, neighbor);

                        if (distance < distances[neighbor])
                        {
                            distances[neighbor] = distance;

                            previous[neighbor] = currentNode;
                        }
                    }
                }
            }

            if (previous[end] == null)
            {
                throw new ArgumentException("No route found between start and end nodes.");
            }

            List<TNode> path = new List<TNode>();

            TNode current = end;

            while (current != null)
            {
                path.Insert(0, current);

                current = previous[current];
            }

            return new Route<TNode>(start, end, path, GetDistance(path));
        }

        private int GetDistance(List<TNode> route)
        {
            int distance = 0;

            for (int i = 0; i < route.Count - 1; i++)
            {
                distance += _graph.GetWeight(route[i], route[i + 1]);
            }

            return distance;
        }
    }
}
