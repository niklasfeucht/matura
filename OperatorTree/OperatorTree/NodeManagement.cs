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
        private Node startNode;
        private bool valid;

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

        public int GetStartNode()
        {
            int count = 0;
            foreach(Node n in nodes)
            {
                if(n.Parent == null)
                {
                    count++;
                    startNode = n;
                }
            }
            return count;
        }

        private void IsValid_(Node n)
        {
            Operator op;
            if(n.GetType() == typeof(Operator))
            {
                op = (Operator)n;
                if (op.Left == null) valid = false;
                if (op.Right == null) valid = false;
                if (!valid) return;

                IsValid_(op.Left);
                IsValid_(op.Right);
            }
        }

        public bool IsValid()
        {
            valid = true;
            int count = GetStartNode();
            if(count != 1)
            {
                valid = false;
                startNode = null;
                return valid;
            }

            IsValid_(startNode);
            return valid;
        }

        private string Prefix_(Node n)
        {
            Operator op;
            if(n.GetType() == typeof(Operator))
            {
                op = (Operator)n;
                return op.GetDesc() + " " + Prefix_(op.Left) + " " + Prefix_(op.Right);
            }
            return n.GetDesc();
        }

        public string Prefix()
        {
            int count = GetStartNode();
            if(count != 1)
            {
                startNode = null;
                return "";
            }
            return Prefix_(startNode);
        }

        private string Infix_(Node n)
        {
            Operator op;
            if(n.GetType() == typeof(Operator))
            {
                op = (Operator)n;
                return Infix_(op.Left) + " " + op.GetDesc() + " " + Infix_(op.Right);
            }
            return n.GetDesc();
        }

        public string Infix()
        {
            int count = GetStartNode();
            if(count != 1)
            {
                startNode = null;
                return "";
            }
            return Infix_(startNode);
        }

        private string Postfix_(Node n)
        {
            Operator op;
            if(n.GetType() == typeof(Operator))
            {
                op = (Operator)n;
                return Postfix_(op.Left) + " " + Postfix_(op.Right) + " " + op.GetDesc();
            }
            return n.GetDesc();
        }

        public string Postfix()
        {
            int count = GetStartNode();
            if(count != 1)
            {
                startNode = null;
                return "";
            }
            return Postfix_(startNode);
        }
    }
}
