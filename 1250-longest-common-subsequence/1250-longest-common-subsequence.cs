public class Solution {
    Dictionary<(int, int), int> dp;
    public int LongestCommonSubsequence(string text1, string text2) {
        dp = new();
        return LongestCommonSubsequenceUtil(text1, text2, 0, 0);
    }
    int LongestCommonSubsequenceUtil(string s, string t, int i, int j){
        if(i >= s.Length || j >= t.Length) return 0;
        if(dp.ContainsKey((i,j))) return dp[(i,j)];
        if(s[i] == t[j]){
            return 1 + LongestCommonSubsequenceUtil(s, t, i + 1, j + 1);
        }
        return dp[(i,j)] = Math.Max(LongestCommonSubsequenceUtil(s, t, i + 1, j), LongestCommonSubsequenceUtil(s, t, i, j + 1));
    }
}