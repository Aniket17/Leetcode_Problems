public class Solution {
    int[] dp;
    public int NumWays(int n, int k) {
        dp = new int[n+1];
        Array.Fill(dp, -1);
        return TotalWays(n, k);
    }

    int TotalWays(int n, int k){
        if(n < 0) return 0;
        if(n == 2) return k*k;
        if(n == 1) return k;
        if(dp[n] != -1) return dp[n];
        return dp[n] = (k - 1) * (TotalWays(n - 1, k) + TotalWays(n - 2, k));
    }
}