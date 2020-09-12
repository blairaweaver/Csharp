using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    class LinkedTreeNode
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

        public void addChildNode(LinkedTreeNode child)
        {
            childNodes.Add(child);
        }

        public LinkedTreeNode getParent()
        {
            return parentNode;
        }
        public MapNode getMapNode()
        {
            return mapNodeEquilvalent;
        }
    }
}
