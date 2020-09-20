using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace StateSpaceSearch
{
    class AStarQueue : IEnumerable<LinkedTreeNode>
    {
        

        List<AStarQueueNode> queue;
        public AStarQueue(LinkedTreeNode treeNode)
        {
            queue = new List<AStarQueueNode>();
            queue.Add(new AStarQueueNode(treeNode, 0));
        }

        //add a new item to the queue
        public void Add(LinkedTreeNode treeNode, int distance)
        {
            queue.Add(new AStarQueueNode(treeNode, distance));
            sort();
        }

        private void sort()
        {
            queue.Sort();
        }

        //grab the first item from list and return it
        //this will remove it at the same time
        public LinkedTreeNode Pop()
        {
            LinkedTreeNode treeNode = queue[0].TreeNode;
            queue.RemoveAt(0);
            return treeNode;
        }

        //return the number in the queue
        public int Count()
        {
            return queue.Count;
        }

        public void RemoveDuplicates()
        {
            //make a temp list to hold all cities we have seen
            List<MapNode> temp = new List<MapNode>();
            for(int i = 0; i < queue.Count; i++)
            {
                //grab the map node for the next item
                MapNode mapNode = queue[i].TreeNode.GetMapNode();
                //check if we have seen this a node with this city
                //since this is sorted by distance, if we have already seen it
                //then the new node is farther away and should be removed
                if (temp.Contains(mapNode))
                {
                    //remove and update index
                    queue.RemoveAt(i);
                    i--;
                }
                //since we haven't seen it, add to the temp list
                else
                {
                    temp.Add(mapNode);
                }
            }
        }

        public IEnumerator<LinkedTreeNode> GetEnumerator()
        {
            foreach (AStarQueueNode queueNode in queue)
            {
                yield return queueNode.TreeNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
