public class Solution {
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
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var graph = new Dictionary<int, List<Node>>();
        var prices = new int[n];
        Array.Fill(prices, -1);
        for(int i = 0; i < n; i++){
            graph[i] = new List<Node>();
        }
        foreach(var flight in flights){
            int s = flight[0], d=flight[1], price=flight[2];
            graph[s].Add(new Node(d, price));
        }
        Queue<Node> queue = new();
        queue.Enqueue(new Node(src, 0));

        while(queue.Count > 0){
            var size = queue.Count;
            if(k < 0) break; 
            while(size-- > 0){
                var node = queue.Dequeue();
                var currPrice = node.weight;
                foreach(var pair in graph[node.key]){
                    int price = currPrice + pair.weight;

                    if(prices[pair.key] == -1 || prices[pair.key] > price){
                        prices[pair.key] = price;
                        queue.Enqueue(new Node(pair.key, price));
                    }
                }
            }
            k--;
        }
        return prices[dst];
    }
}