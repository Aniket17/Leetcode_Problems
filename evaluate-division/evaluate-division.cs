public class Solution {
    /*
    [["a","b"],["b","c"]], values = [2.0,3.0]
    {
        a: [b,2]
        b: [a,0.5],[c,3]
        c: [b, 0.33]
    }
    */
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var graph = new Dictionary<string, List<(string label, double val)>>();
        var n = equations.Count;
        for(int i = 0; i < n; i++){
            var eq = equations[i];
            var val = values[i];
            if(!graph.ContainsKey(eq[0])){
                graph[eq[0]] = new();
            }
            graph[eq[0]].Add((eq[1], val));
            
            if(!graph.ContainsKey(eq[1])){
                graph[eq[1]] = new();
            }
            graph[eq[1]].Add((eq[0], 1/val));
        }
        var res = new double[queries.Count];
        for(int i = 0; i < queries.Count; i++){
            var q = queries[i];
            if(graph.ContainsKey(q[0]) && graph.ContainsKey(q[1])){
                res[i] = Dfs(graph, q[0], q[1], new HashSet<string>{q[0]});
            }else{
                res[i] = -1.0;
            }
        }
        return res;
    }
    
    double Dfs(Dictionary<string, List<(string label, double val)>> graph, string src, string dst, HashSet<string> seen){
        if(src == dst) return 1;
        foreach(var nei in graph[src]){
            if(seen.Contains(nei.label)) continue;
            if(nei.label == dst){
                return nei.val;
            }
            seen.Add(nei.label);
            var ans = Dfs(graph, nei.label, dst, seen);
            seen.Remove(nei.label);
            if(ans != -1.0){
                return ans * nei.val;
            }
        }
        return -1.0;
    }
}