public class Solution{
        public class Edge : IComparable<Edge>{
            public int key;
            public int weight;

            public Edge(int k, int w)
            {
                key = k;
                weight = w;
            }

            public int CompareTo(Edge other)
            {
                return weight - other.weight;
            }
        }


        public int NetworkDelayTime(int[][] times, int n, int k) {
            var ans = 0;

            var heap = new PriorityQueue<Edge, int>();

            var graph = new Dictionary<int, List<Edge>>();

            var map = new Dictionary<int, int>();

            for (int i = 1; i < n + 1; i++)
            {
                graph[i] = new List<Edge>();
                map[i] = int.MaxValue;
            }

            foreach(var time in times){
                graph[time[0]].Add(new Edge(time[1], time[2]));
            }

            map[k] = 0;

            heap.Enqueue(new Edge(k, 0), 0);

            HashSet<int> seen = new HashSet<int>();

            while (heap.Count != 0) {
                var node = heap.Dequeue();

                if (seen.Contains(node.key)) continue;

                map[node.key] = Math.Min(map[node.key], node.weight);

                foreach (var nei in graph[node.key])
                {
                    var dist = nei.weight + map[node.key];
                    if (dist < map[nei.key])
                    {
                        map[nei.key] = dist;
                    }
                    if (!seen.Contains(nei.key)) {
                        heap.Enqueue(new Edge(nei.key, dist), dist);
                    }
                }
                seen.Add(node.key);
            }

            if(map.Any(x=>x.Value == int.MaxValue))
            {
                return -1;
            }
            return map.Max(x=>x.Value);
        }
    }