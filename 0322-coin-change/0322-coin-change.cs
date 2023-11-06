public class Solution {
    Dictionary<int, int> memo = new();
    public int CoinChange(int[] coins, int amount) {
        var ans = GetChange(coins, amount);
        return ans == int.MaxValue ? -1 : ans;
    }

    int GetChange(int[] coins, int amount){
        if(amount < 0) return -1; //dont have EXACT change
        if(amount == 0) return 0; //cool, got exact change
        if(memo.ContainsKey(amount)) return memo[amount];
        var ans = int.MaxValue;
        for(int i = 0; i < coins.Length; i++){
            if(coins[i] > amount) continue;
            var subAns = GetChange(coins, amount - coins[i]);
            if(subAns != -1 && subAns != int.MaxValue){
                subAns += 1;
                ans = Math.Min(subAns, ans);
            }
        }
        return memo[amount] = ans;
    }
}