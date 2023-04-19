﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASternKonsole
{
    internal class ClosedList
    {
        private Dictionary<Node, ListEntry> closed;

        public ClosedList()
        {
            closed = new Dictionary<Node, ListEntry>();
        }

        public bool Add(ListEntry entry)
        {
            if(closed.ContainsKey(entry.NodeEntry)) return false;

            closed.Add(entry.NodeEntry, entry);
            return true;
        }

        public bool IsInClosed(Node n)
        {
            return closed.ContainsKey(n);
        }

        public List<Node> GetResult(Node endNode)
        {
            List<Node> result = new List<Node>();

            if (!closed.ContainsKey(endNode)) return result;

            ListEntry entry = closed[endNode];
            result.Add(endNode);
            while((entry != null) && (entry.Predecessor != null))
            {
                entry = closed[entry.Predecessor];
                result.Add(entry.NodeEntry);
            }

            return result;
        }
    }
}
