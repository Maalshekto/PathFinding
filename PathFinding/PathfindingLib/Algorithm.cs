using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    public abstract class Algorithm
    {
        protected Graph graph;
        protected IHM ihm;
        public Algorithm(Graph _graph, IHM _ihm)
        {
            graph = _graph;
            ihm = _ihm;
        }

        public void Solve()
        {
            // Nettoyage
            graph.Clear();
            // Lancement de l’algorithme
            Run();
            // Affichage du résultat
            ihm.PrintResult(graph.ReconstructPath(), graph.ExitNode().DistanceFromBegin);
        }
        protected abstract void Run();
    }

}
