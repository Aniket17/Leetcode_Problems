public class Solution {
    int minPrice = int.MaxValue;
    Dictionary<string, int> memo;
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        
        var graph = new Dictionary<int, Dictionary<int, int>>();
        
        memo = new Dictionary<string, int>();
        
        for(int i = 0; i < n; i++){
            graph[i] = new Dictionary<int, int>();
        }
        
        foreach(var f in flights){
            var n1 = f[0];
            var n2 = f[1];
            var price = f[2];
            
            graph[n1].Add(n2, price);
        }
        
        if(k == 0){
            //no stops
            if(graph[src].ContainsKey(dst)){
                return graph[src][dst];
            }else{
                return -1;
            }
        }
        
        //BFS
        var minPrice = int.MaxValue;
        var queue = new Queue<Tuple<int, int>>();
        
        int[] prices = new int[n];
        Array.Fill(prices, -1);
        
        queue.Enqueue(Tuple.Create(src, 0));
        
        while(queue.Count > 0){
            var size = queue.Count;
            if(k < 0) break; 
            while(size-- > 0){
                var tuple = queue.Dequeue();
                var node = tuple.Item1;
                var currPrice = tuple.Item2;
                
                foreach(var pair in graph[node]){
                    int price = currPrice + pair.Value;
                    
                    if(prices[pair.Key] == -1 || prices[pair.Key] > price){
                        
                        prices[pair.Key] = price;
                        
                        queue.Enqueue(Tuple.Create(pair.Key, price));
                    }
                }
            }
            k--;
        }
        
        return prices[dst];
    }
}

/*

a -> b 100
a -> c 200
b -> c 50 

dfs -> src -> dst
src -> changes increase currK 
if currK > k return max

*/