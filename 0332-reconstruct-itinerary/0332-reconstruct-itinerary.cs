public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        // Step 1: Build the adjacency list
        var adj = new Dictionary<string, List<string>>();
        
        // Populate the adjacency list from tickets
        foreach (var ticket in tickets) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }
        
        // Step 2: Sort each list of destinations to maintain lexicographical order
        foreach (var key in adj.Keys) {
            adj[key].Sort();
        }

        // Step 3: Use a stack to construct the itinerary in reverse order
        var itinerary = new Stack<string>();

        // Recursive DFS function with post-order traversal
        void Dfs(string airport) {
            // Visit each destination in sorted order
            while (adj.ContainsKey(airport) && adj[airport].Count > 0) {
                // Get the next lexicographically smallest destination
                var nextDestination = adj[airport][0];
                adj[airport].RemoveAt(0);
                Dfs(nextDestination);
            }
            // After visiting all destinations from 'airport', add it to itinerary
            itinerary.Push(airport);
        }

        // Start DFS from "JFK"
        Dfs("JFK");

        // The itinerary stack contains the path in reverse, so convert it to list and return
        return itinerary.ToList();
    }
}
