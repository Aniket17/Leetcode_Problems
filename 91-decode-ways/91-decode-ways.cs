public class Solution {
    int[] memo;
    public int NumDecodings(string s) {
        memo = new int[s.Length+1];
        Array.Fill(memo, -1);
        return NumWays(s, 0);
    }
    int NumWays(string s, int pos){
        if(memo[pos] != -1) return memo[pos];
        if(pos >= s.Length) return 1;
        if(s[pos] == '0') return 0;
        if(pos == s.Length - 1){
            return 1;
        }
        var ans = NumWays(s, pos+1);
        if(int.Parse(s.Substring(pos, 2)) <= 26){
            ans += NumWays(s, pos+2);
        }
        return memo[pos] = ans;
    }
    /*
    1 + dp(s.Substring(i+1))+dp(s.Substring(i+2))
    */
}