using OptiPath.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptiPath
{
    internal class Graph<TNode, TEdge>
        where TNode : INode
        where TEdge : IEdge<TNode>
    {
        private readonly Dictionary<TNode, Dictionary<TNode, TEdge>> _graph = new Dictionary<TNode, Dictionary<TNode, TEdge>>();

        public Dictionary<TNode, TEdge> this[TNode node] => _graph[node];

        public IEnumerable<TNode> Keys => _graph.Keys;

        public bool ContainsKey(TNode node) => _graph.ContainsKey(node);

        public IEnumerable<TEdge> GetEdgesFromNode(TNode node) => _graph[node].Values;

        public void AddNode(TNode node)
        {
            if (!_graph.ContainsKey(node))
            {
                _graph[node] = new Dictionary<TNode, TEdge>();
            }
        }

        public void AddEdge(TEdge edge)
        {
            if (!_graph.ContainsKey(edge.Source))
            {
                throw new ArgumentException("Map does not contain the source Node.");
            }

            if (!_graph.ContainsKey(edge.Target))
            {
                throw new ArgumentException("Map does not contain the target Node.");
            }

            if (_graph[edge.Source].ContainsKey(edge.Target))
            {
                throw new ArgumentException($"Edge already exists with the same source {edge.Source.Name} and target {edge.Target.Name}");
            }

            _graph[edge.Source][edge.Target] = edge;
        }

        public int GetWeight(TNode source, TNode target)
        {
            if (!_graph.ContainsKey(source))
            {
                throw new KeyNotFoundException($"Node {source} does not exist in the graph.");
            }

            if (!_graph[source].ContainsKey(target))
            {
                throw new KeyNotFoundException($"Edge from node {source} to node {target} does not exist in the graph.");
            }

            return _graph[source][target].GetWeight();
        }
    }
}
