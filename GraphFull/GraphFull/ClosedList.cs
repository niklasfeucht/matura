using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFull
{
    internal class ClosedList
    {
        private Dictionary<Node, ListEntry> closedDict;

        public ClosedList()
        {
            closedDict = new Dictionary<Node, ListEntry>();
        }

        public bool Add(ListEntry entry)
        {
            if (closedDict.ContainsKey(entry.NodeEntry)) return false;

            closedDict.Add(entry.NodeEntry, entry);
            return true;
        }

        public bool IsInClosed(Node n)
        {
            return closedDict.ContainsKey(n);
        }

        public List<Node> GetResult(Node end)
        {
            List<Node> result = new List<Node>();
            Node n = end;

            if(!closedDict.ContainsKey(n)) return result;

            while(n != null)
            {
                result.Add(n);

                n = closedDict[n].Predecessor;
            }

            return result;
        }
    }
}
