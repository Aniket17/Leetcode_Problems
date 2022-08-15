public class Solution {
    public int MaxProfit(int[] prices) {
        var nextMax = GetNextMax(prices);
        var maxProfit = 0;
        for(int i = 0; i < prices.Length; i++){
            maxProfit = Math.Max(maxProfit, nextMax[i] - prices[i]);
        }
        return maxProfit;
    }
    
    int[] GetNextMax(int[] prices){
        var result = new int[prices.Length];
        result[prices.Length - 1] = prices[prices.Length - 1];
        for(int i = prices.Length - 2; i >= 0; i--){
            result[i] = Math.Max(prices[i], result[i+1]);
        }
        return result;
    }
}

/*
[7,1,5,3,6,4]
[7,6,6,6,6,4]
*/