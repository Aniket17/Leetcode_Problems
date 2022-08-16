public class Solution {
    int[,] memo;
    public int LongestCommonSubsequence(string s, string t) {
        var m = s.Length;
        var n = t.Length;
        memo = new int[m,n];
        for(int i =0;i < m; i++)
            for(int j = 0; j < n; j++) memo[i,j]=-1;
        
        return LongestCommonSubsequenceUtil(s, t, m - 1, n - 1, memo);
    }
    int LongestCommonSubsequenceUtil(string s, string t, int sPos, int tPos, int[,] memo){
        if(sPos < 0 || tPos < 0) return 0;
        
        if(memo[sPos, tPos] != -1){
            return memo[sPos, tPos];
        }
        
        if(s[sPos] == t[tPos]){
            return memo[sPos, tPos] = 1 + LongestCommonSubsequenceUtil(s, t, sPos - 1, tPos - 1, memo);
        }
        return memo[sPos, tPos] = Math.Max(LongestCommonSubsequenceUtil(s, t, sPos - 1, tPos, memo), LongestCommonSubsequenceUtil(s, t, sPos, tPos - 1, memo));
    }
}