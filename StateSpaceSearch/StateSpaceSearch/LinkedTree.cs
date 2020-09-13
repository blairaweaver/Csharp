using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    public class LinkedTree
    {
        private LinkedTreeNode root;
        public LinkedTree(MapNode node)
        {
            root = new LinkedTreeNode(null, node);
        }

        //will return the new linkedtreenode so that the search function can delete the node later if there is a loop
        public LinkedTreeNode AddNode(LinkedTreeNode parent, MapNode newLeaf)
        {
            return new LinkedTreeNode(parent, newLeaf);
        }

        public void RemoveNode(LinkedTreeNode node)
        {
            //get the parent and then tell parent to remove it from the list
            node.GetParent().RemoveChild(node);
        }

        //see if a loop is formed
        //this works by checking the current to see if it matches the node we are looking for
        //In the first call to this, give the parent node and the new node
        public Boolean IsALoop(LinkedTreeNode currentNode, LinkedTreeNode nodeToMatch)
        {
            if(currentNode == root)
            {
                return currentNode == nodeToMatch;
            }
            if (currentNode == nodeToMatch)
            {
                return true;
            }
            else
            {
                return IsALoop(currentNode.GetParent(), nodeToMatch);
            }
        }
    }
}
