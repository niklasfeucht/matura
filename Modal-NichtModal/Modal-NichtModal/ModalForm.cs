using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal_NichtModal
{
    public partial class ModalForm : Form
    {
        private string value;
        public string Value { get { return value; } }

        public ModalForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            value = textBox1.Text;
        }
    }
}
