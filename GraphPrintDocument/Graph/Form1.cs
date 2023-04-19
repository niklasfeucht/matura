using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        private NodeManagement nodes;
        private Node curr;
        private bool moving = false;
        private bool connecting = false;
        private int oldX;
        private int oldY;

        private static readonly Font font_main = new Font("Arial", 48);
        private static readonly Font font_second = new Font("Arial", 36);
        private static readonly int left_margin = 50;
        private int line = 50;
        private static readonly int line_height_main = 70;
        private static readonly int line_height_second = 50;
        
        private int index = 0;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            SetStyle(ControlStyles.AllPaintingInWmPaint,true);  
            nodes = new NodeManagement();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            curr = nodes.IsInNode(e.X, e.Y);
            if(curr != null)
            {
                if(e.Button == MouseButtons.Left) //Verschieben eines Knoten
                {
                    moving = true;
                    
                } else if(e.Button == MouseButtons.Right) //Verbinden
                {
                    connecting = true;
                }
            }
            else //Hinzufügen eines neuen Knoten
            {
                nodes.Add(e.X, e.Y);
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (curr != null && connecting) e.Graphics.DrawLine(Pens.Black, curr.X, curr.Y, oldX, oldY);
            nodes.Paint(e.Graphics);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving)
            {
                curr.X = curr.X + e.X-oldX;
                curr.Y = curr.Y + e.Y-oldY;
            }
            oldX = e.X;
            oldY = e.Y;
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(connecting)
            {
                Node node = nodes.IsInNode(e.X, e.Y);
                if(node!=null) nodes.AddConnection(curr, node);
            }
            moving = false;
            connecting = false;
            Invalidate();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (printpreviewdialog.ShowDialog() == DialogResult.OK)
            {
                              
                
                pd.Print();
            }
        }

        private void pd_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void pd_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            List<Node> nodeList = nodes.GetNodes();
            int itemsPerPage = e.MarginBounds.Height / (line_height_main *2 + line_height_second);
            line = 50;

            for(int i = 0; i < itemsPerPage; i++)
            {
                if(index < nodeList.Count)
                {
                    g.DrawString(nodeList[index].Desc + " : ", font_main, Brushes.Black, left_margin, line);
                    line += line_height_main;

                    g.DrawString("X: " + nodeList[index].X, font_second, Brushes.DarkGray, left_margin, line);
                    line += line_height_second;
                    g.DrawString("Y: " + nodeList[index].Y, font_second, Brushes.DarkGray, left_margin, line);
                    line += line_height_main;
                    index++;
                }
                
                
            }

            e.HasMorePages = (index < nodeList.Count);
        }

        private void pd_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {

        }
    }
}
