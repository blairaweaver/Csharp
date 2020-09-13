using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    public class LinkedTreeNode
    {
        private LinkedTreeNode parentNode;
        private List<LinkedTreeNode> childNodes;
        private MapNode mapNodeEquilvalent;

        public LinkedTreeNode(LinkedTreeNode parent, MapNode m)
        {
            parentNode = parent;
            mapNodeEquilvalent = m;
            childNodes = new List<LinkedTreeNode>();
        }

        public void AddChildNode(LinkedTreeNode child)
        {
            childNodes.Add(child);
        }

        public LinkedTreeNode GetParent()
        {
            return parentNode;
        }
        public MapNode GetMapNode()
        {
            return mapNodeEquilvalent;
        }

        //This should only be for a repeat node
        public void RemoveChild(LinkedTreeNode child)
        {
            childNodes.Remove(child);
        }

        public Boolean SameNode(LinkedTreeNode node)
        {
            return this.mapNodeEquilvalent == node.mapNodeEquilvalent;
        }
    }
}
