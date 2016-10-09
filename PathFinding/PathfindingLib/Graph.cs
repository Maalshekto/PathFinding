using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    public interface Graph
    {
        Node BeginningNode();
        Node ExitNode();
        List<Node> NodesList();
        List<Node> NodesList(Node _currentNode);
        List<Arc> ArcsList();
        List<Arc> ArcsList(Node _currentNode);
        int NodesCount();
        double CostBetweenNodes(Node _fromNode, Node _toNode);
        String ReconstructPath();
        void ComputeEstimatedDistanceToExit();
        void Clear();
    }
}
