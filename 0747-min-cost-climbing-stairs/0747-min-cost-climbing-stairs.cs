public class Solution {
    int[] dp;
    public int MinCostClimbingStairs(int[] costs) {
        // two choices, climb 1 or 2
        // choose min from 1,2 climb there and add to cost
        var n = costs.Length;
        dp = new int[n + 1];
        Array.Fill(dp, -1);
        return Solve(n, costs);
    }
    
    public int Solve(int index, int[] costs){
        if(index <= 1){
            return 0;
        }
        if(dp[index] != -1) return dp[index];
        
        var first = Solve(index - 1, costs) + costs[index - 1];
        var second = Solve(index - 2, costs) + costs[index - 2];
        dp[index] = Math.Min(first, second);
        return dp[index];
    }
}