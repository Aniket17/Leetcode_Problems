public class Solution {
    Dictionary<string, int> memo = new Dictionary<string, int>();
    public int LengthOfLIS(int[] nums) {
        var sorted = nums.Distinct().ToArray();
        Array.Sort(sorted);
        return LengthOfLCS(nums, sorted);
    }
    
    int LengthOfLCS(int[] first, int[] second){
        var m = first.Length;
        var n = second.Length;

        var dp = new int[m + 1][];
        dp[0] = new int[n + 1];
        for(int i = 1; i <= m; i++){
            dp[i] = new int[n + 1];
            for(int j = 1; j <= n; j++){
                if(first[i - 1] == second[j - 1]){
                     dp[i][j] = 1 + dp[i - 1][j - 1];
                }else{
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }
        return dp[m][n];
    }
}