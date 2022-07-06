public class Solution {
    Dictionary<string, int> dp = new Dictionary<string, int>();
    public int LongestPalindromeSubseq(string s) {
        var len = s.Length;
        return GetLengthOfLongestCommonSubsequence(s, new String(s.Reverse().ToArray()), len - 1, len - 1);
    }
    public int GetLengthOfLongestCommonSubsequence(string s, string t, int i, int j) {
        if(i < 0 || j < 0) return 0;
        var key = $"{i},{j}";
        if(dp.ContainsKey(key)) return dp[key];
        
        if(s[i] == t[j]){
            return dp[key] = 1 + GetLengthOfLongestCommonSubsequence(s, t, i - 1, j - 1);
        }else{
            var l1 = GetLengthOfLongestCommonSubsequence(s, t, i, j - 1);
            var l2 = GetLengthOfLongestCommonSubsequence(s, t, i - 1, j);
            return dp[key] = Math.Max(l1, l2);
        }
    }
}