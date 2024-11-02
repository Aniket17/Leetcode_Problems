public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        var n = cost.Length;
        int[] dp = new int[n];
        Array.Fill(dp, int.MaxValue);
        return Math.Min(CalcCost(0), CalcCost(1));

        int CalcCost(int index){
            if(index >= n) return 0;
            if(index == n-1) return cost[n-1];
            if(dp[index] != int.MaxValue) return dp[index];
            return dp[index] = Math.Min(cost[index] + CalcCost(index+1), cost[index] + CalcCost(index+2));
        }
    }
}