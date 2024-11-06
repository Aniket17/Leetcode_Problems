public class Solution {
    int[] dp;
    int minCoins = int.MaxValue;
    public int CoinChange(int[] coins, int amount) {
        //amount < 0 return -1
        //dp(amount) = 1 + dp(amount - coin);
        dp = new int[amount + 1];
        Array.Fill(dp, -1);
        var result = CoinChangeUtil(coins, amount);
        return result == int.MaxValue ? -1 : result;
    }

    int CoinChangeUtil(int[] coins, int amount){
        if(amount < 0) return int.MaxValue;
        if(amount == 0){
            return 0;
        }
        if(dp[amount] != -1) return dp[amount];
        var ans = int.MaxValue;
        foreach(var coin in coins){
            if(coin > amount) continue;
            var res = CoinChangeUtil(coins, amount - coin);
            if(res != int.MaxValue){
                res++;
                ans = Math.Min(res, ans);
            }
        }
        return dp[amount] = ans;
    }
}