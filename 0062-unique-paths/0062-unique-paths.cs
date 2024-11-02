public class Solution {
    public int UniquePaths(int m, int n) {
        int[][] dp = new int[m][];
        for(int i = 0; i < m; i++){
            dp[i] = new int[n];
            Array.Fill(dp[i], -1);
        }
        dp[m-1][n-1] = 1;
        return FindUniquePaths(dp, 0, 0, m, n);
    }

    int FindUniquePaths(int[][] dp, int row, int col, int m, int n){
        if(!IsValid(row, col, m, n)) return 0;
        if(dp[row][col] != -1) return dp[row][col];

        dp[row][col] = FindUniquePaths(dp, row+1, col, m, n) 
        + FindUniquePaths(dp, row, col+1, m, n);

        return dp[row][col];
    }

    bool IsValid(int row, int col, int m, int n){
        return row < m && row >= 0 && col < n && col >= 0;
    }
}