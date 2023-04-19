using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASternKonsole
{
    internal class NodeManagement
    {
        private Dictionary<string, Node> nodes;

        public NodeManagement()
        {
            nodes = new Dictionary<string, Node>();
        }

        public bool AddNode(string desc, int x, int y)
        {
            if(nodes.ContainsKey(desc)) return false;
            nodes.Add(desc, new Node(x, y, desc));
            return true;
        }

        public bool AddConnection(string n1, string n2, int distance)
        {
            if (nodes.ContainsKey(n1) && nodes.ContainsKey(n2))
            {
                return nodes[n1].AddNeighbour(nodes[n2], distance) && nodes[n2].AddNeighbour(nodes[n1], distance);
            }
            return false;
        }

        public bool AddConnectionDijkstra(string n1, string n2)
        {
            return AddConnection(n1, n2, 1);
        }

        public bool AddConnectionAStern(string n1, string n2)
        {
            int x = nodes[n2].X;
            int y = nodes[n2].Y;
            return AddConnection(n1, n2, nodes[n1].Distance(x, y));
        }

        public List<Node> Dijkstra(string start, string end)
        {
            Node startNode = nodes[start];
            Node endNode = nodes[end];
            OpenList openList = new OpenList();
            ClosedList closedList = new ClosedList();

            ListEntry entry = new ListEntry(startNode, 0, 0, null);
            openList.Add(entry);
            entry = openList.GetBestDijkstra();

            while (entry != null)
            {
                foreach (Node n in entry.NodeEntry.GetNeighbours().Keys)
                {
                    if (closedList.IsInClosed(n))
                    {

                    }
                    else if (!openList.IsInOpen(n))
                    {
                        ListEntry newEntry = new ListEntry(n, entry.Distance + entry.NodeEntry.GetDistanceTo(n), 0, entry.NodeEntry);
                        openList.Add(newEntry);
                    }
                    else
                    {
                        ListEntry e = openList.Get(n);
                        if (entry.Distance + entry.NodeEntry.GetDistanceTo(n) < e.Distance)
                        {
                            e.Distance = entry.Distance + entry.NodeEntry.GetDistanceTo(n);
                            e.Predecessor = entry.NodeEntry;
                        }
                    }
                }

                closedList.Add(entry);
                entry = openList.GetBestDijkstra();
            }

            List<Node> result = closedList.GetResult(endNode);

            foreach (Node n in result)
            {
                Console.WriteLine(n.Desc);
            }


            return result;
        }

        public List<Node> AStern(string start, string end)
        {
            Node startNode = nodes[start];
            Node endNode = nodes[end];
            OpenList openList = new OpenList();
            ClosedList closedList = new ClosedList();

            ListEntry entry = new ListEntry(startNode, 0, startNode.Distance(endNode.X, endNode.Y), null);
            openList.Add(entry);
            entry = openList.GetBestAStern();

            while(entry != null)
            {
                foreach(Node n in entry.NodeEntry.GetNeighbours().Keys)
                {
                    if(closedList.IsInClosed(n))
                    {

                    }
                    else if(!openList.IsInOpen(n))
                    {
                        ListEntry newEntry = new ListEntry(n, entry.Distance + entry.NodeEntry.GetDistanceTo(n), n.Distance(endNode.X, endNode.Y), entry.NodeEntry);
                        openList.Add(newEntry);
                    }
                    else
                    {
                        ListEntry e = openList.Get(n);
                        if(entry.Distance + entry.NodeEntry.GetDistanceTo(n) < e.Distance)
                        {
                            e.Distance = entry.Distance +  entry.NodeEntry.GetDistanceTo(n);
                            e.Predecessor = entry.NodeEntry;
                        }
                    }
                }

                closedList.Add(entry);
                entry = openList.GetBestAStern();
            }

            List<Node> result = closedList.GetResult(endNode);

            foreach(Node n in result)
            {
                Console.WriteLine(n.Desc);
            }

            return result;
        }

        public void Print()
        {
            foreach(Node n in nodes.Values)
            {
                Console.WriteLine(n.Desc);
                n.PrintNeighbours();
                Console.WriteLine();
            }
        }
    }
}
