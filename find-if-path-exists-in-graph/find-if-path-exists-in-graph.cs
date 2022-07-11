public class Solution {
    HashSet<int> seen = new HashSet<int>();
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        if(n == 1) return true;
        var graph = new Dictionary<int, HashSet<int>>();
        for(int i = 0; i < n; i++) graph.Add(i, new HashSet<int>());
        foreach(var e in edges){
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }
        
        //graph ready
        return isValidPath(graph, source, destination);
    }
    
    private bool isValidPath(Dictionary<int, HashSet<int>> graph, int src, int dst){
        if(seen.Contains(src)) return false;
        if(graph[src].Contains(dst)) return true;
        seen.Add(src);
        foreach(var nei in graph[src]){
            if(isValidPath(graph, nei, dst)){
                return true;
            }
        }
        return false;
    }
}