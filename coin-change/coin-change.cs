public class Solution {
    int[] memo;
    public int CoinChange(int[] coins, int amount) {
        memo = new int[amount+1];
        var ans = GetChange(coins, amount);
        return ans == int.MaxValue ? -1 : ans;
    }
    
    private int GetChange(int[] coins, int amount){
        if(amount < 0){
            return -1;
        }
        if(amount == 0) return 0;
        if(memo[amount] > 0) return memo[amount];
        int min = int.MaxValue;
        foreach(var coin in coins){
            if(coin > amount) continue;
            var res = GetChange(coins, amount - coin);
            if(res != -1 && res < min){
                min = 1+res;
            }
        }
        return memo[amount] = min;
    }
}