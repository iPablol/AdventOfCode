using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode.Forms
{
    public partial class Prompt : Form
    {
        public Prompt(string text)
        {
            InitializeComponent();
            WebBrowser browser = new WebBrowser()
            {
                Dock = DockStyle.Fill,
                DocumentText = text
            };
            Controls.Add(browser);
        }

        private void promptText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
