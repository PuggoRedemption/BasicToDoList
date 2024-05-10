using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BasicToDoList
{
    public partial class MainForm : Form
    {
        string connectionString = "Server =.; Database = To Do List; Trusted_Connection = True;";
        SqlCommand cmd;
        SqlDataAdapter da;
        BindingSource taskBindingSource = new BindingSource();
        DataTable dt = new DataTable();

        public MainForm()
        {
            InitializeComponent();

            // Change text color here to avoid deletion.
            dataGridView1.ForeColor = Color.Black;

        }

        // Load the DataGridView
        private void MainForm_Load(object sender, EventArgs e)
        { 
            // Set up connection, create a new DataAdapter, fill the DataTable, and set the DataSource to the DataTable.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                da = new SqlDataAdapter("select taskID, taskName, taskDescription, complete from Task where task.complete = 0;", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                // Hide ID column and rename others
                dataGridView1.Columns[0].Visible = false;
                dt.Columns["taskName"].ColumnName = "Task Name";
                dt.Columns["taskDescription"].ColumnName = "Description";
                dt.Columns["complete"].ColumnName = "Complete";

                // Set up Text Wrap for Description Field
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //((DataGridViewTextBoxColumn)dataGridView1.Columns[2]).MaxInputLength = 20;
            
                conn.Close();
            }
        }

        // Show a textbox when creating a new task and hide the textbox when done.
        private void startNewTask(object sender, EventArgs e)
        {
            // Do the opposite of the visible value.
            newTaskName.Visible = !newTaskName.Visible;

            // Modify the button text based on what was there previously.
            if (newTaskButton.Text == "New Task")
            {
                newTaskButton.Text = "Cancel";
            }
            else
            {
                newTaskButton.Text = "New Task";
            }
        }

        // Adds a new task based on textbox input.
        private void createNewTask(object sender, KeyPressEventArgs e)
        {
            // Verify if "Enter" was pressed and there is a value for the newTaskName.
            if (e.KeyChar == (char)Keys.Enter && newTaskName.Text != "")
            {
                // Closes the key event to stop windows Ding.
                e.Handled = true;

                // Capture the new task name and set a default description.
                Task newTask = new Task()
                {
                    TaskName = newTaskName.Text,
                    TaskDescription = ""
                };

                // Erase text from textbox
                newTaskName.Text = "";

                // Create data access object and insert the new task into the database.
                TaskDAO newTaskDAO = new TaskDAO();
                int result = newTaskDAO.addNewTask(newTask);

                taskBindingSource.DataSource = newTaskDAO.getOpenTasks();
                dataGridView1.DataSource = taskBindingSource;
            }
        }

        // Update the Database when a cell value has changed in the table.
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Set up a connection, grab the selected row, and set a SQL command to run a stored procedure.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                DataGridViewRow dgvrow = dataGridView1.CurrentRow;
                SqlCommand cmd2 = new SqlCommand("TaskEdit", conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                // Map and send parameters to the stored procedure
                cmd2.Parameters.AddWithValue("@taskID", dgvrow.Cells["taskID"].Value.ToString());
                cmd2.Parameters.AddWithValue("@taskName", dgvrow.Cells["Task Name"].Value.ToString());
                cmd2.Parameters.AddWithValue("@taskDescription", dgvrow.Cells["Description"].Value.ToString());
                cmd2.Parameters.AddWithValue("@complete", Convert.ToBoolean(dgvrow.Cells["complete"].Value));
                cmd2.ExecuteNonQuery();

                // Repopulate the DataTable with updated information (mainly for removing complete records)
                da = new SqlDataAdapter("select taskID, taskName, taskDescription, complete from Task where task.complete = 0;", conn);
                //dt.Clear();
                dt.Reset();
                dataGridView1.DataSource = dt;
                da.Fill(dt);

                conn.Close();
            }
        }
    }
}
