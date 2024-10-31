public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] edges) {
        var result = new List<IList<int>>();
        var graph = edges.Select(x=>x.ToHashSet()).ToList();
        var neighbors = graph[0];
        var seen = new HashSet<int>();
        IsValidPath(graph, 0, edges.Length - 1, new HashSet<int>(){0}, result);
        return result;
    }
    
    private void IsValidPath(List<HashSet<int>> graph, int start, int end, HashSet<int> path, List<IList<int>> result)
    {
        if(start == end) {
            result.Add(path.ToList());
            return;
        }
        //check neighbors
        foreach(var node in graph[start]){
            path.Add(node);
            IsValidPath(graph, node, end, path, result);
            path.Remove(node);
        }
        return;
    }
}