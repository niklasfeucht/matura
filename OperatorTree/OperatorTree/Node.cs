using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorTree
{
    abstract class Node
    {
        public Node Parent { set; get; }
        public int X { set; get; }
        public int Y { set; get; }

        public static readonly int SIZE = 20;        
        public static readonly Font FONT = new Font("Arial", 12);

        public Node(int x, int y)
        {
            X = x;
            Y = y;            
        }

        public abstract bool IsInNode(int x, int y);
        public abstract bool IsFree(int x, int y);
        public abstract void Paint(Graphics g);
        public abstract string GetDesc();
        public abstract bool AddConnection(Node n);

        public void PaintLine(Graphics g, int x, int y)
        {
            
            g.DrawLine(Pens.Black, X, Y, x, y);
            
        }

    }
}
