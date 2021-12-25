public class Solution {
    Dictionary<string, int> memo;
    public int MinInsertions(string s) {
        memo = new Dictionary<string, int>();
        var lcs = GetLCS(s, new String(s.Reverse().ToArray()), 0, 0);
        return s.Length - lcs;
    }
    
    public int GetLCS(string s, string t, int i, int j){
        if(i >= s.Length || j >= t.Length){
            return 0;
        }
        var key = $"{i},{j}";
        if(memo.ContainsKey(key)) return memo[key];
        if(s[i] == t[j]){
            return memo[key] = 1 + GetLCS(s, t, i + 1, j + 1);
        }
        return memo[key] = Math.Max(GetLCS(s, t, i + 1, j), GetLCS(s, t, i, j + 1));
    }
}