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
            var years = Assembly.GetExecutingAssembly().GetTypes().Select(t => Regex.Match(t.Namespace, "[0-9]+").Value).Distinct().Where(x => x != "").ToList();
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void yearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayBox.Enabled = true;
            runButton.Enabled = false;
            dayBox.Items.Clear();
            var days = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace.Contains((string)yearBox.SelectedItem)).Select(x => Regex.Match(x.Name, "Day[0-9]+$").Value).ToList().ConvertAll(x => x.Replace("Day", ""));
            days.RemoveAll(x => x == "");
            days.Sort((a, b) => int.Parse(a).CompareTo(int.Parse(b)));
            dayBox.Items.AddRange(days.ToArray());
        }

        private void dayBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            runButton.Enabled = true;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string year = (string)yearBox.SelectedItem;
            string day = (string)dayBox.SelectedItem;
            var problem = (Problem?)Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Problem)) && x.FullName == $"AdventOfCode._{year}.Day{day}").First().GetConstructor([])?.Invoke(null);
            if (problem is not null)
            {
                problem.testing = testing.Checked;
                problem.part2 = part2.Checked;
                problem.singleSentenceSolution = sss.Checked;
                Task<long>.Run(() =>
                {
                    problem.Solve();
                    problem.PrintResult();
                    return problem.GetResult();
                })
                .ContinueWith((result) =>
                {
                    resultsList.Items.Add(new ListViewItem()
                    {
                        Text = result.Result.ToString(),
                        Group = resultsList.Groups[0],
                    });
                }, TaskScheduler.FromCurrentSynchronizationContext());
                Console.WriteLine($"{(testing.Checked ? "Testing" : "Solving")} part {(part2.Checked ? 2 : 1)} of day {day} of {year}");
            }
        }

        private void resultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultsList.SelectedItems.Count > 0)
                Clipboard.SetText(resultsList.SelectedItems[0].Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }
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
