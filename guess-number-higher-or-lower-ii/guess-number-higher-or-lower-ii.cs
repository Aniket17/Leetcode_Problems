public class Solution {
    public int GetMoneyAmount(int n) {
        int[][] dp = new int[n + 2][];
        for(int i = 0; i < n+2; i++){
            dp[i] = new int[n + 1];
        }
        for(int len = 2; len <= n; len++){
            for(int start = 1; start <= n - len + 1; start++){
                var end = start + len - 1;
                var min = int.MaxValue;
                
                for(int pivot = start; pivot <= end; pivot++){
                    min = Math.Min(min, pivot + Math.Max(dp[start][pivot - 1], dp[pivot + 1][end]));
                }
                
                dp[start][end] = min;
            }
        }
        
        return dp[1][n];
    }
}