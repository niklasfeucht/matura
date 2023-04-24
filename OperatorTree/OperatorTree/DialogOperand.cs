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
    public partial class DialogOperand : Form
    {
        private int value;
        public int Value { get { return value; } }
        public DialogOperand()
        {
            InitializeComponent();
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = (int.TryParse(tbValue.Text, out value));
        }
    }
}
