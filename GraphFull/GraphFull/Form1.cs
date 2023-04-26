using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphFull
{
    public partial class Form1 : Form
    {
        NodeManagement nodes;
        Node curr;
        int oldX, oldY;
        bool moving = false;
        bool connecting = false;
        Node start, end;


        Font FONT_primary = new Font("Arial", 48);
        Font FONT_secondary = new Font("Arial", 30);
        int margin_left = 50;
        int index = 0;
        int line;


        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            nodes = new NodeManagement();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (connecting) e.Graphics.DrawLine(Pens.Black, curr.X, curr.Y, oldX, oldY);
            nodes.Paint(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            curr = nodes.IsInNode(e.X,e.Y);
            if(curr != null)
            {
                if(e.Button == MouseButtons.Left)
                {
                    if(ModifierKeys.HasFlag(Keys.Control)) {
                        moving = true;
                    }
                    else
                    {
                        connecting = true;
                    }
                }
                else if(e.Button == MouseButtons.Right)
                {
                    if(start == null)
                    {
                        start = curr;
                        start.IsMarked = true;
                    }
                    else if(end == null)
                    {
                        end = curr;
                        end.IsMarked = true;
                        aSternMI.Enabled = true;
                    }
                }
            } 
            else //Hinzufügen eines neuen Knoten
            {
                nodes.Add(e.X, e.Y);
            }
            oldX = e.X;
            oldY = e.Y;
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving)
            {
                curr.X += e.X - oldX;
                curr.Y += e.Y - oldY;
            }
            oldX = e.X;
            oldY = e.Y;
            Invalidate();
        }

        private void newMI_Click(object sender, EventArgs e)
        {
            nodes = new NodeManagement();
            Invalidate();
        }

        private void openMI_Click(object sender, EventArgs e)
        {
            ofd.InitialDirectory = "C:\\temp";
            ofd.Filter = "Binary File | *.bin";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(ofd.FileName, FileMode.Open);

                BinaryFormatter bf = new BinaryFormatter();

                nodes = (NodeManagement)bf.Deserialize(f);

                f.Close();
            }
            Invalidate();
        }

        private void saveMI_Click(object sender, EventArgs e)
        {
            sfd.InitialDirectory = "C:\\temp";
            sfd.Filter = "Binary File | *.bin";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(sfd.FileName, FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(f, nodes);

                f.Close();
            }
        }

        private void printMI_Click(object sender, EventArgs e)
        {
            index = 0;
            printPreview.ShowDialog();
        }

        private void exitMI_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();            
        }

        private void aSternMI_Click(object sender, EventArgs e)
        {
            nodes.Reset();
            nodes.AStern(start, end);
            Invalidate();
        }

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            List<Node> list_nodes = nodes.GetNodes();
            int items = e.MarginBounds.Height / (60*3);
            line = 50;
            Node n;

            for(int i=0; i<items; i++)
            {
                if (index >= list_nodes.Count) break;
                n = list_nodes[index];
                g.DrawString(n.Desc, FONT_primary, Brushes.Black, margin_left, line);
                line += 80;
                g.DrawString("X: " + n.X, FONT_secondary, Brushes.Gray, margin_left, line);
                line += 60;
                g.DrawString("Y: " + n.Y, FONT_secondary, Brushes.Gray, margin_left, line);
                line += 60;
                index++;
            }
            e.HasMorePages = index < list_nodes.Count;
        }

        private void resetMI_Click(object sender, EventArgs e)
        {
            nodes.Reset();
            start = null;
            end = null;
            aSternMI.Enabled = false;
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(connecting)
            {
                Node target = nodes.IsInNode(e.X, e.Y);
                if(target != null)
                {
                    nodes.AddConnection(curr, target);
                }
            }
            moving = false;
            connecting = false;
            Invalidate();
        }
    }
}
