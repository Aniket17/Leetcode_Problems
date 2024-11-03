public class Solution {
    Dictionary<(int, int), int> dp = new();
    public int MinCost(int[][] costs) {
        //paint with color1, color2 or color3
        //track prev in recursion relation
        //ith house paint cost = prev == Min(costs[color1] + dp(i+1, costs, color2..color3))
        var color1 = MinCostUtil(costs, 0, 0);
        var color2 = MinCostUtil(costs, 0, 1);
        var color3 = MinCostUtil(costs, 0, 2);
        return Math.Min(color3, Math.Min(color1, color2));
    }
    int MinCostUtil(int[][] costs, int index, int prev){
        if(index == costs.Length) return 0;
        if(dp.ContainsKey((index, prev))) return dp[(index, prev)];
        var minCost = int.MaxValue;
        int color1, color2;
        switch(prev){
            case 0:
                color1 = costs[index][prev] + MinCostUtil(costs, index+1, 1);
                color2 = costs[index][prev] + MinCostUtil(costs, index+1, 2);
                minCost = Math.Min(color1, color2);
                break;
            case 1:
                color1 = costs[index][prev] + MinCostUtil(costs, index+1, 0);
                color2 = costs[index][prev] + MinCostUtil(costs, index+1, 2);
                minCost = Math.Min(color1, color2);
                break;
            case 2:
                color1 = costs[index][prev] + MinCostUtil(costs, index+1, 1);
                color2 = costs[index][prev] + MinCostUtil(costs, index+1, 0);
                minCost = Math.Min(color1, color2);
                break;
        }

        return dp[(index, prev)] = minCost;
    }
}