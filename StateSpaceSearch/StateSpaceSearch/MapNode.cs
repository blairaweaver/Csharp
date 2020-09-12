using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    public class MapNode : IComparable
    {
        private string cityName;
        private List<MapNode> neighbors;
        private List<int> distances;

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
        }

        //return the neighbor list so that they can be added to the queue
        public List<MapNode> getNeighbors()
        {
            return neighbors;
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

    }
}
