public class Solution {
    /**
    take a course, check deps
    if no deps, put it on stack, mark as done - set
    if course is in reading, cycle - return []
    return stack.reverse + items which are not on stack
    */
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var toRead = Enumerable.Range(0,numCourses).ToArray();
        if(prerequisites.Length == 0){
            return toRead;
        }
        var reading = new HashSet<int>();
        var finished = new HashSet<int>();
        var stack = new Stack<int>();
        
        var graph = new Dictionary<int, List<int>>();
        foreach(var req in prerequisites){
            if(!graph.ContainsKey(req[0])){
                graph[req[0]] = new List<int>();
            }
            graph[req[0]].Add(req[1]);
        }
        
        foreach(var book in toRead){
            if(!graph.ContainsKey(book)){
                if(finished.Add(book)){
                    stack.Push(book);
                }
            }else{
                reading.Add(book);
                if(!ReadBook(graph, book, stack, reading, finished)){
                    return new int[0];
                }
                reading.Remove(book);
                finished.Add(book);
            }
        }
        var result = new int[stack.Count];
        while(stack.Count != 0){
            result[stack.Count - 1] = stack.Pop();
        }
        return result;
    }
    
    bool ReadBook(Dictionary<int, List<int>> graph,
                   int book,
                   Stack<int> stack,
                   HashSet<int> reading,
                   HashSet<int> finished)
    {
        if(!graph.ContainsKey(book)) return true;
        foreach(var dep in graph[book]){
            if(reading.Contains(dep)) return false;
            if(finished.Contains(dep)) continue;
            reading.Add(dep);
            if(!ReadBook(graph, dep, stack, reading, finished)){
                return false;
            }
            if(finished.Add(dep)){
                stack.Push(dep);
            }
            reading.Remove(dep);
        }
        if(finished.Add(book)){
            stack.Push(book);
        }
        return true;
    }
}