public class Solution {
    int[] dp;
    public int LongestIncreasingPath(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        dp = new int[m*n];
        Array.Fill(dp, -1);
        var max = 0;
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                dp[row*n+col] = LongestIncreasingPath(matrix, row, col);
                max = Math.Max(max, dp[row*n+col]);
            }
        }
        return 1+max;
    }

    int LongestIncreasingPath(int[][] matrix, int row, int col){
        int m = matrix.Length, n = matrix[0].Length;
        var dirs = new int[4][]{
            new int[]{1,0},
            new int[]{-1,0},
            new int[]{0,1},
            new int[]{0,-1}
        };
        if(dp[row * n + col] != -1) return dp[row * n + col];
        var ans = 0;
        foreach(var dir in dirs){
            var newRow = row+dir[0];
            var newCol = col+dir[1];
            if(newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && matrix[newRow][newCol] > matrix[row][col]){
                ans = Math.Max(ans, 1 + LongestIncreasingPath(matrix, newRow, newCol));
            }
        }
        return dp[row*n+col] = ans;
    }
}


/*
[
[3,2,1],
[0,3,0],
[1,0,0]
]
*/