using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StateSpaceSearch
{
    //using interface for StateSearch to follow the Strategy Pattern to allow for adding more methods of search in the future
    public interface StateSearch
    {
        public void search();
    }

    //
    public class DepthFirstSearch : StateSearch
    {
        //use stack
        Stack<LinkedTreeNode> nodes;
        public void search()
        {

        }
    }

    public class AStarSearch : StateSearch
    {
        //will need custom queue
        //queue needs to sort at the end by distance
        public void search()
        {

        }
    }
    public partial class Searching : Form
    {
        //store the search pattern used
        StateSearch search;
        //store the map ref
        Map workingMap;
        //store the cities
        MapNode startCity;
        MapNode destCity;
        //These two list will form the distance graph
        List<MapNode> distanceGraphNodes;
        List<int> distanceGraphValues;

        //set up the new form
        public Searching(Map m, int searchMethod, MapNode start, MapNode dest)
        {
            //set all the variables
            workingMap = m;
            startCity = start;
            destCity = dest;
            switch(searchMethod)
            {
                case 0:
                    search = new AStarSearch();
                    break;
                case 1:
                    search = new DepthFirstSearch();
                    break;
            }
            //Initialize list
            distanceGraphNodes = new List<MapNode>();
            distanceGraphValues = new List<int>();

            //create distance graph
            createDistanceGraph();

            InitializeComponent();
        }

        //method to create distance graph. This goes from the dest and works out
        //The distance is estimated by using the equation 2a + 2b = 2c
        //where 
        //a is distance to a neighbor that has already been done
        //b is the calculated distance from that neighbor to the destination
        //c is the calculated distance from this node to the desination
        //
        //This is only an approximation used for the assignment and doesn't take into account any angles
        //didn't use squares in order to cut done on complexity since these are just estimates
        private void createDistanceGraph()
        {
            //used to keep track of those that need to be done
            Queue<MapNode> myQ = new Queue<MapNode>();

            //add the start city 
            distanceGraphNodes.Add(destCity);
            distanceGraphValues.Add(0);
            //add start city's neighbors to queue. Don't have to check for duplicates yet
            foreach(MapNode m in destCity.getNeighbors())
            {
                myQ.Enqueue(m);
            }

            while(myQ.Count > 0)
            {
                //get next node
                MapNode workingNode = myQ.Dequeue();
                //get the neighbors of that node
                List<MapNode> workingNeighbors = workingNode.getNeighbors();

                //if working node is neighbor to destination, just add values
                if(workingNode.isNeighbor(destCity))
                {
                    distanceGraphNodes.Add(workingNode);
                    distanceGraphValues.Add(workingNode.distanceTo(destCity));
                    
                }
                //else, calculate the value
                else
                {
                    //find a neighbor that has been done
                    foreach(MapNode m in workingNeighbors)
                    {
                        //if find one, calculate
                        if(distanceGraphNodes.Contains(m))
                        {
                            //calculate
                            int calDis = (workingNode.distanceTo(m) * 2 + distanceGraphValues[distanceGraphNodes.IndexOf(m)] * 2) / 2;
                            
                            //add value and node to graph
                            distanceGraphValues.Add(calDis);
                            distanceGraphNodes.Add(workingNode);
                            
                            //exit foreach loop
                            break;
                        }
                    }

                }

                //add any neighbor from this node that hasn't been done or is in queue to be done
                foreach (MapNode m in workingNeighbors)
                {
                    if (distanceGraphNodes.Contains(m) || myQ.Contains(m))
                    {
                        //don't do anything
                    }
                    else
                    {
                        myQ.Enqueue(m);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
