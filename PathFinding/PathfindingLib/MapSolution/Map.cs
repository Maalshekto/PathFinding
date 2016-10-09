using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathfindingLib;

namespace PathfindingLib.MapSolution
{
    public class Map : Graph
    {
        Tile[,] tiles;
        int nbRows;
        int nbCols;
        Tile beginNode;
        Tile exitNode;
        List<Node> nodesList = null;
        List<Arc> arcsList = null;
        // Méthodes

        void setupMap(String _map, int _beginRow, int _beginColumn, int _exitRow, int _exitColumn)
        {
            String[] mapRows = _map.Split(new char[] { '\n' });
            nbRows = mapRows.Length;
            nbCols = mapRows[0].Length;
            tiles = new Tile[nbRows, nbCols];
            // Remplissage
            for (int row = 0; row < nbRows; row++)
            {
                for (int col = 0; col < nbCols; col++)
                {
                    tiles[row, col] = new Tile(TileTypeConverter.TypeFromChar(mapRows[row][col]), row, col);
                }
            }
            // Entrée et sortie
            beginNode = tiles[_beginRow, _beginColumn];
            beginNode.DistanceFromBegin = beginNode.Cost();
            exitNode = tiles[_exitRow, _exitColumn];
            // Liste des noeuds et des arcs
            NodesList();
            ArcsList();
        }

        public Map(String _map, int _beginRow, int _beginColumn, int _exitRow, int _exitColumn)
        {
            setupMap(_map, _beginRow, _beginColumn, _exitRow, _exitColumn);
        }

        public Map(char[,] _map, int _beginRow, int _beginColumn, int _exitRow, int _exitColumn)
        {
            string str = ""; 
            for(int i = 0; i < _map.GetLength(0); i++) {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    str += _map[i, j];
                }
                if(i < _map.GetLength(0) - 1)
                    str += "\n";
            }
            setupMap(str, _beginRow, _beginColumn, _exitRow, _exitColumn);
        }

        public Node BeginningNode()
        {
            return beginNode;
        }
        public Node ExitNode()
        {
            return exitNode;
        }

        public List<Node> NodesList()
        {
            if (nodesList == null)
            {
                nodesList = new List<Node>();
                foreach (Node node in tiles)
                {
                    nodesList.Add(node);
                }
            }
            return nodesList;
        }
        public List<Node> NodesList(Node _currentNode)
        {
            List<Node> nodesList = new List<Node>();
            int currentRow = ((Tile)_currentNode).Row;
            int currentCol = ((Tile)_currentNode).Col;
            // Renvoyer les voisins s’ils existent et sont accessibles
            if (currentRow - 1 >= 0 && tiles[currentRow - 1, currentCol].IsValidPath())
            {
                nodesList.Add(tiles[currentRow - 1, currentCol]);
            }
            if (currentCol - 1 >= 0 && tiles[currentRow, currentCol - 1].IsValidPath())
            {
                nodesList.Add(tiles[currentRow, currentCol - 1]);
            }
            if (currentRow + 1 < nbRows && tiles[currentRow + 1,
            currentCol].IsValidPath())
            {
                nodesList.Add(tiles[currentRow + 1, currentCol]);
            }
            if (currentCol + 1 < nbCols && tiles[currentRow,
            currentCol + 1].IsValidPath())
            {
                nodesList.Add(tiles[currentRow, currentCol + 1]);
            }
            return nodesList;
        }
        public int NodesCount()
        {
            return nbRows * nbCols;
        }

