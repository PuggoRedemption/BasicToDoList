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
            newTaskName = new TextBox();
            newTaskButton = new Button();
            SuspendLayout();
            // 
            // newTaskName
            // 
            newTaskName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newTaskName.Location = new Point(114, 23);
            newTaskName.Name = "newTaskName";
            newTaskName.Size = new Size(636, 31);
            newTaskName.TabIndex = 1;
            newTaskName.Visible = false;
            newTaskName.KeyPress += createNewTask;
            // 
            // newTaskButton
            // 
            newTaskButton.BackColor = Color.DarkBlue;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(776, 548);
            Controls.Add(newTaskButton);
            Controls.Add(newTaskName);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "To Do List";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox newTaskName;
        private Button newTaskButton;
    }
}
