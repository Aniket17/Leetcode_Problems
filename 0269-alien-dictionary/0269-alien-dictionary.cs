public class Solution {
    public string AlienOrder(string[] words) {
        var graph = new Dictionary<char, HashSet<char>>();
        var inDegree = new Dictionary<char, int>();
        foreach(var word in words){
            foreach(var ch in word){
                if(!graph.ContainsKey(ch)){
                    graph[ch] = new();
                    inDegree[ch] = 0;
                }
            }
        }

        for(int i = 0; i < words.Length - 1; i++){
            var w1 = words[i];
            var w2 = words[i + 1];

            if(w1.Length > w2.Length && w1.StartsWith(w2)) return "";

            var len = Math.Min(w1.Length, w2.Length);

            for(int j = 0; j < len; j++){
                if(w1[j] != w2[j]){
                    //found first diff
                    graph[w1[j]].Add(w2[j]);
                    inDegree[w2[j]]++;
                    break;
                }
            }
        }

        var queue = new Queue<char>();
        foreach(var key in inDegree.Keys){
            if(inDegree[key] == 0){
                queue.Enqueue(key);
            }
        }

        var sb = new StringBuilder();
        while(queue.Count != 0){
            var ch = queue.Dequeue();
            sb.Append(ch);
            foreach(var nei in graph[ch]){
                inDegree[nei]--;
                if(inDegree[nei] == 0){
                    queue.Enqueue(nei);
                }
            }
        }

        return sb.Length != graph.Keys.Count() ? "" : sb.ToString();
    }
}

/*
["wrt","wrf","er","ett","rftt"]
w: [e], 0
r: [t], 1
t: [f], 1
f: [], 1
e: [r], 1

wertf


index w1    w2
0     wrt   wrf
*/