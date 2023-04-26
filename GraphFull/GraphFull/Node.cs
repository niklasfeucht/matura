using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFull
{
    [Serializable]
    internal class Node
    {
        public int X { get; set; } 
        public int Y { get; set; }
        public string Desc { get; set; }
        private const int SIZE = 20;
        private static readonly Font FONT = new Font("Arial", 12);

        public bool IsMarked { get; set; }

        private Dictionary<Node, int> neighbours;

        public Node(int x, int y, string desc)
        {
            X = x;
            Y = y;
            Desc = desc;
            neighbours = new Dictionary<Node, int>();
            IsMarked = false;
        }

        public void Paint(Graphics g)
        {
            if(IsMarked)
            {
                g.FillEllipse(Brushes.White, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);
                g.DrawEllipse(Pens.Red, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);

                SizeF dim = g.MeasureString(Desc, FONT);
                g.DrawString(Desc, FONT, Brushes.Red, X - dim.Width / 2, Y - dim.Height / 2);
            }
            else
            {
                g.FillEllipse(Brushes.White, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);
                g.DrawEllipse(Pens.Black, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);

                SizeF dim = g.MeasureString(Desc, FONT);
                g.DrawString(Desc, FONT, Brushes.Black, X - dim.Width / 2, Y - dim.Height / 2);
            }
            

        }

        public void PaintLines(Graphics g)
        {
            foreach(Node n in neighbours.Keys)
            {
                if(IsMarked && n.IsMarked)
                {
                    g.DrawLine(Pens.Red, X, Y, n.X, n.Y);
                }
                else
                {
                    g.DrawLine(Pens.Black, X, Y, n.X, n.Y);
                }
                
            }            
        }

        public bool IsInNode(int x, int y)
        {            
            int distance = Distance(x,y);
            return distance < SIZE;
        }

        public bool IsFree(int x, int y)
        {
            int distance = Distance(x,y);
            return distance > SIZE * 2;
        }

        public int Distance(int x, int y)
        {
            int dx = X - x;
            int dy = Y - y;
            return (int)Math.Sqrt(dx * dx + dy * dy);
        }

        public bool AddNeighbour(Node n)
        {
            if (neighbours.ContainsKey(n)) return false;
            neighbours.Add(n, Distance(n.X,n.Y));
            return true;
        }

        public Dictionary<Node, int> GetNeighbours()
        {
            return neighbours;
        }

        public int GetDistanceTo(Node n)
        {
            return neighbours[n];
        }




    }
}
