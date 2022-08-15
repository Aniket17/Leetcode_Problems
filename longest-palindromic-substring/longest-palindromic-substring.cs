public class Solution {
    public string LongestPalindrome(string s) {
        int len = s.Length;
        if(len == 0) return s;
        
        string ans = "";
        int max = 0;

        bool[][] dp = new bool[len][];

        for (int j = 0; j < len; j++) {
            dp[j] = new bool[len];
            for (int i = 0; i <= j; i++) {
                bool isSame = s[i] == s[j];
                
                if(i == j){
                    //single char is always palindrome
                    dp[i][j] = true;
                } else if(j - i == 1){
                    dp[i][j] = isSame;
                }else{
                    dp[i][j] = dp[i + 1][j - 1] && isSame;
                }
                if (dp[i][j] && j - i + 1 > max) {
                    max = j - i + 1;
                    ans = s.Substring(i, (j - i) + 1);
                }
            }
        }
        return ans;
    }
}