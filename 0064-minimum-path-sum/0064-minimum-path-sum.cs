public class Solution {
    int[][] dp;
    public int MinPathSum(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        dp = new int[m][];
        for(int i = 0; i < m; i++){
            dp[i] = new int[n];
            for(int j = 0; j < n; j++){
                dp[i][j] = int.MaxValue;
            }
        }
        dp[m-1][n-1] = grid[m-1][n-1];
        FindPathSum(grid, 0, 0);
        return dp[0][0];
    }

    int FindPathSum(int[][] grid, int row, int col){
        int m = grid.Length, n = grid[0].Length;
        if(row < 0 || col < 0 || row >= m || col >= n) return int.MaxValue;
        if(dp[row][col] != int.MaxValue) return dp[row][col];

        var rightSum = FindPathSum(grid, row + 1, col);
        var leftSum = FindPathSum(grid, row, col + 1);
        var subSum = grid[row][col] + Math.Min(rightSum, leftSum);
        dp[row][col] = Math.Min(dp[row][col], subSum);
        return subSum;
    }
}