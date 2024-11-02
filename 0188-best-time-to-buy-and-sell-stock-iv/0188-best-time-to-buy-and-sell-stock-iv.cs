public class Solution {
    Dictionary<(int, int, bool), int> dp = new();
    public int MaxProfit(int k, int[] prices) {
        return MaxProfitUtil(prices, k, 0, false);
    }
    int MaxProfitUtil(int[] prices, int remain, int index, bool holding){
        if(index == prices.Length || remain == 0) return 0;
        if(dp.ContainsKey((index, remain, holding))) return dp[(index, remain, holding)];

        var profit = 0;
        var doNothing = MaxProfitUtil(prices, remain, index+1, holding); //do nothing
        if(holding){
            //choose to sell or do nothing
            var sell = prices[index] + MaxProfitUtil(prices, remain - 1, index+1, false); //sell
            profit = Math.Max(doNothing, sell);
        }else{
            //buy or do nothing
            var buy = -prices[index] + MaxProfitUtil(prices, remain, index+1, true); //sell
            profit = Math.Max(doNothing, buy);
        }
        return dp[(index, remain, holding)] = profit;
    }
}