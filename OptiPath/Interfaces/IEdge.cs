namespace OptiPath.Interfaces
{
    public interface IEdge<out TNode>
        where TNode : INode
    {
        /// <summary>
        /// The source Node.
        /// </summary>
        public TNode Source { get; }

        /// <summary>
        /// The target Node.
        /// </summary>
        public TNode Target { get; }

        /// <summary>
        /// Gets the weight of the Edge.
        /// </summary>
        public int GetWeight();
    }
}
