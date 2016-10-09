using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    public abstract class Node
    {
        private Node precursor = null;
        internal Node Precursor
        {
            get
            {
                return precursor;
            }
            set
            {
                precursor = value;
            }
        }
        private double distanceFromBegin = double.PositiveInfinity;
        internal double DistanceFromBegin
        {
            get
            {
                return distanceFromBegin;
            }
            set
            {
                distanceFromBegin = value;
            }
        }
        internal double EstimatedDistance { get; set; }
    }
}
