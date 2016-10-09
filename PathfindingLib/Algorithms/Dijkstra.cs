using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathfindingLib;

namespace PathfindingLib.Algorithms
{
    public class Dijkstra : Algorithm
    {
        public Dijkstra(Graph _graph, IHM _ihm) : base(_graph, _ihm) { }
        protected override void Run()
        {
            // Initialisation
            List<Node> nodesToVisit = graph.NodesList();
            bool exitReached = false;
            // Boucle principale
            while (nodesToVisit.Count != 0 && !exitReached)
            {
                Node currentNode = nodesToVisit.FirstOrDefault();
                foreach (Node newNode in nodesToVisit)
                {
                    if (newNode.DistanceFromBegin < currentNode.DistanceFromBegin)
                    {
                        currentNode = newNode;
                    }
                }
                if (currentNode == graph.ExitNode())
                {
                    exitReached = true;
                }
                else
                {
                    List<Arc> arcsFromCurrentNode = graph.ArcsList(currentNode);
                    foreach (Arc arc in arcsFromCurrentNode)
                    {
                        if (arc.FromNode.DistanceFromBegin + arc.Cost <
                        arc.ToNode.DistanceFromBegin)
                        {
                            arc.ToNode.DistanceFromBegin = arc.FromNode.DistanceFromBegin +
                            arc.Cost;
                            arc.ToNode.Precursor = arc.FromNode;
                        }
                    }
                    nodesToVisit.Remove(currentNode);
                }
            }
        }
    }
}
