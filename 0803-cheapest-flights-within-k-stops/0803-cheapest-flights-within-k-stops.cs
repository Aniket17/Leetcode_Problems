public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int source, int destination, int k) {
        // Build the graph
        var graph = new Dictionary<int, List<(int, int)>>(); // src -> [(dst, price)]
        foreach (var flight in flights) {
            if (!graph.ContainsKey(flight[0])) graph[flight[0]] = new List<(int, int)>();
            graph[flight[0]].Add((flight[1], flight[2]));
        }

        // Priority queue to store (node, totalPrice, stops), priority by totalPrice
        var heap = new PriorityQueue<(int node, int price, int stops), int>();
        heap.Enqueue((source, 0, 0), 0);

        // Keep track of the best price to reach a node with a certain number of stops
        var minPrice = new Dictionary<(int node, int stops), int>();

        while (heap.Count > 0) {
            var (currentNode, currentPrice, stops) = heap.Dequeue();

            // If we reach the destination within k stops, return the current price
            if (currentNode == destination) return currentPrice;

            // If the number of stops exceeds k, continue
            if (stops > k) continue;

            // Explore neighboring nodes
            if (graph.ContainsKey(currentNode)) {
                foreach (var (neighbor, price) in graph[currentNode]) {
                    var newPrice = currentPrice + price;

                    // If this path is cheaper than any previously recorded path for this (node, stops), process it
                    if (!minPrice.ContainsKey((neighbor, stops + 1)) || newPrice < minPrice[(neighbor, stops + 1)]) {
                        minPrice[(neighbor, stops + 1)] = newPrice;
                        heap.Enqueue((neighbor, newPrice, stops + 1), newPrice);
                    }
                }
            }
        }

        return -1; // If we can't reach the destination within k stops
    }
}
