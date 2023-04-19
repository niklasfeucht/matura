using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASternKonsole
{
    internal class Node
    {
        public int X { set; get; }
        public int Y { set; get; }
        public string Desc { set; get; }
        private Dictionary<Node, int> neighbours;

        public Node(int x, int y, string desc)
        {
            X = x;
            Y = y;
            Desc = desc;
            neighbours = new Dictionary<Node, int>();  
        }   

        public int Distance(int x, int y)
        {
            int dx = X - x;
            int dy = Y - y;
            return (int)Math.Sqrt(dx * dx + dy * dy);
        }

        public Dictionary<Node, int> GetNeighbours()
        {
            return neighbours;
        }

        public bool AddNeighbour(Node n, int distance)
        {
            if (neighbours.ContainsKey(n)) return false;
            neighbours.Add(n, distance);
            return true;
        }

        public int GetDistanceTo(Node n)
        {
            return neighbours[n];
        }

        public void PrintNeighbours()
        {
            foreach (Node n in neighbours.Keys)
            {
                Console.WriteLine("- " + n.Desc + ": " + neighbours[n]);
            }
        }
    }
}
