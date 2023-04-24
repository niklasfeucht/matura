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
    public partial class Form1 : Form
    {
        private NodeManagement nodes;
        private bool moving = false;
        private bool connecting = false;
        private int oldX, oldY;
        private Node curr, target;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            nodes = new NodeManagement();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            curr = nodes.IsInNode(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                cmenu.Show(this, e.X, e.Y);
            } else if(e.Button == MouseButtons.Left)
            {
                if(curr!= null)
                {
                    if (ModifierKeys.HasFlag(Keys.Control))
                    {
                        moving = true;
                    }
                    else
                    {
                        connecting = true;
                    }
                }
                
            }
            oldX = e.X;
            oldY = e.Y;
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (moving)
            {
                curr.X += e.X-oldX;
                curr.Y += e.Y-oldY;
            }
            else if (connecting)
            {
                    
            }
            
            oldX = e.X;
            oldY = e.Y;
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(curr != null && connecting)
            {
                target = nodes.IsInNode(e.X, e.Y);
                if (target != null)
                    nodes.AddConnection(target, curr);
            }

            moving = false;
            connecting = false;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (connecting) curr.PaintLine(e.Graphics, oldX, oldY);
            nodes.Paint(e.Graphics);
            lblValid.Text = "Valid: " + nodes.IsValid();

            if(nodes.IsValid())
            {
                lblPrefix.Text = "Prefix: " + nodes.Prefix();
                lblInfix.Text = "Infix: " + nodes.Infix();
                lblPostfix.Text = "Postfix: " + nodes.Postfix();
            }
        }

       
        private void operandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogOperand d = new DialogOperand();
            if(d.ShowDialog() == DialogResult.OK)
            {
                nodes.Add(new Operand(oldX, oldY, d.Value));
                Invalidate();
            }
        }

        private void operatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogOperator d = new DialogOperator();
            if(d.ShowDialog() == DialogResult.OK)
            {
                nodes.Add(new Operator(oldX, oldY, d.Value));
                Invalidate();
            }
        }
    }
}
