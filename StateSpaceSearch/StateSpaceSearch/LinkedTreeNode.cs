using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    public class LinkedTreeNode : IComparable, IEquatable<LinkedTreeNode>
    {
        private LinkedTreeNode parentNode;
        private List<LinkedTreeNode> childNodes;
        private MapNode mapNodeEquilvalent;
        private int distanceToRoot;

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

        public override string ToString()
        {
            return mapNodeEquilvalent.ToString();
        }

        //implements IComparable interface and allows for comparison
        public int CompareTo(object obj)
        {
            if (obj is LinkedTreeNode)
            {
                return this.mapNodeEquilvalent.CompareTo((obj as LinkedTreeNode).mapNodeEquilvalent);
            }
            throw new ArgumentException("Object is not a Linked Tree Node");
        }

        //Everything below here is so that two map nodes can be compared consistently
        //see https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals?view=netcore-3.1
        public bool Equals(LinkedTreeNode other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.mapNodeEquilvalent == other.mapNodeEquilvalent)
            {
                return true;
            }
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            LinkedTreeNode LinkedTreeNodeObj = obj as LinkedTreeNode;
            if (LinkedTreeNodeObj == null)
                return false;
            else
                return Equals(LinkedTreeNodeObj);
        }

        public override int GetHashCode()
        {
            return this.mapNodeEquilvalent.GetHashCode();
        }

        public static bool operator ==(LinkedTreeNode LinkedTreeNode1, LinkedTreeNode LinkedTreeNode2)
        {
            if (((object)LinkedTreeNode1) == null || ((object)LinkedTreeNode2) == null)
                return Object.Equals(LinkedTreeNode1, LinkedTreeNode2);

            return LinkedTreeNode1.Equals(LinkedTreeNode2);
        }

        public static bool operator !=(LinkedTreeNode LinkedTreeNode1, LinkedTreeNode LinkedTreeNode2)
        {
            if (((object)LinkedTreeNode1) == null || ((object)LinkedTreeNode2) == null)
                return !Object.Equals(LinkedTreeNode1, LinkedTreeNode2);

            return !(LinkedTreeNode1.Equals(LinkedTreeNode2));
        }
    }
}
