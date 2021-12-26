public class Solution {
    public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs) {
        
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
            if(!graph[sentence1[i]].Contains(sentence2[i])){
                return false;
            }
        }
        return true;
    }
}