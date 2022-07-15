public class Solution
    {
        private Dictionary<int, List<int>> graph;
        private Dictionary<int, int> rank;
        private Dictionary<KeyValuePair<int, int>, Boolean> connDict;

        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {

            this.formGraph(n, connections);
            this.dfs(0, 0);

            var result = new List<IList<int>>();
            foreach(KeyValuePair<int, int> criticalConnection in this.connDict.Keys)
            {
                result.Add(new List<int>() { criticalConnection.Key, criticalConnection.Value });
            }
            return result;
        }

        private int dfs(int node, int discoveryRank)
        {

            // That means this node is already visited. We simply return the rank.
            if (this.rank[node] != -1)
            {
                return this.rank[node];
            }

            // Update the rank of this node.
            this.rank[node] = discoveryRank;

            // This is the max we have seen till now. So we start with this instead of INT_MAX or something.
            int minRank = discoveryRank + 1;

            foreach (int neighbor in this.graph[node])
            {

                // Skip the parent.
                int neighRank = this.rank[neighbor];
                if (neighRank != -1 && neighRank == discoveryRank - 1)
                {
                    continue;
                }

                // Recurse on the neighbor.
                int recursiveRank = this.dfs(neighbor, discoveryRank + 1);

                // Step 1, check if this edge needs to be discarded.
                if (recursiveRank <= discoveryRank)
                {
                    int sortedU = Math.Min(node, neighbor), sortedV = Math.Max(node, neighbor);
                    this.connDict.Remove(new KeyValuePair<int, int>(sortedU, sortedV));
                }

                // Step 2, update the minRank if needed.
                minRank = Math.Min(minRank, recursiveRank);
            }

            return minRank;
        }

        private void formGraph(int n, IList<IList<int>> connections)
        {

            this.graph = new Dictionary<int, List<int>>();
            this.rank = new Dictionary<int, int>();
            this.connDict = new Dictionary<KeyValuePair<int, int>, bool>();

            // Default rank for unvisited nodes is "null"
            for (int i = 0; i < n; i++)
            {
                this.graph[i] = new List<int>();
                this.rank[i] = -1;
            }

            foreach (List<int> edge in connections)
            {

                // Bidirectional edges
                int u = edge[0], v = edge[1];
                this.graph[u].Add(v);
                this.graph[v].Add(u);

                int sortedU = Math.Min(u, v), sortedV = Math.Max(u, v);
                connDict.Add(new KeyValuePair<int, int>(sortedU, sortedV), true);
            }
        }
    }