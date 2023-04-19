using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    [Serializable]
    internal class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Desc { get; set; }
        private const int SIZE = 20;
        private static readonly Font FONT = new Font("Arial", 12);

        private Dictionary<Node, int> neighbours;

        public Node(int x, int y, string desc)
        {
            X = x;
            Y = y;
            Desc = desc;
            neighbours = new Dictionary<Node, int>();
        }

        public void Paint(Graphics g)
        {
            g.FillEllipse(Brushes.White, X-SIZE, Y-SIZE, SIZE*2, SIZE*2);
            g.DrawEllipse(Pens.Black, X-SIZE, Y-SIZE, SIZE*2, SIZE*2);

            SizeF dim = g.MeasureString(Desc, FONT);
            g.DrawString(Desc,FONT,Brushes.Black, X-dim.Width/2, Y-dim.Height/2);
        }

        public void PaintConnections(Graphics g)
        {
            foreach(Node node in neighbours.Keys)
            {
                g.DrawLine(Pens.Black, X, Y, node.X, node.Y);
            }            
        }

        public bool IsFree(int x, int y)
        {
            int dx = x - X;
            int dy = y - Y;
            int dist = (int)Math.Sqrt(dx * dx + dy * dy);
            return dist > SIZE*2;
        }

        public bool IsInNode(int x, int y)
        {
            int dx = x - X;
            int dy = y - Y;
            int dist = (int)Math.Sqrt(dx * dx + dy * dy);
            return dist < SIZE;
        }

        public bool AddNeighbour(Node node)
        {
            if (neighbours.ContainsKey(node)) return false;
            neighbours.Add(node, 1);
            return true;
        }
    }
}
