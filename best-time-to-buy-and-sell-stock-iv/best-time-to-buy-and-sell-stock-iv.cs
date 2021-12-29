public class Solution {
    public int MaxProfit(int k, int[] prices) {
        var days = prices.Length;
        if(days < 2) return 0;
        
        int[][] dp = new int[k + 1][];
        for(int i = 0; i <= k; i++){
            dp[i] = new int[days];
        }
        
        for(int i = 1; i < dp.Length; i++){
            var maxDiff = -prices[0];
            
            // dp[i][j-1] => not transacting on jth day with i transactions
            // prices[j] + maxDiff => choose to transact
            // dp[i - 1][j] => profit on same day from last transaction
            
            for(int j = 1; j < dp[0].Length; j++){
                dp[i][j] = Math.Max(dp[i][j - 1], prices[j] + maxDiff);
                
                maxDiff = Math.Max(maxDiff, dp[i - 1][j] - prices[j]);
            }
        }
        return dp[k][days - 1];
    }
}