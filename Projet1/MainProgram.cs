using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathfindingLib;
using PathfindingLib.MapSolution;
using PathfindingLib.Algorithms;
using IO = System.Console;

namespace PathFinding
{

    class MainProgram : IHM
    {
        static void Main(string[] _args)
        {
            MainProgram p = new MainProgram();
            p.Run();
            IO.ReadKey();
            
        }
        public void PrintResult(String _path, double _distance)
        {
            Console.Out.WriteLine("Chemin (taille : " + _distance +") : " + _path);
        }
        private void RunAlgorithm(string _algoName, Graph _graph)
        {
            // Variables
            DateTime beginning;
            DateTime end;
            TimeSpan duration;
            Algorithm algo = null;
            // Création de l’algorithme
            switch (_algoName)
            {
                case "Depth-First":
                    algo = new DepthFirst(_graph, this);
                    break;
                case "Breadth-First":
                    algo = new BreadthFirst(_graph, this);
                    break;
                case "Bellman-Ford":
                    algo = new BellmanFord(_graph, this);
                    break;
                case "Dijkstra":
                    algo = new Dijkstra(_graph, this);
                    break;
                case "A*":
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

        private void RunAllAlgorithms(Graph _graph)
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

        private void Run()
        {
            // 1ère carte
            String mapStr = "..  XX   .\n"
                          + "*.  *X  *.\n"
                          + " .  XX ...\n"
                          + " .* X *.* \n"
                          + " ...=...  \n"
                          + " .* X     \n"
                          + " .  XXX*  \n"
                          + " .  * =   \n"
                          + " .... XX  \n"
                          + "   *.  X* ";
            Map map = new Map(mapStr, 0, 0, 9, 9);
            RunAllAlgorithms(map);

            // 2ème carte
            mapStr = "...*     X .*    *  \n"
                   + " *..*   *X .........\n"
                   + "   .     =   *.*  *.\n"
                   + "  *.   * XXXX .    .\n"
                   + "XXX=XX   X *XX=XXX*.\n"
                   + "  *.*X   =  X*.  X  \n"
                   + "   . X * X  X . *X* \n"
                   + "*  .*XX=XX *X . XXXX\n"
                   + " ....  .... X . X   \n"
                   + " . *....* . X*. = * ";
            map = new Map(mapStr, 0, 0, 9, 19);
            RunAllAlgorithms(map);
        }
    }
}
