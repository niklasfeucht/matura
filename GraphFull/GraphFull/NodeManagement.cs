using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFull
{
    [Serializable]
    internal class NodeManagement
    {
        private List<Node> nodes;

        public NodeManagement()
        {
            nodes = new List<Node>();
        }

        public Node IsInNode(int x, int y)
        {
            foreach (Node n in nodes)
            {
                if (n.IsInNode(x, y)) return n;
            }
            return null;
        }

        public bool IsFree(int x, int y)
        {
            foreach(Node n in nodes)
            {
                if (!n.IsFree(x, y)) return false;
            }
            return true;
        }

        public bool Add(int x, int y)
        {
            if(IsFree(x,y))
            {
                nodes.Add(new Node(x, y, nodes.Count + ""));
                return true;
            }
            return false;
        }

        public bool AddConnection(Node start, Node end)
        {
            return start.AddNeighbour(end) && end.AddNeighbour(start);
        }

        public void Paint(Graphics g)
        {
            foreach(Node n in nodes)
            {
                n.PaintLines(g);
            }
            foreach(Node n in nodes)
            {
                n.Paint(g);
            }
        }

        public void AStern(Node start, Node end)
        {
            OpenList openList = new OpenList();
            ClosedList closedList = new ClosedList();
            ListEntry entry = new ListEntry(start, 0, start.Distance(end.X, end.Y), null);

            openList.Add(entry);
            Console.WriteLine("test");
            while(entry != null)
            {
                foreach(Node n in entry.NodeEntry.GetNeighbours().Keys)
                {
                    if(closedList.IsInClosed(n))
                    {

                    }
                    else if(!openList.IsInOpen(n))
                    {                        
                        ListEntry newEntry = new ListEntry(n, entry.Distance + entry.NodeEntry.GetDistanceTo(n), n.Distance(end.X, end.Y), entry.NodeEntry);
                        openList.Add(newEntry);
                    }
                    else
                    {
                        ListEntry currEntry = openList.Get(n);
                        if(entry.Distance + entry.NodeEntry.GetDistanceTo(n) < currEntry.Distance)
                        {
                            currEntry.Distance = entry.Distance + entry.NodeEntry.GetDistanceTo(n);
                            currEntry.Predecessor = entry.NodeEntry;
                        }
                    }
                }

                closedList.Add(entry);
                entry = openList.GetBest();
            }

            List<Node> result = closedList.GetResult(end);

            foreach(Node node in result)
            {
                node.IsMarked = true;
            }
        }

        public void Reset()
        {
            foreach(Node n in nodes)
            {
                n.IsMarked = false;
            }
        }
        
        public List<Node> GetNodes()
        {
            return nodes;
        }

    }
}
