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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nodes = new NodeManagement();
            Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Binary File | *.bin";
            ofd.InitialDirectory = "C:\\Temp";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);

                BinaryFormatter bf = new BinaryFormatter();

                nodes = (NodeManagement)bf.Deserialize(fs);
                Invalidate();

                fs.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Binary File | *.bin";
            sfd.InitialDirectory = "C:\\Temp";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, nodes);

                fs.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
