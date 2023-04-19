using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASternKonsole
{
    internal class OpenList
    {
        private List<ListEntry> openList;
        private Dictionary<Node, ListEntry> openDictionary;

        public OpenList()
        {
            openList = new List<ListEntry>();
            openDictionary = new Dictionary<Node, ListEntry>();
        }

        public bool Add(ListEntry entry)
        {
            if (openList.Contains(entry) || openDictionary.ContainsKey(entry.NodeEntry)) return false;

            openList.Add(entry);
            openDictionary.Add(entry.NodeEntry, entry);
            return true;
        }

        public ListEntry Get(Node n)
        {
            return openDictionary[n];
        }

        public void SortDijkstra()
        {
            openList.Sort(delegate (ListEntry l1, ListEntry l2)
            {
                return ((l1.Distance).CompareTo(l2.Distance));
            });
        }

        public void SortAStern()
        {
            openList.Sort(delegate (ListEntry l1, ListEntry l2)
            {
                return ((l1.Distance+l1.s).CompareTo(l2.Distance+l2.s));
            });
        }

        public bool IsInOpen(Node n)
        {
            return openDictionary.ContainsKey(n);
        }

        public ListEntry GetBestDijkstra()
        {
            if(openList.Count <= 0) return null;

            SortDijkstra();
            ListEntry result = openList[0];
            openList.RemoveAt(0);
            openDictionary.Remove(result.NodeEntry);

            return result;
        }

        public ListEntry GetBestAStern()
        {
            if (openList.Count <= 0) return null;

            SortAStern();
            ListEntry result = openList[0];
            openList.RemoveAt(0);
            openDictionary.Remove(result.NodeEntry);

            return result;
        }
    }
}
