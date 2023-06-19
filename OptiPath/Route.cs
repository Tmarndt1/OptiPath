namespace OptiPath
{
    public class Route<TNode>
        where TNode : class, INode
    {
        /// <summary>
        /// The starting Node of the Route.
        /// </summary>
        public TNode Start { get; private set; }

        /// <summary>
        /// The ending Node of the Route.
        /// </summary>
        public TNode End { get; private set; }

        /// <summary>
        /// The total distance of the Route.
        /// </summary>
        public int Distance { get; private set; }

        /// <summary>
        /// Constructor that requires a start and end Node.
        /// </summary>
        /// <param name="start">The starting Node of the Route.</param>
        /// <param name="end">The ending Node of the Route.</param>
        /// <param name="distance">The total distance of the Route.</param>
        public Route(TNode start, TNode end, int distance)
        {
            Start = start;
            End = end;
            Distance = distance;
        }
    }
}
