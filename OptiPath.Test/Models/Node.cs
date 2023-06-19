namespace OptiPath.Test
{
    public class Node : INode
    {
        /// <summary>
        /// The name of the Node.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructor that requires the Node's uuid and name.
        /// </summary>
        /// <param name="name">The name of the Node.</param>
        public Node(string name)
        {
            Name = name;
        }
    }
}
