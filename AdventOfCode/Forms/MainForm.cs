using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode
{
    public partial class MainForm : Form
    {
        private static string savePath = "../../../Forms/state.txt";
        public MainForm()
        {
            InitializeComponent();
            RedirectConsole();
            var years = Assembly.GetExecutingAssembly().GetTypes().Select(t => Regex.Match(t?.Namespace ?? "", "[0-9]+").Value).Distinct().Where(x => x != "").ToList();
            years.Sort((a, b) => int.Parse(a).CompareTo(int.Parse(b)));
            yearBox.Items.AddRange(years.ToArray());
            LoadState();
        }

        private void RedirectConsole()
        {
            Console.SetOut(new CustomWriter(console.GetType().GetProperty(nameof(console.Text)), console));
        }

        private void SaveState()
        {
            string state = "";
            state += $"year={yearBox.SelectedItem}\n";
            state += $"day={dayBox.SelectedItem}\n";
            state += $"testing={testing.Checked}\n";
            state += $"part2={part2.Checked}\n";
            state += $"sss={sss.Checked}\n";
            File.WriteAllText(savePath, state);
        }

        private void LoadState()
        {
            foreach (string line in File.ReadLines(savePath))
            {
                string fieldName = line.Split('=')[0];
                string value = line.Split("=")[1];
                switch (fieldName)
                {
                    case "year": yearBox.SelectedItem = value; break;
                    case "day": dayBox.SelectedItem = value; break;
                    case "testing": testing.Checked = bool.Parse(value); break;
                    case "part2": part2.Checked = bool.Parse(value); break;
                    case "sss": sss.Checked = bool.Parse(value); break;
                }
            }
            UpdateProblem();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResizeConsoleAndList();
        }

        private void yearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayBox.Enabled = true;
            dayBox.Items.Clear();
            dayBox.SelectedItem = "";
            var days = Assembly.GetExecutingAssembly().GetTypes().Where(x => x?.Namespace?.Contains((string)yearBox.SelectedItem) ?? false).Select(x => Regex.Match(x.Name, "Day[0-9]+$").Value).ToList().ConvertAll(x => x.Replace("Day", ""));
            days.RemoveAll(x => x == "");
            days.Sort((a, b) => int.Parse(a).CompareTo(int.Parse(b)));
            dayBox.Items.AddRange(days.ToArray());
            UpdateProblem();
        }

        private void dayBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProblem();
        }

        private void UpdateProblem()
        {
            try
            {
                if (day == null || year == null)
                {
                    problem = null;
                    runButton.Enabled = false;
                    return;
                }
                problem = (Problem?)Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Problem)) && x.FullName == $"AdventOfCode._{year}.Day{day}").First().GetConstructor([])?.Invoke(null);
                runButton.Enabled = true;
            }
            catch { }
            finally
            {
                UpdateSSSCheckBox();
            }
        }

        private void UpdateSSSCheckBox()
        {
            sss.Enabled = problem == null ? false : problem.ImplementsSSS();
            if (!sss.Enabled)
            {
                sss.Checked = false;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            UpdateProblem();
            if (problem is not null)
            {
                problem.testing = testing.Checked;
                problem.part2 = part2.Checked;
                problem.singleSentenceSolution = sss.Checked;
                Problem prob = problem;
                Task.Run(() =>
                {
                    prob.Solve();
                    prob.PrintResult();
                    return prob;
                })
                .ContinueWith((result) =>
                {
                    Problem prob = result.Result;
                    UpdateResultsList(prob);
                }, TaskScheduler.FromCurrentSynchronizationContext());
                Console.WriteLine($"{(testing.Checked ? "Testing" : "Solving")} part {(part2.Checked ? 2 : 1)} of day {day} of {year}");
            }
        }

        private void UpdateResultsList(Problem prob)
        {
            ListViewGroup group = resultsList.Groups[prob.GetTitle()];
            if (group == null)
            {
                resultsList.Groups.Add((group = new ListViewGroup(prob.GetTitle(), HorizontalAlignment.Center) { Name = prob.GetTitle() }));
            }
            ListViewItem item = new ListViewItem()
            {
                Text = "Day " + prob.id.day,
                Group = group
            };
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, prob.part1 ? "1" : "2"));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, prob.testing ? "Yes" : "No"));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, prob.singleSentenceSolution ? "Yes" : "No"));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, prob.GetTime()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, prob.GetResult().ToString()) { Name = "result" });
            resultsList.Items.Add(item);
        }

        private void resultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultsList.SelectedItems.Count > 0)
                Clipboard.SetText(resultsList.SelectedItems[0].SubItems["result"].Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }

        private string year => (string)yearBox.SelectedItem;
        private string day => (string)dayBox.SelectedItem;
        private Problem problem;

        private void clearButton_Click(object sender, EventArgs e)
        {
            console.Clear();
            resultsList.Items.Clear();
            resultsList.Groups.Clear();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeConsoleAndList();
        }

        private void ResizeConsoleAndList()
        {
            console.Height = (int)(ClientSize.Height * consoleProportion);
            console.Width = ClientSize.Width * (int)(1 - ClientSize.Height * consoleProportion);
            console.Top = console.Height;
            console.Left = 0;

            resultsList.Height = ClientSize.Height / 2;
            resultsList.Width = ClientSize.Width / 2;
            resultsList.Top = 0;
            resultsList.Left = ClientSize.Width / 2;
        }

        private static float consoleProportion = 0.7f;
    }

    internal partial class CustomWriter : TextWriter
    {
        private PropertyInfo output;
        private object instance;
        private System.Windows.Forms.Timer updateTimer;
        private ConcurrentQueue<string> consoleBuffer = [];

        public CustomWriter(PropertyInfo output, object instance)
        {
            this.output = output;
            this.instance = instance;
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 100; // Set the timer interval to 100ms
            updateTimer.Tick += UpdateConsoleBuffer;
            updateTimer.Start();
        }

        private void UpdateConsoleBuffer(object? sender, EventArgs e)
        {
            while (consoleBuffer.TryDequeue(out string update))
            {
                output.SetMethod.Invoke(instance, [(string)output.GetValue(instance) + update]);
            }
        }

        public override void Write(char value)
        {
            consoleBuffer.Enqueue(value.ToString());
        }

        public override void Write(string? value)
        {
            consoleBuffer.Enqueue(value);
        }

        public override void WriteLine(string? value)
        {
            consoleBuffer.Enqueue(value + '\n');
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}
