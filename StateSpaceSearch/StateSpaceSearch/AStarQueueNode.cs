using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    //define the nodes used in the queue
    public class AStarQueueNode : IComparable
    {
        private LinkedTreeNode treeNode;
        public LinkedTreeNode TreeNode
        {
            get { return treeNode; }
        }
        private int distance;
        public int Distance
        {
            get { return distance; }
        }
        public AStarQueueNode(LinkedTreeNode treeNode, int distance)
        {
            this.treeNode = treeNode;
            this.distance = distance;
        }

        //implements IComparable interface and allows for comparison
        public int CompareTo(object obj)
        {
            if (obj is AStarQueueNode)
            {
                return this.distance.CompareTo((obj as AStarQueueNode).Distance);
            }
            throw new ArgumentException("Object is not a A* Queue Node");
        }
    }
}
