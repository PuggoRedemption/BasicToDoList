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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void startNewTask(object sender, EventArgs e)
        {
            newTaskName.Visible = !newTaskName.Visible;
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
                e.Handled = true;
                string text = newTaskName.Text;
                newTaskName.Text = null;
                MessageBox.Show(text);
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
        //}
    }
}
