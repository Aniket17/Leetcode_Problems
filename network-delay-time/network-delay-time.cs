class Solution {
    Dictionary<int, int> dist;
    public int NetworkDelayTime(int[][] times, int N, int K) {
        Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
        foreach (int[] edge in times) {
            if (!graph.ContainsKey(edge[0]))
                graph.Add(edge[0], new List<int[]>());
            graph[edge[0]].Add(new int[]{edge[2], edge[1]});
        }
        foreach (int node in graph.Keys) {
            graph[node] = graph[node].OrderBy(x=>x[0]).ToList();
        }
        dist = new Dictionary<int, int>();
        for (int node = 1; node <= N; ++node)
            dist.Add(node, int.MaxValue);

        dfs(graph, K, 0);
        int ans = 0;
        foreach(int cand in dist.Values) {
            if (cand == int.MaxValue) return -1;
            ans = Math.Max(ans, cand);
        }
        return ans;
    }

    public void dfs(Dictionary<int, List<int[]>> graph, int node, int elapsed) {
        if (elapsed >= dist[node]) return;
        dist[node] = elapsed;
        if (graph.ContainsKey(node))
            foreach(int[] info in graph[node])
                dfs(graph, info[1], elapsed + info[0]);
    }
}