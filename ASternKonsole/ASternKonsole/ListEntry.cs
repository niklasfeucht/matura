using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASternKonsole
{
    internal class ListEntry
    {
        public Node NodeEntry { get; set; }
        public int Distance { get; set; }   //Distanz zum Aktuellen Knoten 
        public int s { get; set; }          //restliche Mindestdistanz (Luftlinie)
        public Node Predecessor { get; set; }

        public ListEntry(Node nodeEntry, int distance, int s, Node predecessor)
        {
            NodeEntry = nodeEntry;
            Distance = distance;
            this.s = s;
            Predecessor = predecessor;
        }
    }
}
