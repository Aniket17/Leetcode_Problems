public class Solution {
    Dictionary<string, int> memo;
    public int MinCostII(int[][] costs) {
        if(costs.Length == 0) return 0;
        memo = new Dictionary<string, int>();
        var ans = int.MaxValue;
        for(int i = 0; i < costs[0].Length; i++){
            ans = Math.Min(MinCost(costs, 0, i), ans);
        }
        return ans;
    }
    
    private int MinCost(int[][] costs, int house, int color){
        if(house == costs.Length) return 0;
        var ans = int.MaxValue;
        if(memo.ContainsKey($"{house},{color}")) return memo[$"{house},{color}"];
        for(int i = 0; i < costs[0].Length; i++){
            if(i == color) continue;
            ans = Math.Min(ans, MinCost(costs, house + 1, i) + costs[house][i]);
        }
        memo[$"{house},{color}"] = ans;
        return memo[$"{house},{color}"];
    }
}


/*
[17,2,17]
[16,16,5]
[14,3,19]
*/