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
            ListViewGroup listViewGroup1 = new ListViewGroup("---Year 2024---", HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            dayColumn = new ColumnHeader();
            partColumn = new ColumnHeader();
            exampleColumn = new ColumnHeader();
            sssColumn = new ColumnHeader();
            timeColumn = new ColumnHeader();
            resultColumn = new ColumnHeader();
            clearButton = new Button();
            SuspendLayout();
            // 
            // yearLabel
            // 
            yearLabel.AutoSize = true;
            yearLabel.Location = new Point(16, 63);
            yearLabel.Margin = new Padding(5, 0, 5, 0);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(37, 20);
            yearLabel.TabIndex = 0;
            yearLabel.Text = "Year";
            // 
            // yearBox
            // 
            yearBox.DropDownStyle = ComboBoxStyle.DropDownList;
            yearBox.FormattingEnabled = true;
            yearBox.Location = new Point(63, 59);
            yearBox.Margin = new Padding(5, 4, 5, 4);
            yearBox.Name = "yearBox";
            yearBox.Size = new Size(110, 28);
            yearBox.TabIndex = 1;
            yearBox.SelectedIndexChanged += yearBox_SelectedIndexChanged;
            // 
            // console
            // 
            console.Dock = DockStyle.Bottom;
            console.Location = new Point(0, 149);
            console.Margin = new Padding(3, 4, 3, 4);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(1066, 543);
            console.TabIndex = 2;
            console.Text = "";
            // 
            // dayLabel
            // 
            dayLabel.AutoSize = true;
            dayLabel.Location = new Point(16, 113);
            dayLabel.Name = "dayLabel";
            dayLabel.Size = new Size(35, 20);
            dayLabel.TabIndex = 3;
            dayLabel.Text = "Day";
            // 
            // dayBox
            // 
            dayBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dayBox.Enabled = false;
            dayBox.FormattingEnabled = true;
            dayBox.Location = new Point(63, 109);
            dayBox.Margin = new Padding(3, 4, 3, 4);
            dayBox.Name = "dayBox";
            dayBox.Size = new Size(66, 28);
            dayBox.TabIndex = 4;
            dayBox.SelectedIndexChanged += dayBox_SelectedIndexChanged;
            // 
            // runButton
            // 
            runButton.Enabled = false;
            runButton.Location = new Point(419, 102);
            runButton.Margin = new Padding(3, 4, 3, 4);
            runButton.Name = "runButton";
            runButton.Size = new Size(86, 31);
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
            testing.Location = new Point(202, 61);
            testing.Margin = new Padding(3, 4, 3, 4);
            testing.Name = "testing";
            testing.Size = new Size(88, 24);
            testing.TabIndex = 6;
            testing.Text = "Example";
            testing.UseVisualStyleBackColor = true;
            // 
            // part2
            // 
            part2.AutoSize = true;
            part2.Location = new Point(331, 61);
            part2.Margin = new Padding(3, 4, 3, 4);
            part2.Name = "part2";
            part2.Size = new Size(66, 24);
            part2.TabIndex = 7;
            part2.Text = "part2";
            part2.UseVisualStyleBackColor = true;
            // 
            // sss
            // 
            sss.AutoSize = true;
            sss.Enabled = false;
            sss.Location = new Point(202, 106);
            sss.Margin = new Padding(3, 4, 3, 4);
            sss.Name = "sss";
            sss.Size = new Size(195, 24);
            sss.TabIndex = 8;
            sss.Text = "Single Sentence Solution";
            sss.UseVisualStyleBackColor = true;
            // 
            // resultsList
            // 
            resultsList.Activation = ItemActivation.TwoClick;
            resultsList.Columns.AddRange(new ColumnHeader[] { dayColumn, partColumn, exampleColumn, sssColumn, timeColumn, resultColumn });
            resultsList.Dock = DockStyle.Right;
            listViewGroup1.Header = "---Year 2024---";
            listViewGroup1.Name = "testgroup";
            resultsList.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });
            resultsList.Location = new Point(563, 0);
            resultsList.Margin = new Padding(3, 4, 3, 4);
            resultsList.MultiSelect = false;
            resultsList.Name = "resultsList";
            resultsList.Size = new Size(503, 149);
            resultsList.TabIndex = 9;
            resultsList.UseCompatibleStateImageBehavior = false;
            resultsList.View = View.Details;
            resultsList.SelectedIndexChanged += resultsList_SelectedIndexChanged;
            // 
            // dayColumn
            // 
            dayColumn.Text = "Day";
            dayColumn.Width = 50;
            // 
            // partColumn
            // 
            partColumn.Text = "Part";
            partColumn.TextAlign = HorizontalAlignment.Center;
            partColumn.Width = 50;
            // 
            // exampleColumn
            // 
            exampleColumn.Text = "Example";
            exampleColumn.TextAlign = HorizontalAlignment.Center;
            exampleColumn.Width = 80;
            // 
            // sssColumn
            // 
            sssColumn.Text = "SSS";
            sssColumn.TextAlign = HorizontalAlignment.Center;
            sssColumn.Width = 50;
            // 
            // timeColumn
            // 
            timeColumn.Text = "Execution Time";
            timeColumn.Width = 120;
            // 
            // resultColumn
            // 
            resultColumn.Text = "Result";
            resultColumn.Width = 250;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(419, 59);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(86, 29);
            clearButton.TabIndex = 10;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 692);
            Controls.Add(clearButton);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainForm";
            Text = "Advent of Code";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Resize += MainForm_Resize;
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
        private Button clearButton;
        private ColumnHeader dayColumn;
        private ColumnHeader resultColumn;
        private ColumnHeader partColumn;
        private ColumnHeader exampleColumn;
        private ColumnHeader sssColumn;
        private ColumnHeader timeColumn;
    }
}

