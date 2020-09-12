using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    class LinkedTree
    {
        private LinkedTreeNode root;
        public LinkedTree(MapNode node)
        {
            root = new LinkedTreeNode(null, node);
        }
    }
}
