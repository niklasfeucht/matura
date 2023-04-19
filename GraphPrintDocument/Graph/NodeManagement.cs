using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class NodeManagement
    {
        private List<Node> nodes;

        public NodeManagement() { nodes = new List<Node>(); }

        public bool Add(int x, int y)
        {
            foreach(Node node in nodes)
            {
                if (!node.IsFree(x, y)) return false;
            }
            nodes.Add(new Node(x, y, (nodes.Count + 1) + ""));
            return true;
        }

        public bool AddConnection(Node start, Node end)
        {
            return start.AddNeighbour(end) && end.AddNeighbour(start);
        }

        public void Paint(Graphics g)
        {
            foreach (Node node in nodes)
            {
                node.PaintConnections(g);
            }
            foreach (Node node in nodes)
            {
                node.Paint(g);
            }
        }

        public Node IsInNode(int x, int y)
        {
            foreach(Node node in nodes)
            {
                if(node.IsInNode(x, y)) return node;
            }
            return null;
        }

        public List<Node> GetNodes()
        {
            return nodes;
        }
    }
}
