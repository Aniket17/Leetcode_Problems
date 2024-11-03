public class Solution {
    Dictionary<(int, bool), int> dp = new();
    public int MaxProfit(int[] prices, int fee) {
        //three states, buy, sell, doNothing
        return MaxProfitUtil(prices, fee, 0, false);
    }

    int MaxProfitUtil(int[] prices, int fee, int index, bool holding){
        if(index >= prices.Length) return 0; //zero profit
        var key = (index, holding);
        if(dp.ContainsKey(key)) return dp[key];
        var doNothing = MaxProfitUtil(prices, fee, index + 1, holding);
        var profit = 0;
        if(holding){
            profit = prices[index] + MaxProfitUtil(prices, fee, index + 1, false) - fee;
        }else{
            profit = -prices[index] + MaxProfitUtil(prices, fee, index + 1, true);
        }
        return dp[key] = Math.Max(doNothing, profit);
    }
}