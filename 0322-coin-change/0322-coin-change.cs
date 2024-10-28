public class Solution {
    Dictionary<int, int> memo = new();
    public int CoinChange(int[] coins, int amount) {
        var ans = GetChange(coins, amount);
        return ans == int.MaxValue ? -1 : ans;
    }

    int GetChange(int[] coins, int amount){
        if(amount < 0) return -1;
        if(amount == 0) return 0;
        if(memo.ContainsKey(amount)) return memo[amount];
        int ans = int.MaxValue;
        foreach(var coin in coins){
            if(amount - coin < 0) continue;
            var res = GetChange(coins, amount - coin);
            if(res != -1 && res != int.MaxValue){
                res += 1;
                ans = Math.Min(ans, res);
            }
        }
        return memo[amount] = ans;
    }
}