using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace StateSpaceSearch
{
    public partial class OutputForm : Form
    {
        //store the search pattern used
        StateSearch search;
        //store the map ref
        Map workingMap;

        //set up the new form
        public OutputForm(Map m)
        {
            //set all the variables
            workingMap = m;


            InitializeComponent();
            this.Shown += new System.EventHandler(this.OutputForm_Shown);

            //This is just for me to learn how to draw in the window
            //Graphics dc = this.CreateGraphics();
            //this.Show();
            //Pen BluePen = new Pen(Color.Blue, 3);
            //dc.DrawRectangle(BluePen, 0, 0, 50, 50);
            //Pen RedPen = new Pen(Color.Red, 2);
            //dc.DrawEllipse(RedPen, 0, 50, 80, 60);

        }

        //set the search variable
        public void SetSearch(StateSearch stateSearch)
        {
            search = stateSearch;
        }

        //This will draw the Distance Graph.
        public void DrawDistanceGraph()
        {

        }

        //this will create a table for the distance graph
        public void CreateDistanceTable(List<MapNode> mapNodes, List<int> distances)
        {
            //initialiaze the output string
            string outputString = "";

            //create the header
            outputString += String.Format("|{0,-16}|{1,-12}|", "Node", "Distance");
            outputString += Environment.NewLine;

            //add each of the nodes and the distances
            for(int i = 0; i < mapNodes.Count; i++)
            {
                outputString += String.Format("|{0,-16}|{1,-12}|", mapNodes[i].CityName, distances[i]);
                outputString += Environment.NewLine;
            }

            outputString += Environment.NewLine;
            UpdateText(outputString);
        }

        //This will draw the Map
        public void DrawMap()
        {

        }
        //This will create a table to for the map
        public void CreateMapTable()
        {
            //This is version 1. Trying to look into a way that would make this prettier
            //Look into:
            //  Datatable (this might also allow for use with data grid view)
            //Did look into:
            //  stringformat 
            //      (this doesn't look like it is easy to do on the fly)
            //      Might be able to format pieces of the strings and join together
            //  Covert list to DataTable
            //      Similar to the Datatable. Just one possible method
            //  String interpolation
            //      don't think it will be easy to have this done on the fly

            //this method works by formatting bits and then adding them
            //Still has inconsisten spacing

            //create a blank string to add to
            string outputString = "";
            //get number of connections
            int connections = workingMap.getMaxConnections();

            //start adding the header
            //Went ahead and added 3 columns since there should be one connection
            outputString += String.Format("|{0,-16}|{1,-16}|{2,-12}|", "Node", "Branching to", "Distance");

            //add needed columns. start at 1 since already added 1 in the above line
            for (int i = 1; i < connections; i++)
            {
                outputString += String.Format("{0,-16}|{1,-12}|", "Branching to", "Distance");
            }
            //go to the next line for the first city
            outputString += Environment.NewLine;

            //cycle through the nodes and fill out the table
            foreach (MapNode mn in workingMap.nodes)
            {
                //add node to the first column
                outputString += String.Format("|{0,-16}|", mn.CityName);

                //get the neighbors
                List<MapNode> neighborList = mn.Neighbors;

                //add each neighbor and the distance to it
                foreach (MapNode neighbor in neighborList)
                {
                    outputString += String.Format("{0,-16}|{1,-12}|", neighbor.CityName, neighbor.distanceTo(mn));
                }

                //add empty columns if the city has less connections than the max number
                for(int i = 0; i < connections - mn.NumbBranches; i++)
                {
                    outputString += String.Format("{0,-16}|{1,-12}|", "", "");
                }

                //go to the next line for the next city
                outputString += Environment.NewLine;
            }
            //add a buffer before the search
            outputString += Environment.NewLine;

            //add the map table to the output textbox
            UpdateText(outputString);
        }

        //This will draw the tree at a given step
        //Tree will be supplied from the StateSearch
        public void DrawTree(LinkedTree tree)
        {

        }

        //This will update the text box at a given step
        //The string will be supplied by the StateSearch
        public void UpdateText(String updates)
        {
            textOuput.AppendText(updates);
        }

        //This may not be used
        //private void Searching_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //Saves the textbox to a text file for later viewing
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save the Text Output";
            saveFileDialog1.ShowDialog();

            //check if filename was given
            if(saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textOuput.Text);
            }
        }

        //Start the search once the window is open so that the user can see all the steps and not miss a few at the beginnig
        private void OutputForm_Shown(Object sender, EventArgs e)
        {
            //Add a timer so that the search doesn't start right when the window opens??
            CreateMapTable();
            search.Search();
        }
    }
}
