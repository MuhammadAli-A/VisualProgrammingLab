using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab06
{
    public partial class Form1 : Form
    {
        // Declare the list to store data
        private List<string> dataList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string inputData = txtInput.Text.Trim();
            if (!string.IsNullOrEmpty(inputData))
            {
                if (!dataList.Contains(inputData))
                {
                    dataList.Add(inputData);
                    UpdateListBox(); // Update ListBox with numbering
                    MessageBox.Show($"'{inputData}' has been added to the list.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"'{inputData}' is already in the list.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                txtInput.Clear();
            }
            else
            {
                MessageBox.Show("Please enter an item to add.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string inputData = txtInput.Text.Trim();
            if (dataList.Contains(inputData))
            {
                dataList.Remove(inputData);
                UpdateListBox(); // Update ListBox with numbering
                MessageBox.Show($"'{inputData}' has been removed from the list.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtInput.Clear();
            }
            else
            {
                MessageBox.Show($"'{inputData}' was not found in the list.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string inputData = txtInput.Text.Trim();
            if (dataList.Contains(inputData))
            {
                MessageBox.Show($"'{inputData}' exists in the list.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Highlight the item in the ListBox
                int index = dataList.IndexOf(inputData);
                if (index >= 0)
                {
                    listBoxItems.SetSelected(index, true);
                }
            }
            else
            {
                MessageBox.Show($"'{inputData}' does not exist in the list.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Ensure the ListBox is updated with the latest dataList
            UpdateListBox();

            // Check if there are any items in the dataList
            if (dataList.Count > 0)
            {
                // Create a string to hold all list items to be displayed in the message box
                StringBuilder listItems = new StringBuilder();

                // Append each item in the list to the string
                for (int i = 0; i < dataList.Count; i++)
                {
                    listItems.AppendLine($"{i + 1}. {dataList[i]}"); // Add numbered item
                }

                // Show the entire list in a message box
                var result = MessageBox.Show(listItems.ToString(),
                    "Complete List of Items",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                // Handle the OK/Cancel result if necessary
                if (result == DialogResult.OK)
                {
                    // Handle the case when OK is clicked
                }
                else
                {
                    
                }
            }
            else
            {
                MessageBox.Show("The list is empty.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void listBoxItems_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem != null)
            {
                int selectedIndex = listBoxItems.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    string selectedItem = dataList[selectedIndex];
                    dataList.RemoveAt(selectedIndex); // Remove from the List
                    UpdateListBox(); // Update ListBox with numbering
                    MessageBox.Show($"'{selectedItem}' has been removed from the list.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No item selected.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataList.Clear(); // Clear the List
            listBoxItems.Items.Clear(); // Clear the ListBox
            MessageBox.Show("The list has been cleared.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

      
        private void UpdateListBox()
        {
            listBoxItems.Items.Clear(); // Clear existing items in the ListBox
            if (dataList.Count > 0)
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    listBoxItems.Items.Add($"{i + 1}. {dataList[i]}");
                }
            }
            else
            {
                listBoxItems.Items.Add("No items in the list");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataList.Clear(); // Clear the List
            listBoxItems.Items.Clear(); // Clear the ListBox
            MessageBox.Show("The list has been cleared.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
