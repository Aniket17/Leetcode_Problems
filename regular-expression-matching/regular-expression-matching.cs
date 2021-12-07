public class Solution {
    public bool IsMatch(string s, string p) {
        var sLen = s.Length;
        var pLen = p.Length;
        bool[][] dp = new bool[sLen + 1][];
        dp[0] = new bool[pLen + 1];
        dp[0][0] = true;
        for(int j = 1; j <= pLen; j++){
            if(p[j - 1] == '*'){
                dp[0][j] = dp[0][j - 2];
            }
        }
        for (int i = 1; i <= sLen; ++i) {
            dp[i] = new bool[pLen + 1];
            for (int j = 1; j <= pLen; ++j) {
                if(s[i - 1] == p[j - 1] || p[j - 1] == '.'){
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else if (p[j - 1] == '*'){
                    dp[i][j] = dp[i][j - 2];
                    
                    if(p[j - 2] == '.' || s[i - 1] == p[j - 2]){
                        dp[i][j] = dp[i][j] || dp[i - 1][j];
                    }
                    
                }
                else{
                    dp[i][j] = false;
                }
                    
            }
        }
        return dp[sLen][pLen];
    }
}

/*  
"ab", p = ".*"
    ""  .   *
""  1   0   0
a   0   1   1
b   0   0   1
*/
