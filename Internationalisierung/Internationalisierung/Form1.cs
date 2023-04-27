using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internationalisierung
{
    public partial class Form1 : Form
    {
        ResourceManager ResourceManager = new ResourceManager("Internationalisierung.Resource", typeof(Form1).Assembly);
        public Form1()
        {
            InitializeComponent();
        }

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
            Controls.Clear();
            InitializeComponent();
        }

        private void englischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-de");
            Controls.Clear();
            InitializeComponent();
        }
    }
}
