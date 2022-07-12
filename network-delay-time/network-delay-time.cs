public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var distance = new int[n];
        Array.Fill(distance, int.MaxValue);
        distance[k - 1] = 0;

        for(int i = 0; i < n -1; i++){
            //relax the edge
            foreach(var edge in times){
                var u = edge[0] - 1;
                var v = edge[1] - 1;
                var weight = edge[2];
                if(distance[u] == int.MaxValue) continue;
                if(distance[u] + weight < distance[v]){
                    distance[v] = distance[u] + weight;
                }
            }
        }
        Console.WriteLine(string.Join(",", distance));
        return distance.Any(x=>x == int.MaxValue) ? -1 : distance.Max();
    }
}