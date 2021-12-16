public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if(edges.Length == 0 || edges[0].Length == 0) return new List<int>(){0};

        var graph = new Dictionary<int, HashSet<int>>();
        for(int i = 0; i < n; i++){
            graph[i] = new HashSet<int>();
        }
        foreach(var edge in edges){
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        
        var leaves = new List<int>();
        foreach(var node in graph.Keys){
            if(graph[node].Count == 1){
                leaves.Add(node);
            }
        }
        
        while(n > 2){
            n -= leaves.Count;
            List<int> newLeaves = new List<int>();
            foreach(int i in leaves) {
                int j = graph[i].First();
                graph[j].Remove(i);
                if (graph[j].Count == 1) newLeaves.Add(j);
            }
            leaves = newLeaves;
        }
        return leaves;
    }
}