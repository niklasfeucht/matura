using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFull
{
    internal class OpenList
    {
        private Dictionary<Node, ListEntry> openDict;
        private List<ListEntry> openList;

        public OpenList()
        {
            openDict = new Dictionary<Node, ListEntry>();
            openList = new List<ListEntry>();
        }

        public bool Add(ListEntry entry)
        {
            if (openDict.ContainsKey(entry.NodeEntry) || openList.Contains(entry)) return false;
            openDict.Add(entry.NodeEntry, entry);
            openList.Add(entry);
            return true;
        }

        public bool IsInOpen(Node n)
        {
            return openDict.ContainsKey(n);
        }

        public ListEntry Get(Node n)
        {
            return openDict[n];
        }

        public void Sort()
        {
            openList.Sort(delegate (ListEntry entry1, ListEntry entry2)
            {
                return (entry1.Distance + entry1.s).CompareTo(entry2.Distance + entry2.s);
            });
        }

        public ListEntry GetBest()
        {
            Sort();
            if (openList.Count <= 0) return null;

            ListEntry best = openList[0];
            openList.RemoveAt(0);
            openDict.Remove(best.NodeEntry);
            return best;
        }
    }
}
