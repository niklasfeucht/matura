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
    public delegate void SetTextHandler(string value);
    public partial class NonModalForm : Form
    {
        public event SetTextHandler SetText;
        public NonModalForm()
        {
            InitializeComponent();
        }

        public Form1 Parent { set; get; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(SetText != null) SetText(textBox1.Text);
        }
    }
}
