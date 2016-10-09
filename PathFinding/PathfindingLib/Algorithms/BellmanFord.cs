using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathfindingLib;

namespace PathfindingLib.Algorithms
{
    public class BellmanFord : Algorithm
    {
        public BellmanFord(Graph _graph, IHM _ihm) : base(_graph, _ihm) { }
        protected override void Run()
        {
            // Initialisation
            bool distanceChanged = true;
            int i = 0;
            List<Arc> arcsList = graph.ArcsList();
            // Boucle principale
            int nbLoopMax = graph.NodesCount() - 1;
            while (i < nbLoopMax && distanceChanged)
            {
                distanceChanged = false;
                foreach (Arc arc in arcsList)
                {
                    if (arc.FromNode.DistanceFromBegin +
                    arc.Cost < arc.ToNode.DistanceFromBegin)
                    {
                        arc.ToNode.DistanceFromBegin =
                        arc.FromNode.DistanceFromBegin + arc.Cost;
                        arc.ToNode.Precursor =
                        arc.FromNode;
                        distanceChanged = true;
                    }
                }
                i++;
            }
            // Test si boucle négative
            foreach (Arc arc in arcsList)
            {
                if (arc.FromNode.DistanceFromBegin + arc.Cost <
                arc.ToNode.DistanceFromBegin)
                {
                    // Impossible de trouver un chemin
                    throw new Exception();
                }
            }
        }
    }
}
