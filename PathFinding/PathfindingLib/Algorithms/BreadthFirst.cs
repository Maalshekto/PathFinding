using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathfindingLib;

namespace PathfindingLib.Algorithms
{
    public class BreadthFirst : Algorithm
    {
        public BreadthFirst(Graph _graph, IHM _ihm) : base(_graph, _ihm) { }
        protected override void Run()
        {
            // Création de la liste des noeuds non visités, et de la file
            List<Node> notVisitedNodes = graph.NodesList();
            Queue<Node> nodesToVisit = new Queue<Node>();
            nodesToVisit.Enqueue(graph.BeginningNode());
            notVisitedNodes.Remove(graph.BeginningNode());
            Node exitNode = graph.ExitNode();
            bool exitReached = false;
            // Boucle principale
            while (nodesToVisit.Count != 0 && !exitReached)
            {
                Node currentNode = nodesToVisit.Dequeue();
                if (currentNode.Equals(exitNode))
                {
                    // On a fini
                    exitReached = true;
                }
                else
                {
                    // On ajoute les voisins
                    foreach (Node node in graph.NodesList(currentNode))
                    {
                        if (notVisitedNodes.Contains(node))
                        {
                            notVisitedNodes.Remove(node);
                            node.Precursor = currentNode;
                            node.DistanceFromBegin = currentNode.DistanceFromBegin +
                            graph.CostBetweenNodes(currentNode, node);
                            nodesToVisit.Enqueue(node);
                        }
                    }
                }
            }
        }
    }
}
