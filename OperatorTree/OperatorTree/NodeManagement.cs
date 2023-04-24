using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorTree
{
    class NodeManagement
    {
        private List<Node> nodes;

        public NodeManagement()
        {
            nodes = new List<Node>();
        }

        public bool Add(Node node)
        {
            foreach(Node n in nodes) {
                if (!n.IsFree(node.X, node.Y)) return false;
            }
            nodes.Add(node);
            return true;
        }

        public bool AddConnection(Node child, Node parent)
        {
            if(parent.GetType() == typeof(Operator))
            {
                Operator op = (Operator)parent;
                if(op.AddConnection(child))
                {
                    child.Parent = parent;
                    return true;
                }
            }
            return false;
        }

        public void Paint(Graphics g)
        {
            foreach(Node n in nodes)
            {
                if(n.Parent != null)
                {
                    n.PaintLine(g, n.Parent.X, n.Parent.Y);
                }
                //n.PaintLine(g);
            }
            foreach(Node n in nodes)
            {
                n.Paint(g);
            }
        }

        public Node IsInNode(int x, int y)
        {
            foreach(Node n in nodes)
            {
                if (n.IsInNode(x, y)) return n;
            }
            return null;
        }
    }
}
