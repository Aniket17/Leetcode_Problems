public class Solution {
    
    Dictionary<string, bool> memo = new Dictionary<string, bool>();
    
    public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs) {
        if(sentence1.Length != sentence2.Length) return false;
        
        var graph = new Dictionary<string, HashSet<string>>();
        
        foreach(var pair in similarPairs){
            if(!graph.ContainsKey(pair[0])){
                graph[pair[0]] = new HashSet<string>();
            }
            if(!graph.ContainsKey(pair[1])){
                graph[pair[1]] = new HashSet<string>();
            }
            graph[pair[0]].Add(pair[1]);
            graph[pair[1]].Add(pair[0]);
        }
        
        for(int i = 0; i < sentence1.Length; i++){
            if(sentence1[i] == sentence2[i]){
                continue;
            }
            if(!graph.ContainsKey(sentence1[i])){
                return false;
            }
            
            // DFS with src and dst
            if(!HasPath(graph, sentence1[i], sentence2[i], new HashSet<string>())){
                return false;
            }
        }
        return true;
    }
    
    bool HasPath(Dictionary<string, HashSet<string>> graph, string src, string dst, HashSet<string> seen){
        if(!graph.ContainsKey(src)){
            return false;
        }
        if(graph[src].Contains(dst)){
            return true;
        }
        // if(seen.Contains(src)) return false;
        
        var key = $"{src},{dst}";
        // if(memo.ContainsKey(key)) return memo[key];
        
        foreach(var nei in graph[src]){
            if(seen.Contains(nei)) continue;
            seen.Add(nei);
            if(HasPath(graph, nei, dst, seen)){
                return memo[key] = true;
            }
        }
        return memo[key] = false;
    }
}