public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        // Handle base cases
        if (n == 1) return new List<int> { 0 };
        if (n == 2) return new List<int> { 0, 1 };

        // Initialize in-degree and adjacency list
        var inDegree = new int[n];
        var map = new Dictionary<int, List<int>>();
        foreach (var edge in edges) {
            inDegree[edge[0]]++;
            inDegree[edge[1]]++;
            if (!map.ContainsKey(edge[0])) map[edge[0]] = new List<int>();
            if (!map.ContainsKey(edge[1])) map[edge[1]] = new List<int>();
            map[edge[0]].Add(edge[1]);
            map[edge[1]].Add(edge[0]);
        }

        // Initialize the first set of leaves
        var queue = new Queue<int>();
        for (var i = 0; i < n; i++) {
            if (inDegree[i] == 1) {
                queue.Enqueue(i);
            }
        }

        // Trim the leaves level by level
        while (n > 2) {
            int leavesCount = queue.Count;
            n -= leavesCount; // Reduce the total number of nodes by the number of leaves
            for (int i = 0; i < leavesCount; i++) {
                var node = queue.Dequeue();
                foreach (var neighbor in map[node]) {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 1) {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        // The remaining nodes in the queue are the MHT roots
        return queue.ToList();
    }
}
