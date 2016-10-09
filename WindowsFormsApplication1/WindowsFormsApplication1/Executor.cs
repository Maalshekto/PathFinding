using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathfindingLib;
using PathfindingLib.MapSolution;
using PathfindingLib.Algorithms;


namespace WindowsFormsApplication1
{
    class Executor : IHM
    {
        private string Result = ""; 
        public void PrintResult(String _path, double _distance)
        {
            Result += "Chemin (taille : " + _distance +") : " + _path + "\n\n";
        }

          public void RunAlgorithm(string _algoName, Graph _graph)
        {
            // Variables
            DateTime beginning;
            DateTime end;
            TimeSpan duration;
            Algorithm algo = null;
            // Création de l’algorithme
            switch (_algoName)
            {
                case "Depth First":
                    algo = new DepthFirst(_graph, this);
                    break;
                case "Breadth First":
                    algo = new BreadthFirst(_graph, this);
                    break;
                case "Bellman Ford":
                    algo = new BellmanFord(_graph, this);
                    break;
                case "Dijkstra":
                    algo = new Dijkstra(_graph, this);
                    break;
                case "A Star":
                    algo = new AStar(_graph, this);
                    break;
            }
            // Résolution
            Console.Out.WriteLine("Algorithme : " + _algoName);
            beginning = DateTime.Now;
            algo.Solve();
            end = DateTime.Now;
            duration = end - beginning;
            Console.Out.WriteLine("Durée (ms) : " +
            duration.TotalMilliseconds.ToString() + "\n");
        }

        public void RunAllAlgorithms(Graph _graph)
        {
            // Résolution par une recherche en profond
            RunAlgorithm("Depth-First", _graph);
            // Résolution par une recherche en largeur
            RunAlgorithm("Breadth-First", _graph);
            // Résolution par Bellman-Ford
            RunAlgorithm("Bellman-Ford", _graph);
            // Résolution par Dijkstra
            RunAlgorithm("Dijkstra", _graph);
            // Résolution par A*
            RunAlgorithm("A*", _graph);
        }
        public string getResult()
        {
            return Result;
        }
    }
}
