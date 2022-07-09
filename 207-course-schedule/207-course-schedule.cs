public class Solution {
    HashSet<int> finished = new HashSet<int>();
    HashSet<int> reading = new HashSet<int>();
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph = new Dictionary<int, List<int>>();
        foreach(var req in prerequisites){
            if(!graph.ContainsKey(req[0])){
                graph[req[0]] = new List<int>();
            }
            graph[req[0]].Add(req[1]);
        }
        
        for(int i = 0; i < numCourses; i++){
            if(!CanFinish(graph, i)){
                return false;
            }
        }
        return true;
    }
    
    private bool CanFinish(Dictionary<int, List<int>> graph, int course){
        if(!graph.ContainsKey(course)) {
            finished.Add(course);
            reading.Remove(course);
            return true;
        }
        if(finished.Contains(course)) return true;
        if(reading.Contains(course)) return false;
        
        reading.Add(course);
        var deps = graph[course];
        foreach(var dep in deps){
            if(!CanFinish(graph, dep)){
                return false;
            }
            finished.Add(dep);
            reading.Remove(course);
        }
        return true;
    }
}