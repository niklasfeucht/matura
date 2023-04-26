using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFull
{
    internal class ListEntry
    {
        public Node NodeEntry { get; set; }
        public int Distance { get; set; }
        public int s { get; set; }
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
