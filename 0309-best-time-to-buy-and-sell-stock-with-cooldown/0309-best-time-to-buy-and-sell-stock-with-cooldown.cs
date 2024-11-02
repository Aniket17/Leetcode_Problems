public class Solution {
    Dictionary<(int, bool), int> dp = new();
    public int MaxProfit(int[] prices) {
        return MaxProfitUtil(prices, 0, false);
    }
    int MaxProfitUtil(int[] prices, int index, bool holding){
        if(index >= prices.Length) return 0;
        if(dp.ContainsKey((index, holding))) return dp[(index, holding)];

        var doNothing = MaxProfitUtil(prices, index + 1, holding);
        var profit = 0;
        if(holding){
            //sell
            profit = Math.Max(doNothing, prices[index] + MaxProfitUtil(prices, index + 2, false));
        }else{
            //buy
            profit = Math.Max(doNothing, -prices[index] + MaxProfitUtil(prices, index + 1, true));
        }
        return dp[(index, holding)] = profit;
    }
}