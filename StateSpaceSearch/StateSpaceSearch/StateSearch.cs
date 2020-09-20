using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace StateSpaceSearch
{
    //using interface for StateSearch to follow the Strategy Pattern to allow for adding more methods of search in the future
    public interface StateSearch
    {
        public void Search();
        

    }

    public class DepthFirstSearch : StateSearch
    {

        //Store the start and end city
        MapNode startCity, destCity;
        //String to store updates
        String updateString = "";
        //use stack for the queue since it operates as FILO
        Stack<LinkedTreeNode> nodes;
        //To store the tree which will be given to the output form to draw
        LinkedTree tree;
        //Store the output form so the class knows where to send updates
        OutputForm output;
        public DepthFirstSearch(MapNode startCity, MapNode endCity, OutputForm output)
        {
            this.startCity = startCity;
            this.destCity = endCity;
            this.output = output;
            //Initialize the tree
            tree = new LinkedTree(startCity);
            //Initialize the queue and add start city
            nodes = new Stack<LinkedTreeNode>();
            nodes.Push(tree.Root);

        }
        public void Search()
        {
            //set the goal node to null at the beginning of each search
            LinkedTreeNode goalNode = null;

            //continue until queue is empty
            while (nodes.Count != 0)
            {
                //create the string output. Having it in the loop will clear it after each step
                string treeOutput = "";
                //need to add the queue to the output
                treeOutput += "Queue at start" + Environment.NewLine + "Front   ";
                foreach(LinkedTreeNode ln in nodes)
                {
                    treeOutput += ln.ToString() + "   ";
                }
                treeOutput += "   End" + Environment.NewLine + Environment.NewLine;
                //create a list to keep track of newly created linked list nodes that may be removed
                //I would prefer to just check nodes when made, but for the professor's output,
                //all nodes will be added and then check for loops
                List<LinkedTreeNode> newlyCreatedNodes = new List<LinkedTreeNode>();

                //get a linked tree node from the queue
                LinkedTreeNode workingNode = nodes.Pop();

                //Add the updated queue to the output
                treeOutput += "Queue after taking an element" + Environment.NewLine + "Front   ";
                foreach (LinkedTreeNode ln in nodes)
                {
                    treeOutput += ln.ToString() + "   ";
                }
                treeOutput += "   End" + Environment.NewLine + Environment.NewLine;

                //get the neighbors
                List<MapNode> neighborList = workingNode.GetMapNode().Neighbors;

                //start creating the next line of output
                //which will show what the node we pulled from the queue
                //And all nodes that are attached to it
                treeOutput += workingNode.ToString() + "(";

                //make a new linked tree node for each neighbor
                foreach(MapNode mn in neighborList)
                {
                    newlyCreatedNodes.Add(tree.AddNode(workingNode, mn));
                    treeOutput += mn.ToString() + ", ";
                }
                //remove the last comma that was added
                treeOutput = treeOutput.Remove(treeOutput.Length - 2);
                treeOutput += ")" + Environment.NewLine;

                //check to see if there are any loops
                //can't use foreach since that doesn't allow you to modify the list
                for(int i = 0; i < newlyCreatedNodes.Count; i++)
                {
                    //pass the parent node and one of the nodes that was just created
                    if (tree.IsALoop(workingNode, newlyCreatedNodes[i]))
                    {
                        //remove the node from tree and list since it is a loop
                        //I do both since I will use the list for the text output
                        //and the tree for the graphical output
                        tree.RemoveNode(newlyCreatedNodes[i]);
                        newlyCreatedNodes.Remove(newlyCreatedNodes[i]);
                        i--;
                    }
                }
                //add a new line to the output to show the changes
                //will also add the nodes to the queue now
                treeOutput += "After rejecting Loops" + Environment.NewLine;
                treeOutput += workingNode.ToString() + "(";
                foreach (LinkedTreeNode ln in newlyCreatedNodes)
                {
                    treeOutput += ln.ToString() + ", ";
                    nodes.Push(ln);
                    //check to see if we found the destination
                    if(destCity == ln.GetMapNode())
                    {
                        goalNode = ln;
                    }
                }
                //If there was nothing in the list, then we shouldn't remove stuff
                if(newlyCreatedNodes.Count != 0)
                {
                    //remove the last comma that was added
                    treeOutput = treeOutput.Remove(treeOutput.Length - 2);
                }
                treeOutput += ")" + Environment.NewLine + Environment.NewLine;

                //send the output after each step
                output.UpdateText(treeOutput);

                //if we found the goal
                if(goalNode != null)
                {
                    //need to break from the while loop
                    //need to print path
                    PrintPath(goalNode);
                    break;
                }
            }
        }

        //function to build the string and aend it to the output
        private void PrintPath(LinkedTreeNode goal)
        {
            //create string builder (this will allow us to add to the beginning
            StringBuilder outputString = new StringBuilder();

            //get the path
            FindPath(outputString, goal);

            //Add a bit of text at the beginning
            outputString.Insert(0, "The Path is:" + Environment.NewLine);

            //send the output
            output.UpdateText(outputString.ToString());
        }

        //recursive function to get the path
        private void FindPath(StringBuilder output, LinkedTreeNode treeNode)
        {
            if(treeNode.GetParent() == null)
            {
                output.Insert(0, treeNode.ToString());
            }
            else
            {
                output.Insert(0, "-" + treeNode.ToString());
                FindPath(output, treeNode.GetParent());
            }
        }


    }

    public class AStarSearch : StateSearch
    {
        //Store the start and end city
        MapNode startCity, destCity;
        //String to store updates
        String updateString = "";
        //These two list will form the distance graph
        List<MapNode> distanceGraphNodes;
        List<int> distanceGraphValues;
        //To store the tree which will be given to the output form to draw
        LinkedTree tree;
        //Store the output form so the class knows where to send updates
        OutputForm output;
        //will need custom queue
        //queue needs to sort at the end by distance
        AStarQueue nodes;
        public AStarSearch(MapNode startCity, MapNode endCity, OutputForm output)
        {
            this.startCity = startCity;
            this.destCity = endCity;
            this.output = output;
            //Initialize list
            distanceGraphNodes = new List<MapNode>();
            distanceGraphValues = new List<int>();
            //Create the distance Graph
            createDistanceGraph();
            //send the distance graph to the output
            output.CreateDistanceTable(distanceGraphNodes, distanceGraphValues);
            //Initialize the tree
            tree = new LinkedTree(startCity);
            //Initialize the queue
            nodes = new AStarQueue(tree.Root);
        }
        public void Search()
        {
            //set the goal node to null at the beginning of each search
            LinkedTreeNode goalNode = null;
            //this is the distance traveled by the goal node so this doesn't have to be calculated over and over again
            //set to max value for start
            int goalDistance = int.MaxValue;

            //continue until queue is empty
            while (nodes.Count() != 0)
            {
                //initialize the string for each step
                string treeOutput = "";

                //add the queue to the output
                treeOutput += "Queue at start" + Environment.NewLine + "Front   ";
                foreach(LinkedTreeNode ln in nodes)
                {
                    treeOutput += ln.ToString() + "   ";
                }
                treeOutput += "End" + Environment.NewLine + Environment.NewLine;

                //create a list to keep track of newly created linked list nodes that may be removed
                List<LinkedTreeNode> newlyCreatedNodes = new List<LinkedTreeNode>();

                //get a linked tree node from the queue
                LinkedTreeNode workingNode = nodes.Pop();

                //get out of the loop at this point, because this means we have found the shortest route
                if(tree.DistanceTraveled(workingNode) >= goalDistance)
                {
                    break;
                }

                //Add the updated queue to the output
                treeOutput += "Queue after taking an element" + Environment.NewLine + "Front   ";
                foreach (LinkedTreeNode ln in nodes)
                {
                    treeOutput += ln.ToString() + "   ";
                }
                treeOutput += "End" + Environment.NewLine + Environment.NewLine;

                //get the neighbors
                List<MapNode> neighborList = workingNode.GetMapNode().Neighbors;

                //start creating the next line of output
                //which will show what the node we pulled from the queue
                //And all nodes that are attached to it
                treeOutput += workingNode.ToString() + "(";

                //make a new linked tree node for each neighbor
                foreach (MapNode mn in neighborList)
                {
                    newlyCreatedNodes.Add(tree.AddNode(workingNode, mn));
                    treeOutput += mn.ToString() + ", ";
                }
                //remove the last comma that was added
                treeOutput = treeOutput.Remove(treeOutput.Length - 2);
                treeOutput += ")" + Environment.NewLine;

                //REMOVE LOOPS HERE
                //check to see if there are any loops
                //can't use foreach since that doesn't allow you to modify the list
                for (int i = 0; i < newlyCreatedNodes.Count; i++)
                {
                    //pass the parent node and one of the nodes that was just created
                    if (tree.IsALoop(workingNode, newlyCreatedNodes[i]))
                    {
                        //remove the node from tree and list since it is a loop
                        //I do both since I will use the list for the text output
                        //and the tree for the graphical output
                        tree.RemoveNode(newlyCreatedNodes[i]);
                        newlyCreatedNodes.Remove(newlyCreatedNodes[i]);
                        i--;
                    }
                }
                //create a list to hold the distances so they aren't calculated twice
                List<int> tempDist = new List<int>();
                //Add a line showing the nodes and the calculated distances
                //also add them to the queueu
                treeOutput += "After rejecting Loops" + Environment.NewLine;
                treeOutput += workingNode.ToString() + "(";
                for(int i = 0; i < newlyCreatedNodes.Count; i++)
                {

                    tempDist.Add(GetDistance(newlyCreatedNodes[i]));
                    treeOutput += newlyCreatedNodes[i].ToString() + ":" + tempDist[i]+ ", ";

                    //adding 
                    nodes.Add(newlyCreatedNodes[i], tempDist[i]);
                    //also check to see if we hit the goal
                    if (destCity == newlyCreatedNodes[i].GetMapNode())
                    {
                        //check and see if the distance travaled to this nodes is shorter than what we already have
                        //this can be more, because the distance we check above is for the parent.
                        if (tempDist[i] < goalDistance)
                        {
                            //update the goal node with the new tree node
                            goalNode = newlyCreatedNodes[i];
                            //update the distance that we used to get here
                            goalDistance = tempDist[i];
                        }
                    }
                }
                //If there was nothing in the list, then we shouldn't remove stuff
                if (newlyCreatedNodes.Count != 0)
                {
                    //remove the last comma that was added
                    treeOutput = treeOutput.Remove(treeOutput.Length - 2);
                }
                treeOutput += ")" + Environment.NewLine;

                //Show Updated Queue
                //Add the updated queue to the output
                treeOutput += "Queue after adding elements" + Environment.NewLine + "Front   ";
                foreach (LinkedTreeNode ln in nodes)
                {
                    treeOutput += ln.ToString() + "   ";
                }
                treeOutput += "End" + Environment.NewLine + Environment.NewLine;

                //Remove Duplicates
                nodes.RemoveDuplicates();

                //show the queue after removing duplicates
                //Add the updated queue to the output
                treeOutput += "Queue after removing duplicate elements" + Environment.NewLine + "Front   ";
                foreach (LinkedTreeNode ln in nodes)
                {
                    treeOutput += ln.ToString() + "   ";
                }
                treeOutput += "End" + Environment.NewLine + Environment.NewLine;

                //send the output after each step
                output.UpdateText(treeOutput);
            }

            //we are out of the while loop
            //check to see if there is a goal node
            //if so, then print the path
            if (goalNode != null)
            {
                PrintPath(goalNode);
            }
        }

        //This returns the distance. Helps get the code cleaner
        private int GetDistance(LinkedTreeNode linkedTreeNode)
        {
            return distanceGraphValues[distanceGraphNodes.IndexOf(linkedTreeNode.GetMapNode())] + tree.DistanceTraveled(linkedTreeNode);
        }
        //function to build the string and aend it to the output
        private void PrintPath(LinkedTreeNode goal)
        {
            //create string builder (this will allow us to add to the beginning
            StringBuilder outputString = new StringBuilder();

            //get the path
            FindPath(outputString, goal);

            //Add a bit of text at the beginning
            outputString.Insert(0, "The Path is:" + Environment.NewLine);

            //send the output
            output.UpdateText(outputString.ToString());
        }

        //recursive function to get the path
        private void FindPath(StringBuilder output, LinkedTreeNode treeNode)
        {
            if (treeNode.GetParent() == null)
            {
                output.Insert(0, treeNode.ToString());
            }
            else
            {
                output.Insert(0, "-" + treeNode.ToString());
                FindPath(output, treeNode.GetParent());
            }
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
            foreach (MapNode m in destCity.Neighbors)
            {
                myQ.Enqueue(m);
            }

            while (myQ.Count > 0)
            {
                //get next node
                MapNode workingNode = myQ.Dequeue();
                //get the neighbors of that node
                List<MapNode> workingNeighbors = workingNode.Neighbors;

                //if working node is neighbor to destination, just add values
                if (workingNode.isNeighbor(destCity))
                {
                    distanceGraphNodes.Add(workingNode);
                    distanceGraphValues.Add(workingNode.distanceTo(destCity));

                }
                //else, calculate the value
                else
                {
                    //find a neighbor that has been done
                    foreach (MapNode m in workingNeighbors)
                    {
                        //if find one, calculate
                        if (distanceGraphNodes.Contains(m))
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
    }
}
