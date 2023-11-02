public class Solution{
        public class Node : IComparable<Node>{
            public int key;
            public int weight;

            public Node(int k, int w)
            {
                key = k;
                weight = w;
            }

            public int CompareTo(Node other)
            {
                return weight - other.weight;
            }
        }


        public int NetworkDelayTime(int[][] times, int n, int k) {
            Dictionary<int, List<Node>> graph = new();
            Dictionary<int, int> map = new();
            HashSet<int> seen = new();
            var heap = new PriorityQueue<Node, int>();

            for(int i = 1; i <= n; i++){
                graph.Add(i, new List<Node>());
                map[i] = int.MaxValue; //current distance
            }

            foreach(var edge in times){
                int src = edge[0], dst = edge[1], weight = edge[2];
                graph[src].Add(new Node(dst, weight));
            }

            map[k] = 0; //starting node dist is 0
            heap.Enqueue(new Node(k, 0), 0);
            
            //BFS
            while(heap.Count != 0){
                var node = heap.Dequeue();
                
                //check if its seen
                if(seen.Contains(node.key)) continue;

                //update the distance in map
                map[node.key] = Math.Min(map[node.key], node.weight);

                //check the neighbors/outgoing edges
                foreach(var nei in graph[node.key]){
                    var dist = map[node.key] + nei.weight; //update dist to time to reach parent + parent to nei
                    map[nei.key] = Math.Min(map[nei.key], dist);
                    heap.Enqueue(new Node(nei.key, map[nei.key]), map[nei.key]);
                }

                //add to seen
                seen.Add(node.key);
            }
            return map.Any(x=>x.Value == int.MaxValue) ? -1 : map.Max(x=>x.Value);
        }
    }