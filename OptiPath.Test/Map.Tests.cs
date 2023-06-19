using System;
using System.Xml.Linq;

namespace OptiPath.Test
{
    public partial class Tests
    {
        private readonly Map<Node, Edge> map;

        public Tests()
        {
            map = new Map<Node, Edge>();
        }

        [Fact]
        public void FindFastestRoute_WhenStartAndEndNodesAreSame_ShouldThrow()
        {
            // Arrange
            Node nodeA = new Node("A");
            map.AddNode(nodeA);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => map.FindFastestRoute(nodeA, nodeA));
        }

        [Fact]
        public void FindFastestRoute_WhenNoRouteExists_ShouldThrowArgumentException()
        {
            // Arrange
            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            map.AddNode(nodeA);
            map.AddNode(nodeB);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => map.FindFastestRoute(nodeA, nodeB));
        }

        [Fact]
        public void FindFastestRoute_WhenRouteExists_ShouldReturnCorrectRoute()
        {
            // Arrange
            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node nodeD = new Node("D");

            map.AddNode(nodeA);
            map.AddNode(nodeB);
            map.AddNode(nodeC);
            map.AddNode(nodeD);

            map.AddEdge(new Edge(nodeA, nodeB, 5));
            map.AddEdge(new Edge(nodeB, nodeC, 3));
            map.AddEdge(new Edge(nodeC, nodeD, 2));

            // Act
            var route = map.FindFastestRoute(nodeA, nodeD);

            // Assert
            Assert.Equal(10, route.Distance);
        }

        [Fact]
        public void FindFastestRoute_WhenMultipleRouteExists_ShouldReturnCorrectRoute()
        {
            // Arrange
            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node nodeD = new Node("D");

            map.AddNode(nodeA);
            map.AddNode(nodeB);
            map.AddNode(nodeC);
            map.AddNode(nodeD);

            map.AddEdge(new Edge(nodeA, nodeB, 5));
            map.AddEdge(new Edge(nodeB, nodeC, 3));
            map.AddEdge(new Edge(nodeC, nodeD, 2));
            
            map.AddEdge(new Edge(nodeA, nodeC, 1));
            map.AddEdge(new Edge(nodeC, nodeB, 3));
            map.AddEdge(new Edge(nodeB, nodeD, 1));


            // Act
            var route = map.FindFastestRoute(nodeA, nodeD);

            // Assert
            Assert.Equal(3, route.Distance);
        }

        [Fact]
        public void FindFastestRoute_WhenAlotRouteExists_ShouldReturnCorrectRoute()
        {
            // Arrange
            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node nodeD = new Node("D");
            Node nodeE = new Node("E");
            Node nodeF = new Node("F");

            map.AddNode(nodeA);
            map.AddNode(nodeB);
            map.AddNode(nodeC);
            map.AddNode(nodeD);
            map.AddNode(nodeE);
            map.AddNode(nodeF);

            map.AddEdge(new Edge(nodeA, nodeB, 5));
            map.AddEdge(new Edge(nodeB, nodeC, 3));
            map.AddEdge(new Edge(nodeC, nodeD, 2));
            map.AddEdge(new Edge(nodeD, nodeE, 1));
            map.AddEdge(new Edge(nodeE, nodeF, 3));

            map.AddEdge(new Edge(nodeA, nodeC, 2));
            map.AddEdge(new Edge(nodeC, nodeB, 5));
            map.AddEdge(new Edge(nodeB, nodeD, 1));

            // Act
            var route = map.FindFastestRoute(nodeA, nodeF);

            // Assert
            Assert.Equal(8, route.Distance);
        }
    }
}