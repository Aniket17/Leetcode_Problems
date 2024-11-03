public class Solution {
    Dictionary<(int, int), int> dp = new();
    public int MinCostII(int[][] costs) {
        var k = costs[0].Length;
        var minCost = int.MaxValue;
        for(int color = 0; color < k; color++){
            minCost = Math.Min(minCost, MinCostUtil(costs, 0, color));
        }
        return minCost;
    }

    public int MinCostUtil(int[][] costs, int currentHouse, int prevColor){
        // Base Condition
        if(currentHouse >= costs.Length)
            return 0;
        if(dp.ContainsKey((currentHouse, prevColor))) return dp[(currentHouse, prevColor)];
        var k = costs[0].Length;
        var minCost = int.MaxValue;
        for(int color = 0; color < k; color++){
            if(color != prevColor){
                var minCostOfCurrentHouse = costs[currentHouse][prevColor] + MinCostUtil(costs, currentHouse + 1, color);
                minCost = Math.Min(minCost, minCostOfCurrentHouse);
            }
        }
        return dp[(currentHouse, prevColor)] = minCost;
    }
}