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
            Graphics dc = this.CreateGraphics();
            //this.Show();
            Pen BluePen = new Pen(Color.Blue, 3);
            dc.DrawRectangle(BluePen, 0, 0, 50, 50);
            Pen RedPen = new Pen(Color.Red, 2);
            dc.DrawEllipse(RedPen, 0, 50, 80, 60);

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

        //This will draw the Map
        public void DrawMap()
        {

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
            search.Search();
        }
    }
}
