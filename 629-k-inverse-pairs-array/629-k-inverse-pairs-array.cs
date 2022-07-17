public class Solution {
    public int KInversePairs(int n, int k) {
        int[][] dp = new int[n + 1][];
        dp[0] = new int[k+1];
        for (int i = 1; i <= n; i++) {
            dp[i] = new int[k + 1];
            for (int j = 0; j <= k; j++) {
                if (j == 0)
                    dp[i][j] = 1;
                else {
                    for (int p = 0; p <= Math.Min(j, i - 1); p++)
                        dp[i][j] = (dp[i][j] + dp[i - 1][j - p]) % 1000000007;
                }
            }
        }
        return dp[n][k];
    }
}