using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatorTree
{
    public partial class DialogOperator : Form
    {
        private string value;
        public string Value { get { return value; } }
        public DialogOperator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            value = (string)cbOperator.SelectedItem;
            btnOk.Enabled = true;
        }
    }
}
