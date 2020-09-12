using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateSpaceSearch
{
    public partial class Form1 : Form
    {
        private Map m;
        private Searching searchForm;

        public Form1()
        {
            //initiliaze form
            InitializeComponent();
            //create the map
            m = new Map();
            //fill the drop boxes
            startComboBox.Items.AddRange(m.nodes);
            destComboBox.Items.AddRange(m.nodes);

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            //check to make sure the user selects two different cities
            if (startComboBox.SelectedItem == null || destComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select both a Starting City and Destination City");
                return;
            }
            if (startComboBox.SelectedItem == destComboBox.SelectedItem)
            {
                MessageBox.Show("Please select different cities");
                return;
            }

            
            //create the new form which will do the searching
            if (aStarRadioButton.Checked == true)
            {
                searchForm = new Searching(m, 0, m.nodes[startComboBox.SelectedIndex], m.nodes[destComboBox.SelectedIndex]);
            }
            else
            {
                searchForm = new Searching(m, 0, m.nodes[startComboBox.SelectedIndex], m.nodes[destComboBox.SelectedIndex]);
            }


            searchForm.Show();
        }
    }
}
