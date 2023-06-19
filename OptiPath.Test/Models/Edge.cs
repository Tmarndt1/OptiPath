using OptiPath.Interfaces;

namespace OptiPath.Test
{
    /// <summary>
    /// Represents an edge or path between two nodes
    /// </summary>
    public class Edge : IEdge<Node>
    {
        /// <summary>
        /// The source Node.
        /// </summary>
        public Node Source { get; }

        /// <summary>
        /// The target Node.
        /// </summary>
        public Node Target { get; }

        /// <summary>
        /// The weight of the Edge.
        /// </summary>
        private readonly int _weight = 0;

        /// <summary>
        /// Constructor that requires a source Node, a target Node, and a weight of the edge.
        /// </summary>
        /// <param name="source">The source Node.</param>
        /// <param name="target">The target Node.</param>
        /// <param name="weight">The weight.</param>
        public Edge(Node source, Node target, int weight)
        {
            Source = source;
            Target = target;
            _weight = weight;
        }

        public int GetWeight() => _weight;
    }
}
