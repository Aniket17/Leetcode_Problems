public class Solution {
    public int[] GardenNoAdj(int n, int[][] paths) {
        var graph = new Dictionary<int, HashSet<int>>();
        foreach(var e in paths){
            var src = e[0];
            var dst = e[1];
            if(!graph.ContainsKey(src)){
                graph[src] = new HashSet<int>();
            }
            if(!graph.ContainsKey(dst)){
                graph[dst] = new HashSet<int>();
            }
            graph[src].Add(dst);
            graph[dst].Add(src);
        }
        
        var ans = new int[n];
        
        for(int i = 1; i <= n; i++){
            var color = new int[5];
            if(!graph.ContainsKey(i)) {
                ans[i - 1] = 1;
                continue;
            }
            foreach(var nei in graph[i]){
                color[ans[nei - 1]] = 1;
            }
            
            for(int j = 1; j <= 4; j++){
                if(color[j] == 0){
                    ans[i - 1] = j;
                    break;
                }
            }
        }
        return ans;
    }
}

/*
m coloring

*/