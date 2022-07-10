public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        int[,] dp = new int[m + 1, n + 1];
        
        foreach (string s in strs) {
            int ones = 0;
            int zeros = 0;
            foreach (char ch in s) {
                if (ch == '1') ones++;
                else if (ch == '0') zeros++;
            }
            for (int i = m; i >= zeros; i--) {
                for (int j = n; j >= ones; j--) {
                    dp[i,j] = Math.Max(dp[i,j], 1 + dp[i - zeros, j - ones]);
                }
            }
        }
        return dp[m,n];
    }
}

/*
base case 
pos == len
store max

map[index, [0s, 1s]]

include -> minus 0s from m and minus 1s from n and add 1
do not include -> keep m and n but increase pos
*/