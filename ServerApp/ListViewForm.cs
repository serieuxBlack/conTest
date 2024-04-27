using System;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class ListViewForm : Form
    {
        private ListView listView1;

        public ListViewForm()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeComponent()
        {
            // Initialize components like the ListView
            listView1 = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Dock = DockStyle.Fill
            };

            // Add columns to ListView
            listView1.Columns.Add("Column 1", 150);
            listView1.Columns.Add("Column 2", 150);

            // Add the ListView to the form's controls
            this.Controls.Add(listView1);

            // Other form initialization...
        }

        private void InitializeListView()
        {
            // Configure ListView properties if needed
            // Add additional initialization code here
        }

        // Public method to add items to the ListView
        public void AddListItem(string column1, string column2)
        {
            ListViewItem item = new ListViewItem(column1);
            item.SubItems.Add(column2);
            listView1.Items.Add(item);
        }

        // Other logic and event handlers for the ListView
    }
}
