public class Solution {
    int[] memo;
    public int CoinChange(int[] coins, int amount) {
        var n = coins.Length;
        memo = new int[amount+1];
        Array.Fill(memo, -1);
        var res = Solve(coins, amount);
        return res == int.MaxValue ? -1 : res;
    }
    
    int Solve(int[] coins, int amount){
        var n = coins.Length;
        if(amount < 0) return int.MaxValue;
        if(amount == 0) return 0;
        if(memo[amount] != -1) return memo[amount];
        
        var minCoins = int.MaxValue;
        for(int i = 0; i < n; i++){
            if(coins[i] > amount) continue;
            var res = Solve(coins, amount - coins[i]);
            if(res != int.MaxValue){
                minCoins = Math.Min(minCoins, 1+res);
            }
        }
        return memo[amount] = minCoins;
    }
}