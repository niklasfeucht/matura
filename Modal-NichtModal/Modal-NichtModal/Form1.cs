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
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            ModalForm modalForm = new ModalForm();
            if(modalForm.ShowDialog() == DialogResult.OK)
            {
                lblResult.Text = modalForm.Value;
            }
        }

        private void btnNichtModal_Click(object sender, EventArgs e)
        {
            NonModalForm nonModalForm = new NonModalForm();
            //nonModalForm.Parent = this;
            nonModalForm.SetText += new SetTextHandler(ChangeValue);
            nonModalForm.Show();
        }

        public void ChangeValue(string value)
        {
            lblResult.Text = value;
        }
    }
}
