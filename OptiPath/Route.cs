using System.Collections.Generic;
using System.Linq;

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

        public TNode[] Path { get; private set; }

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
        public Route(TNode start, TNode end, IEnumerable<TNode> path, int distance)
        {
            Start = start;
            End = end;
            Path = path.ToArray();
            Distance = distance;
        }

        /// <summary>
        /// Overriden ToString that returns the Path's Node Names.
        /// </summary>
        /// <returns>A string with the combined Path.</returns>
        public override string ToString() => string.Join(" -> ", Path.Select(x => x.Name));
}
}