        public List<Arc> ArcsList()
        {
            if (arcsList == null)
            {
                arcsList = new List<Arc>();
                for (int row = 0; row < nbRows; row++)
                {
                    for (int col = 0; col < nbCols; col++)
                    {
                        if (tiles[row, col].IsValidPath())
                        {
                            // Haut
                            if (row - 1 >= 0 && tiles[row - 1, col].IsValidPath())
                            {
                                arcsList.Add(new Arc(tiles[row, col], tiles[row - 1, col], tiles[row - 1, col].Cost()));
                            }
                            
                            // Gauche
                            if (col - 1 >= 0 && tiles[row, col - 1].IsValidPath())
                            {
                                arcsList.Add(new Arc(tiles[row, col], tiles[row, col - 1], tiles[row, col -1].Cost()));
                            }
                            // Bas
                            if (row + 1 < nbRows && tiles[row + 1, col].IsValidPath())
                            {
                                arcsList.Add(new Arc(tiles[row, col], tiles[row + 1, col], tiles[row + 1, col].Cost()));
                            }
                            // Droite
                            if (col + 1 < nbCols && tiles[row, col + 1].IsValidPath())
                            {
                                arcsList.Add(new Arc(tiles[row, col], tiles[row, col + 1], tiles[row, col + 1].Cost()));
                            }
                        }
                    }          
                }
            }
            return arcsList;
        }

        public List<Arc> ArcsList(Node _currentNode)
        {
            List<Arc> list = new List<Arc>();
            int currentRow = ((Tile)_currentNode).Row;
            int currentCol = ((Tile)_currentNode).Col;
            // Renvoyer les voisins
            if (currentRow - 1 >= 0 && tiles[currentRow - 1,
            currentCol].IsValidPath())
            {
                list.Add(new Arc(_currentNode, tiles[currentRow - 1,
                currentCol], tiles[currentRow - 1, currentCol].Cost()));
            }
            if (currentCol - 1 >= 0 && tiles[currentRow, currentCol - 1].
            IsValidPath())
            {
                list.Add(new Arc(_currentNode, tiles[currentRow,
                currentCol - 1], tiles[currentRow, currentCol - 1].Cost()));
            }
            if (currentRow + 1 < nbRows && tiles[currentRow + 1,
            currentCol].IsValidPath())
            {
                list.Add(new Arc(_currentNode, tiles[currentRow + 1,
                currentCol], tiles[currentRow + 1, currentCol].Cost()));
            }
            if (currentCol + 1 < nbCols && tiles[currentRow,
            currentCol + 1].IsValidPath())
            {
                list.Add(new Arc(_currentNode, tiles[currentRow,
                currentCol + 1], tiles[currentRow, currentCol + 1].Cost()));
            }
            return list;
        }

        public double CostBetweenNodes(Node _fromNode, Node _toNode)
        {
            return ((Tile)_toNode).Cost();
        }

        public String ReconstructPath()
        {
            String resPath = "";
            Tile currentNode = exitNode;
            Tile prevNode = (Tile)exitNode.Precursor;
            while (prevNode != null)
            {
                resPath = "-" + currentNode.ToString() + resPath;
                currentNode = prevNode;
                prevNode = (Tile)prevNode.Precursor;
            }
            resPath = currentNode.ToString() + resPath;
            return resPath;
        }

        public LinkedList<int[]> ReconstructPathList()
        {
            LinkedList<int[]> path = new LinkedList<int[]>();
            Tile currentNode = exitNode;
            Tile prevNode = (Tile)exitNode.Precursor;
            int[] tilePos;
            while (prevNode != null)
            {
                tilePos = new int[2];
                tilePos[0] = currentNode.Col;
                tilePos[1] = currentNode.Row;
                path.AddFirst(tilePos);
                
                currentNode = prevNode;
                prevNode = (Tile)prevNode.Precursor;
            }
            tilePos = new int[2];
            tilePos[0] = currentNode.Col;
            tilePos[1] = currentNode.Row;
            path.AddFirst(tilePos);

            return path;
        }

        public void ComputeEstimatedDistanceToExit()
        {
            foreach (Tile tile in tiles)
            {
                tile.EstimatedDistance = Math.Abs(exitNode.Row -
                tile.Row) + Math.Abs(exitNode.Col - tile.Col);
            }
        }

        public void Clear()
        {
            nodesList = null;
            arcsList = null;
            for (int row = 0; row < nbRows; row++)
            {
                for (int col = 0; col < nbCols; col++)
                {
                    tiles[row, col].DistanceFromBegin = double.PositiveInfinity;
                    tiles[row, col].Precursor = null;
                }
            }
            beginNode.DistanceFromBegin = beginNode.Cost();
        }
    }
}