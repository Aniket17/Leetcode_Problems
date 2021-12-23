public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
      var finished = new HashSet < int > ();
      var visited = new HashSet < int > ();
      var graph = new Dictionary<int,HashSet<int>>();
      while(--numCourses >= 0){
          graph.Add(numCourses, new HashSet<int>());
      }
      foreach(var pos in prerequisites) {
        graph[pos[0]].Add(pos[1]);
      }

      foreach(var key in graph.Keys) {
        var canFinish = DFS(graph, key, visited, finished);
        if (!canFinish) return new List<int>().ToArray();
            finished.Add(key);
        }
        return finished.ToArray();
    }

    public bool DFS(Dictionary<int,HashSet<int>> graph, int key, HashSet <int> visited, HashSet < int > finished) {
          if (finished.Contains(key)) return true;
          if (visited.Contains(key)) return false;
          visited.Add(key);
          foreach(var nei in graph[key]) {
            if(!DFS(graph, nei, visited, finished)) return false;
          }
          finished.Add(key);
          return true;
    }
}