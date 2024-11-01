public class Solution {
    public string AlienOrder(string[] words) {
        var adjList = new Dictionary<char, HashSet<char>>();
        var inDegree = new Dictionary<char, int>();
        
        foreach (var word in words) {
            foreach (var c in word) {
                if (!adjList.ContainsKey(c)) {
                    adjList[c] = new HashSet<char>();
                    inDegree[c] = 0;  // Initialize in-degree for each unique character
                }
            }
        }

        // Build graph by comparing adjacent words
        for (int i = 0; i < words.Length - 1; i++) {
            var w1 = words[i];
            var w2 = words[i + 1];
            int len = Math.Min(w1.Length, w2.Length);
            
            // Check for invalid order (prefix issue)
            if (w1.Length > w2.Length && w1.StartsWith(w2)) {
                return ""; // Invalid case where a longer word is a prefix of a shorter one
            }

            for (int j = 0; j < len; j++) {
                if (w1[j] != w2[j]) {
                    if (!adjList[w1[j]].Contains(w2[j])) {
                        adjList[w1[j]].Add(w2[j]);
                        inDegree[w2[j]]++; // Increment in-degree for the target node
                    }
                    break; // Only the first differing character matters
                }
            }
        }

        var result = new StringBuilder();
        //Enqueue all the 0 inDegree nodes
        var queue = new Queue<char>();
        foreach(var kv in inDegree){
            if(kv.Value == 0){
                queue.Enqueue(kv.Key);
            }
        }

        while(queue.Count != 0){
            var node = queue.Dequeue();
            result.Append(node);
            foreach(var nei in adjList[node]){
                inDegree[nei]--;
                if(inDegree[nei] == 0){
                    queue.Enqueue(nei);    
                }
            }
        }

         // If the result length does not match the number of unique characters, a cycle is present
        if (result.Length != adjList.Count) {
            return "";
        }

        return result.ToString();
    }
}

/*
["wrt","wrf","er","ett","rftt"]
w: r
r: t,f
e: r,t
f: t
t: 

t: r,w,e,f
r: w,e
f: r,w

w,r,t

w->r->t
e->r->f
e->t
r->f->t
w->e->r
*/