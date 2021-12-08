public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        dp[0] = 0;
		for(int i = 1; i< dp.Length; i++) dp[i] = -1;
		
		int ans = minCoins(amount, coins, dp);
        if(ans == int.MaxValue) return -1;
        return ans;
    }
    
    public int minCoins(int amount, int[] coins, int[] dp) {
		
		if(amount == 0) return 0;
		
		int ans = int.MaxValue;
		
		for(int i = 0; i < coins.Length; i++) {
			if(amount - coins[i] >= 0) {
				int subAns = 0;
				if(dp[amount - coins[i]] != -1) {
					subAns = dp[amount - coins[i]];
				} else {
					subAns = minCoins(amount - coins[i], coins, dp);
				}
				if(subAns != int.MaxValue && 
						subAns + 1 < ans) {
					ans = subAns + 1;
				}
			}
		}
		return dp[amount] = ans;
	}
}

/*
[1,2,5], amount = 3


*/