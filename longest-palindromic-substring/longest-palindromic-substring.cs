public class Solution {
    public string LongestPalindrome(string s) {
        if (s == null || s == "") {
            return s;
        }
        
        int len = s.Length;

        String ans = "";
        int max = 0;

        bool[][] dp = new bool[len][];

        for (int j = 0; j < len; j++) {
            dp[j] = new bool[len];
            for (int i = 0; i <= j; i++) {
                
                bool judge = s[i] == s[j];
                
                dp[i][j] = j - i > 2 ? dp[i + 1][j - 1] && judge : judge;

                if (dp[i][j] && j - i + 1 > max) {
                    max = j - i + 1;
                    ans = s.Substring(i, (j - i) + 1);
                }
            }
        }
        return ans;
    }
    
}

/*
"aacabdkacaa"
"aacakdbaacaa"
*/