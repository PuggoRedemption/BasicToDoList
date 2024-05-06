namespace BasicToDoList
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            newTaskName = new TextBox();
            newTaskButton = new Button();
            dataGridView1 = new DataGridView();
            updateButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // newTaskName
            // 
            newTaskName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newTaskName.Location = new Point(114, 23);
            newTaskName.Name = "newTaskName";
            newTaskName.Size = new Size(426, 31);
            newTaskName.TabIndex = 1;
            newTaskName.Visible = false;
            newTaskName.KeyPress += createNewTask;
            // 
            // newTaskButton
            // 
            newTaskButton.BackColor = Color.SlateGray;
            newTaskButton.FlatAppearance.BorderColor = Color.DarkBlue;
            newTaskButton.FlatAppearance.BorderSize = 0;
            newTaskButton.FlatStyle = FlatStyle.Flat;
            newTaskButton.ForeColor = Color.Transparent;
            newTaskButton.Location = new Point(12, 23);
            newTaskButton.Name = "newTaskButton";
            newTaskButton.Size = new Size(96, 31);
            newTaskButton.TabIndex = 2;
            newTaskButton.Text = "New Task";
            newTaskButton.UseVisualStyleBackColor = false;
            newTaskButton.Click += startNewTask;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.DarkSlateGray;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = Color.SlateGray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.GridColor = SystemColors.InfoText;
            dataGridView1.Location = new Point(25, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(515, 401);
            dataGridView1.TabIndex = 3;
            dataGridView1.ForeColor = Color.Black;
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.SlateGray;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.ForeColor = Color.Transparent;
            updateButton.Location = new Point(12, 558);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(112, 34);
            updateButton.TabIndex = 4;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(566, 604);
            Controls.Add(updateButton);
            Controls.Add(dataGridView1);
            Controls.Add(newTaskButton);
            Controls.Add(newTaskName);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "To Do List";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox newTaskName;
        private Button newTaskButton;
        private DataGridView dataGridView1;
        private Button updateButton;
    }
}
