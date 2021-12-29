public class Solution {
    int count = 0;
    public int MinReorder(int n, int[][] connections) {
        var graph = new Dictionary<int, HashSet<int>>();
        var graph2 = new Dictionary<int, HashSet<int>>();
        
        for(int i = 0; i < n; i++){
            graph[i] = new HashSet<int>();
            graph2[i] = new HashSet<int>();
        }
        
        foreach(var conn in connections){
            graph[conn[0]].Add(conn[1]);
            graph2[conn[0]].Add(conn[1]);
            graph[conn[1]].Add(conn[0]);
        }
        
        var seen = new HashSet<int>();
        seen.Add(0);
        Dfs(graph, graph2, 0, seen);
        return count;
    }
    
    void Dfs(Dictionary<int, HashSet<int>> graph, Dictionary<int, HashSet<int>> graph2, int node, HashSet<int> seen){
        foreach(var nei in graph[node]){
            if(seen.Contains(nei)){
                continue;
            }
            seen.Add(nei);
            if(graph2.ContainsKey(node) && graph2[node].Contains(nei)){
                count++;
            }
            Dfs(graph, graph2, nei, seen);
        }
    }
}

