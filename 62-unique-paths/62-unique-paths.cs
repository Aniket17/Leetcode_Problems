public class Solution {
    int[] dp;
    int count = 0;
    public int UniquePaths(int m, int n) {
        if(m == 1 || n == 1) return 1;
        dp = new int[m*n];
        Array.Fill(dp, -1);
        Solve(0, 0, m, n);
        return dp[0];
    }
    
    public int Solve(int row, int col, int m, int n){
        if(row == m - 1 && col == n - 1){
            return 1;
        }
        if(row >= m || col >= n) return 0;
        var key = row*n+col;
        if(dp[key] != -1) return dp[key];
        return dp[key] = Solve(row+1, col, m, n) + Solve(row, col+1, m, n);
    }
}