public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
      //build the graph
      var graph = new Dictionary<int, List<(int, int)>>();
      foreach(var time in times){
        if(!graph.ContainsKey(time[0])){
            graph[time[0]] = new();
        }
        graph[time[0]].Add((time[1], time[2]));
      }
      
      //build the distances map
      var distances = new Dictionary<int, int>();
      for(int i = 1; i <= n; i++){
        distances[i] = int.MaxValue;
      }
      distances[k] = 0;

      //build the heap
      var heap = new PriorityQueue<(int node, int dist), int>();
      heap.Enqueue((k, 0), 0);

      //relaxation and update logic
      while(heap.Count != 0){
        var (src, currentDistance) = heap.Dequeue();
        if(distances[src] < currentDistance) continue;

        //iterate thru all neighbors
        if(graph.ContainsKey(src)){
            foreach(var (nei, dist) in graph[src]){
                var newDistance = dist + currentDistance;
                if(distances[nei] > newDistance){
                    //relaxation
                    distances[nei] = newDistance;
                    heap.Enqueue((nei, newDistance), newDistance);
                }
            }
        }
      }

      if(distances.Any(x=>x.Value == int.MaxValue)) return -1; //unreachable node
      return distances.Max(x=>x.Value);
    }
}