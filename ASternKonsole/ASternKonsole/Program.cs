using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASternKonsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            NodeManagement nodes = new NodeManagement();
            nodes.AddNode("1", 30, 10);
            nodes.AddNode("2", 0, 20);
            nodes.AddNode("3", 30, 30);
            nodes.AddNode("4", 50, 30);
            nodes.AddNode("5", 70, 60);
            nodes.AddNode("6", 80, 40);
            nodes.AddNode("7", 100, 20);

            nodes.AddConnectionDijkstra("1", "2");
            nodes.AddConnectionDijkstra("2", "3");
            nodes.AddConnectionDijkstra("3", "4");
            nodes.AddConnectionDijkstra("4", "5");
            nodes.AddConnectionDijkstra("5", "6");
            nodes.AddConnectionDijkstra("6", "7");
            nodes.AddConnectionDijkstra("7", "1");

            nodes.Print();
            Console.WriteLine("Dijkstra");
            nodes.Dijkstra("3", "7");
            Console.WriteLine("-----");
            

            nodes = new NodeManagement();
            nodes.AddNode("1", 30, 10);
            nodes.AddNode("2", 0, 20);
            nodes.AddNode("3", 30, 30);
            nodes.AddNode("4", 50, 30);
            nodes.AddNode("5", 70, 60);
            nodes.AddNode("6", 80, 40);
            nodes.AddNode("7", 100, 20);

            nodes.AddConnectionAStern("1", "2");
            nodes.AddConnectionAStern("2", "3");
            nodes.AddConnectionAStern("3", "4");
            nodes.AddConnectionAStern("4", "5");
            nodes.AddConnectionAStern("5", "6");
            nodes.AddConnectionAStern("6", "7");
            nodes.AddConnectionAStern("7", "1");

            
            nodes.Print();
            Console.WriteLine("AStern");
            nodes.AStern("3", "7");
        }
    }
}
