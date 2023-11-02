public class Solution {
    int[] dp;
    public int Rob(int[] houses, int index = 0) {
        if(dp == null){
            dp = new int[houses.Length + 1];
            Array.Fill(dp, -1);
        }
        if(index >= houses.Length) return 0;
        if(dp[index] != -1) return dp[index];

        dp[index] = Math.Max(houses[index] + Rob(houses, index+2), Rob(houses, index+1));
        return dp[index];
    }
}