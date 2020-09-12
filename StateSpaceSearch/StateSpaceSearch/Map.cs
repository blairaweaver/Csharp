using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    //This class doesn't allow for a custom map. This creates the map given
    //Could modify to read in from a file such as xml. Future edit?
    public class Map
    {
        //Holds all the nodes in array
        public MapNode[] nodes;

        //create the map
        public Map()
        {
            nodes = new MapNode[19];
            createNodes();
            createConnections();
            //sort the array by name
            Array.Sort(nodes);
        }

        //create the nodes and add them to the array
        private void createNodes()
        {
            nodes[0] = new MapNode("Oklahoma City");
            nodes[1] = new MapNode("Dallas");
            nodes[2] = new MapNode("Houston");
            nodes[3] = new MapNode("Little Rock");
            nodes[4] = new MapNode("Springfield");
            nodes[5] = new MapNode("St. Louis");
            nodes[6] = new MapNode("Memphis");
            nodes[7] = new MapNode("Jackson");
            nodes[8] = new MapNode("New Orleans");
            nodes[9] = new MapNode("Mobile");
            nodes[10] = new MapNode("Tallahassee");
            nodes[11] = new MapNode("Montgomery");
            nodes[12] = new MapNode("Birmingham");
            nodes[13] = new MapNode("Atlanta");
            nodes[14] = new MapNode("Knoxville");
            nodes[15] = new MapNode("Nashville");
            nodes[16] = new MapNode("Louisville");
            nodes[17] = new MapNode("Cincinati");
            nodes[18] = new MapNode("Indianapolis");


        }

        //adds all the connections to the nodes
        private void createConnections()
        {
            //Oklahoma City connections
            nodes[0].addNeighbor(nodes[4], 283);
            nodes[0].addNeighbor(nodes[3], 336);
            nodes[0].addNeighbor(nodes[1], 208);

            //Dallas connections
            nodes[1].addNeighbor(nodes[0], 208);
            nodes[1].addNeighbor(nodes[4], 420);
            nodes[1].addNeighbor(nodes[3], 315);
            nodes[1].addNeighbor(nodes[7], 417);
            nodes[1].addNeighbor(nodes[8], 509);
            nodes[1].addNeighbor(nodes[2], 237);

            //Houston connections
            nodes[2].addNeighbor(nodes[1], 237);
            nodes[2].addNeighbor(nodes[3], 442);
            nodes[2].addNeighbor(nodes[8], 363);

            //Little Rock connections
            nodes[3].addNeighbor(nodes[0], 336);
            nodes[3].addNeighbor(nodes[1], 315);
            nodes[3].addNeighbor(nodes[2], 442);
            nodes[3].addNeighbor(nodes[4], 219);
            nodes[3].addNeighbor(nodes[6], 138);
            nodes[3].addNeighbor(nodes[7], 267);
            nodes[3].addNeighbor(nodes[5], 350);

            //Springfield connections
            nodes[4].addNeighbor(nodes[0], 283);
            nodes[4].addNeighbor(nodes[1], 420);
            nodes[4].addNeighbor(nodes[3], 219);
            nodes[4].addNeighbor(nodes[5], 224);
            nodes[4].addNeighbor(nodes[6], 281);

            //St. Louis connections
            nodes[5].addNeighbor(nodes[3], 350);
            nodes[5].addNeighbor(nodes[4], 224);
            nodes[5].addNeighbor(nodes[6], 283);
            nodes[5].addNeighbor(nodes[15], 312);
            nodes[5].addNeighbor(nodes[16], 244);
            nodes[5].addNeighbor(nodes[17], 353);
            nodes[5].addNeighbor(nodes[18], 244);

            //Memphis connections
            nodes[6].addNeighbor(nodes[3], 138);
            nodes[6].addNeighbor(nodes[4], 281);
            nodes[6].addNeighbor(nodes[5], 283);
            nodes[6].addNeighbor(nodes[7], 217);
            nodes[6].addNeighbor(nodes[12], 241);
            nodes[6].addNeighbor(nodes[13], 394);
            nodes[6].addNeighbor(nodes[15], 208);

            //Jackson connections
            nodes[7].addNeighbor(nodes[1], 417);
            nodes[7].addNeighbor(nodes[3], 267);
            nodes[7].addNeighbor(nodes[6], 217);
            nodes[7].addNeighbor(nodes[8], 183);
            nodes[7].addNeighbor(nodes[11], 251);
            nodes[7].addNeighbor(nodes[12], 234);

            //New Orleans connections
            nodes[8].addNeighbor(nodes[1], 509);
            nodes[8].addNeighbor(nodes[7], 183);
            nodes[8].addNeighbor(nodes[2], 363);
            nodes[8].addNeighbor(nodes[9], 153);
            nodes[8].addNeighbor(nodes[12], 354);

            //Mobile connections
            nodes[9].addNeighbor(nodes[8], 153);
            nodes[9].addNeighbor(nodes[10], 354);
            nodes[9].addNeighbor(nodes[11], 171);

            //Tallahassee connections
            nodes[10].addNeighbor(nodes[9], 354);
            nodes[10].addNeighbor(nodes[11], 208);
            nodes[10].addNeighbor(nodes[13], 275);

            //Mongomery connections
            nodes[11].addNeighbor(nodes[7], 251);
            nodes[11].addNeighbor(nodes[9], 171);
            nodes[11].addNeighbor(nodes[10], 208);
            nodes[11].addNeighbor(nodes[12], 92);
            nodes[11].addNeighbor(nodes[13], 161);

            //Birmingham connections
            nodes[12].addNeighbor(nodes[6], 241);
            nodes[12].addNeighbor(nodes[7], 234);
            nodes[12].addNeighbor(nodes[8], 354);
            nodes[12].addNeighbor(nodes[11], 92);
            nodes[12].addNeighbor(nodes[13], 149);
            nodes[12].addNeighbor(nodes[15], 192);

            //Atlanta connections
            nodes[13].addNeighbor(nodes[6], 394);
            nodes[13].addNeighbor(nodes[10], 275);
            nodes[13].addNeighbor(nodes[11], 161);
            nodes[13].addNeighbor(nodes[12], 149);
            nodes[13].addNeighbor(nodes[14], 230);
            nodes[13].addNeighbor(nodes[15], 252);

            //Knoxville connections
            nodes[14].addNeighbor(nodes[13], 230);
            nodes[14].addNeighbor(nodes[15], 177);
            nodes[14].addNeighbor(nodes[17], 254);

            //Nashville connections
            nodes[15].addNeighbor(nodes[5], 312);
            nodes[15].addNeighbor(nodes[6], 208);
            nodes[15].addNeighbor(nodes[12], 192);
            nodes[15].addNeighbor(nodes[13], 252);
            nodes[15].addNeighbor(nodes[14], 177);
            nodes[15].addNeighbor(nodes[16], 180);

            //Louisville connections
            nodes[16].addNeighbor(nodes[5], 244);
            nodes[16].addNeighbor(nodes[15], 180);
            nodes[16].addNeighbor(nodes[17], 102);
            nodes[16].addNeighbor(nodes[18], 113);

            //Cincinati connections
            nodes[17].addNeighbor(nodes[5], 353);
            nodes[17].addNeighbor(nodes[14], 254);
            nodes[17].addNeighbor(nodes[16], 102);
            nodes[17].addNeighbor(nodes[18], 108);

            //Indianapolis connections
            nodes[18].addNeighbor(nodes[5], 244);
            nodes[18].addNeighbor(nodes[16], 113);
            nodes[18].addNeighbor(nodes[17], 108);
        }
    }
}
