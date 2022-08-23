public class Solution {
    public bool AreSentencesSimilarTwo(string[] s1, string[] s2, IList<IList<string>> similarPairs) {
        if(s1.Length != s2.Length) return false;
        var graph = new Dictionary<string, HashSet<string>>();
        foreach(var pair in similarPairs){
            var src = pair[0];
            var dst = pair[1];
            if(!graph.ContainsKey(src)){
                graph[src] = new();
            }
            if(!graph.ContainsKey(dst)){
                graph[dst] = new();
            }
            graph[src].Add(dst);
            graph[dst].Add(src);
        }
        
        for(int i = 0; i < s1.Length; i++){
            if(s1[i] == s2[i]) continue;
            if(!graph.ContainsKey(s1[i]) || !graph.ContainsKey(s2[i])) return false;
            var src = s1[i];
            var dst = s2[i];
            if(!HasPath(src, dst, graph, new HashSet<string>(){src})) return false;
        }
        return true;
    }
    
    bool HasPath(string src, string dst, Dictionary<string, HashSet<string>> graph, HashSet<string> seen){
        if(src == dst) return true;
        foreach(var nei in graph[src]){
            if(seen.Contains(nei)) continue;
            seen.Add(nei);
            if(HasPath(nei, dst, graph, seen)){
                return true;
            }
            seen.Remove(nei);
        }
        return false;
    }
}