using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    public class MapNode : IComparable, IEquatable<MapNode>
    {
        //set variables and properties for variables
        private string cityName;
        public string CityName
        {
            get { return cityName; }
        }
        private List<MapNode> neighbors;
        public List<MapNode> Neighbors
        {
            get { return neighbors; }
        }
        private List<int> distances;
        private int numBranches = 0;
        public int NumbBranches
        {
            get { return numBranches; }
        }

        public MapNode(string cityName)
        {
            this.cityName = cityName;
            neighbors = new List<MapNode>();
            distances = new List<int>();
        }

        //Creates connections between this node and another node
        public void addNeighbor(MapNode cityNode, int distance)
        {
            neighbors.Add(cityNode);
            distances.Add(distance);
            numBranches++;
        }

        //Return string returns the cityName. This is used by the combo box to display the objects
        public override string ToString()
        {
            return cityName;
        }

        //returns if this node is connected to another node
        public Boolean isNeighbor(MapNode node)
        {
            return neighbors.Contains(node);
        }

        //get distance from this node to a neighbor node
        public int distanceTo(MapNode node)
        {
            return distances[neighbors.IndexOf(node)];
        }

        //implements IComparable interface and allows for comparison
        public int CompareTo(object obj)
        {
            if (obj is MapNode)
            {
                return this.cityName.CompareTo((obj as MapNode).cityName);
            }
            throw new ArgumentException("Object is not a Map Node");
        }

        //Everything below here is so that two map nodes can be compared consistently
        //see https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals?view=netcore-3.1
        public bool Equals(MapNode other)
        {
            if(other == null)
            {
                return false;
            }
            if (this.cityName == other.CityName)
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

            MapNode MapNodeObj = obj as MapNode;
            if (MapNodeObj == null)
                return false;
            else
                return Equals(MapNodeObj);
        }

        public override int GetHashCode()
        {
            return this.CityName.GetHashCode();
        }

        public static bool operator ==(MapNode MapNode1, MapNode MapNode2)
        {
            if (((object)MapNode1) == null || ((object)MapNode2) == null)
                return Object.Equals(MapNode1, MapNode2);

            return MapNode1.Equals(MapNode2);
        }

        public static bool operator !=(MapNode MapNode1, MapNode MapNode2)
        {
            if (((object)MapNode1) == null || ((object)MapNode2) == null)
                return !Object.Equals(MapNode1, MapNode2);

            return !(MapNode1.Equals(MapNode2));
        }
    }
}
