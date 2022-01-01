public class Solution{

        public class Edge {
            public int key;
            public int weight;

            public Edge(int k, int w)
            {
                key = k;
                weight = w;
            }
        }

        public class MinHeap {
            List<Edge> items;
            int count;
            public MinHeap(int size)
            {
                items = new List<Edge>();
                count = 0;
            }

            public void Enqueue(Edge e) {
                items.Add(e);
                items[count++] = e;

                HeapifyUp();
            }

            public Edge Dequeue() {
                var last = items[count - 1];
                var top = items.First();
                items[0] = last;
                count -= 1;
                HeapifyDown();
                return top;
            }

            public Edge Peek() => items.First();

            public int Count { get { return count; } }


            private void HeapifyUp() {
                var childIndex = count - 1;
                while (childIndex > 0) {

                    var parentIndex = (childIndex - 1) / 2;

                    if (items[parentIndex].weight > items[childIndex].weight)
                    {
                        Swap(parentIndex, childIndex);
                        childIndex = parentIndex;
                    }
                    else {
                        break;
                    }
                }
            }

            private void HeapifyDown()
            {
                var currentIndex = 0;
                var leftIndex = 1;
                var rightIndex = 2;
                while (leftIndex < count || rightIndex < this.count)
                {
                    var minChildIndex = leftIndex;
                    if (rightIndex < this.count && this.items[rightIndex].weight < this.items[leftIndex].weight)
                    {
                        minChildIndex = rightIndex;
                    }

                    if (this.items[minChildIndex].weight < this.items[currentIndex].weight)
                    {
                        Swap(minChildIndex, currentIndex);

                        currentIndex = minChildIndex;
                        leftIndex = (currentIndex * 2) + 1;
                        rightIndex = (currentIndex * 2) + 2;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Swap(int i, int j) {
                var tmp = items[j];
                items[j] = items[i];
                items[i] = tmp;
            }
        }


        public int NetworkDelayTime(int[][] times, int n, int k) {
            var ans = 0;

            var heap = new MinHeap(n);

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

            heap.Enqueue(new Edge(k, 0));

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
                        heap.Enqueue(new Edge(nei.key, dist));
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