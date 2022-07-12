public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        if(src == dst) return 0;
        int[] distances = new int[n];
        int[] prev = new int[n];
        Array.Fill(distances, int.MaxValue);
        Array.Fill(prev, int.MaxValue);
        distances[src] = 0;
        prev[src] = 0;
        
        for(int i = 0; i <= k; i++){
            distances[src] = 0;
            foreach(var fl in flights){
                var u = fl[0];
                var v = fl[1];
                var price = fl[2];
                if(prev[u] != int.MaxValue){
                    distances[v] = Math.Min(distances[v], prev[u] + price);
                }
            }
            prev = distances.ToArray();
        }
        return distances[dst] == int.MaxValue ? -1 : distances[dst];
    }
}