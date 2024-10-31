public class Solution {
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) {
        // Step 1: Build the graph
        var graph = new Dictionary<int, List<int>>();
        foreach (var edge in edges) {
            if (!graph.ContainsKey(edge[0])) {
                graph[edge[0]] = new List<int>();
            }
            graph[edge[0]].Add(edge[1]);
        }

        // Step 2: State array for tracking visited nodes
        var state = new int[n]; // 0: not visited, 1: visiting, 2: fully visited

        // Step 3: DFS function
        bool Dfs(int node) {
            if (state[node] == 1) return false; // cycle detected
            if (state[node] == 2) return true;  // already fully validated

            // Mark the node as being visited
            state[node] = 1;

            // If the node has no outgoing edges, check if it is the destination
            if (!graph.ContainsKey(node)) {
                if (node == destination) {
                    state[node] = 2; // Mark as fully visited
                    return true;
                }
                return false; // Dead-end not leading to destination
            }

            // Visit all neighbors
            foreach (var neighbor in graph[node]) {
                if (!Dfs(neighbor)) {
                    return false; // Path not leading to the destination
                }
            }

            // Mark the node as fully visited after exploring all paths
            state[node] = 2;
            return true;
        }

        // Step 4: Start DFS from the source
        return Dfs(source);
    }
}
