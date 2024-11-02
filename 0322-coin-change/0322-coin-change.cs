public class Solution {
    Dictionary<int, int> dp;
    public int CoinChange(int[] coins, int amount) {
        dp = new();
        var result = GetChange(coins, amount);
        return result == int.MaxValue ? -1 : result;
    }

    int GetChange(int[] coins, int amount){
        if(amount < 0) return int.MaxValue;
        if(amount == 0){
            return 0;
        }
        if(dp.ContainsKey(amount)) return dp[amount];
        var ans = int.MaxValue;
        foreach(var coin in coins){
            if(coin > amount) continue;
            var res = GetChange(coins, amount - coin);
            if(res != int.MaxValue){
                res++;
                ans = Math.Min(res, ans);
            }
        }
        return dp[amount] = ans;
    }
}