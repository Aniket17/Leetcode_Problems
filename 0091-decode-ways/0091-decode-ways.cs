public class Solution {
    int[] dp;
    public int NumDecodings(string s, int pos = 0) {
        if(dp == null){
            dp = new int[s.Length];
            Array.Fill(dp, -1);
        }
        if(pos >= s.Length) return 1;
        if(s[pos] == '0') return 0; // cant start with 0
        if(dp[pos] != -1) return dp[pos];
        
        var res = NumDecodings(s, pos + 1);
        if(pos+1 < s.Length && (s[pos] == '1' || (s[pos] == '2' && "0123456".Contains(s[pos+1])))){
            res+=NumDecodings(s, pos + 2);
        }

        dp[pos] = res;
        return dp[pos];
    }
}