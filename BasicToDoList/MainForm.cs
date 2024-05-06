using System.Data.Common;
using System.Data.SqlClient;

namespace BasicToDoList
{
    public partial class MainForm : Form
    {
        BindingSource taskBindingSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TaskDAO taskList = new TaskDAO();

            taskBindingSource.DataSource = taskList.getOpenTasks();
            dataGridView1.DataSource = taskBindingSource;

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlCommandBuilder.DataAdapter = sqlDataAdapter;
        }

        //// Get Tasks
        //public class TaskDataService
        //{
        //    private readonly string _connectionString;
        //    public TaskDataService(string connectionString)
        //    {
        //        _connectionString = connectionString;
        //    }

        //    public TaskInfo GetOpenTasks()
        //    {
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {
        //            string sql = "select taskName, taskDescription from Task where task.complete = 0;";
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                using (var reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        return new TaskInfo
        //                                    {
        //                                        TaskName = reader[1].ToString(),
        //                                        TaskDescription = reader[2].ToString()
        //                                    };
        //                    }
        //                }
        //            }
        //        }

        //        return null;
        //    }

        //}

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

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
        //}
    }
}
