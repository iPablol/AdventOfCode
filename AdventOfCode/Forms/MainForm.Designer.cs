namespace AdventOfCode
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewGroup listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            yearLabel = new Label();
            yearBox = new ComboBox();
            console = new RichTextBox();
            dayLabel = new Label();
            dayBox = new ComboBox();
            runButton = new Button();
            testing = new CheckBox();
            part2 = new CheckBox();
            sss = new CheckBox();
            resultsList = new ListView();
            SuspendLayout();
            // 
            // yearLabel
            // 
            yearLabel.AutoSize = true;
            yearLabel.Location = new Point(14, 47);
            yearLabel.Margin = new Padding(4, 0, 4, 0);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(29, 15);
            yearLabel.TabIndex = 0;
            yearLabel.Text = "Year";
            // 
            // yearBox
            // 
            yearBox.DropDownStyle = ComboBoxStyle.DropDownList;
            yearBox.FormattingEnabled = true;
            yearBox.Location = new Point(55, 44);
            yearBox.Margin = new Padding(4, 3, 4, 3);
            yearBox.Name = "yearBox";
            yearBox.Size = new Size(97, 23);
            yearBox.TabIndex = 1;
            yearBox.SelectedIndexChanged += yearBox_SelectedIndexChanged;
            // 
            // console
            // 
            console.Dock = DockStyle.Bottom;
            console.Location = new Point(0, 111);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(933, 408);
            console.TabIndex = 2;
            console.Text = "";
            // 
            // dayLabel
            // 
            dayLabel.AutoSize = true;
            dayLabel.Location = new Point(14, 85);
            dayLabel.Name = "dayLabel";
            dayLabel.Size = new Size(27, 15);
            dayLabel.TabIndex = 3;
            dayLabel.Text = "Day";
            // 
            // dayBox
            // 
            dayBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dayBox.Enabled = false;
            dayBox.FormattingEnabled = true;
            dayBox.Location = new Point(55, 82);
            dayBox.Name = "dayBox";
            dayBox.Size = new Size(58, 23);
            dayBox.TabIndex = 4;
            dayBox.SelectedIndexChanged += dayBox_SelectedIndexChanged;
            // 
            // runButton
            // 
            runButton.Enabled = false;
            runButton.Location = new Point(206, 81);
            runButton.Name = "runButton";
            runButton.Size = new Size(75, 23);
            runButton.TabIndex = 5;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // testing
            // 
            testing.AutoSize = true;
            testing.Checked = true;
            testing.CheckState = CheckState.Checked;
            testing.Location = new Point(206, 46);
            testing.Name = "testing";
            testing.Size = new Size(71, 19);
            testing.TabIndex = 6;
            testing.Text = "Example";
            testing.UseVisualStyleBackColor = true;
            // 
            // part2
            // 
            part2.AutoSize = true;
            part2.Location = new Point(317, 46);
            part2.Name = "part2";
            part2.Size = new Size(53, 19);
            part2.TabIndex = 7;
            part2.Text = "part2";
            part2.UseVisualStyleBackColor = true;
            // 
            // sss
            // 
            sss.AutoSize = true;
            sss.Location = new Point(317, 81);
            sss.Name = "sss";
            sss.Size = new Size(156, 19);
            sss.TabIndex = 8;
            sss.Text = "Single Sentence Solution";
            sss.UseVisualStyleBackColor = true;
            // 
            // resultsList
            // 
            resultsList.Dock = DockStyle.Right;
            listViewGroup1.CollapsedState = ListViewGroupCollapsedState.Expanded;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "resultsGroup";
            listViewGroup1.Subtitle = "Results";
            resultsList.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });
            resultsList.Location = new Point(479, 0);
            resultsList.Name = "resultsList";
            resultsList.Size = new Size(454, 111);
            resultsList.TabIndex = 9;
            resultsList.UseCompatibleStateImageBehavior = false;
            resultsList.View = View.List;
            resultsList.SelectedIndexChanged += resultsList_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(resultsList);
            Controls.Add(sss);
            Controls.Add(part2);
            Controls.Add(testing);
            Controls.Add(runButton);
            Controls.Add(dayBox);
            Controls.Add(dayLabel);
            Controls.Add(console);
            Controls.Add(yearBox);
            Controls.Add(yearLabel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.ComboBox yearBox;
        private RichTextBox console;
        private Label dayLabel;
        private ComboBox dayBox;
        private Button runButton;
        private CheckBox testing;
        private CheckBox part2;
        private CheckBox sss;
        private ListView resultsList;
    }
}

