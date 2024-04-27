using System.Data.Common;
using System.Data.SqlClient;

namespace BasicToDoList
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //DbConnectionStringBuilder
            //"Data Source=DESKTOP-RQ2RN7V\To Do List;"
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server =.; Database = To Do List; Trusted_Connection = True;";
            conn.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

                // Store the text and clear the textbox.
                string text = newTaskName.Text;
                newTaskName.Text = "";
                //MessageBox.Show(text);
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
        //}
    }
}
