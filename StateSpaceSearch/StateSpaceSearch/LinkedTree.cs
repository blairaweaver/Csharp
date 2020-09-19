using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    public class LinkedTree
    {
        private LinkedTreeNode root;
        public LinkedTreeNode Root
        {
            get { return root; }
        }
        public LinkedTree(MapNode node)
        {
            root = new LinkedTreeNode(null, node);
        }

        //create a new node and tell the parent that it has a new child
        //will return the new linkedtreenode so that the search function can delete the node later if there is a loop
        public LinkedTreeNode AddNode(LinkedTreeNode parent, MapNode newLeaf)
        {
            LinkedTreeNode treeNode = new LinkedTreeNode(parent, newLeaf);
            parent.AddChildNode(treeNode);
            return treeNode;
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
            //if we are at the root, just return if they match or not
            //root.Equals(currentNode)
            if (currentNode == root) //old code: currentNode == root (didn't work)
            {
                return currentNode == nodeToMatch;
            }
            //if we have a match, return true and don't continue
            if (currentNode == nodeToMatch) //NEED TO CHECK IF THIS WORKS!!!
            {
                return true;
            }
            //if not at root and don't have a match, check the parent
            else
            {
                return IsALoop(currentNode.GetParent(), nodeToMatch);
            }
        }
    }
}
