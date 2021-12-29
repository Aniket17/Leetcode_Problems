public class Solution {
    public int MinPathSum(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        
        var dp = new int[m][];
        dp[0] = new int[n];
        dp[0][0] = grid[0][0];
        
        for(int i = 1; i < m; i++){
            dp[i] = new int[n];
            dp[i][0] = dp[i - 1][0] + grid[i][0];
        }
        
        for(int i = 1; i < n; i++){
            dp[0][i] = dp[0][i - 1] + grid[0][i];;
        }
        
        for(int i = 1; i < m; i++){
            for(int j = 1; j < n; j++){
                dp[i][j] = grid[i][j] + Math.Min(dp[i][j - 1], dp[i - 1][j]);
            }
        }
        
        return dp[m - 1][n - 1];
    }
}