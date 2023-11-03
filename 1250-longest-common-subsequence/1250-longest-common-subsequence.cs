public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        var m = text1.Length;
        var n = text2.Length;
        var len = 0;
        var dp = new int[m+1][];
        dp[0] = new int[n+1];

        for(int i = 1; i <= m; i++){
            dp[i] = new int[n+1];
            for(int j = 1; j <= n; j++){
                if(text1[i-1] == text2[j-1]){
                    dp[i][j] = 1 + dp[i-1][j-1];
                }else{
                    dp[i][j] = Math.Max(dp[i-1][j], dp[i][j-1]);
                }
                len = Math.Max(len, dp[i][j]);
            }
        }
        return len;
    }
}

/*
    "" a b c d e
''  0  0 0 0 0 0
a   0   
c   0
e   0

*/