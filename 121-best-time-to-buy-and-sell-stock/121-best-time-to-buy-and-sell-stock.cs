public class Solution {
    public int MaxProfit(int[] prices) {
        var minSoFar = int.MaxValue;
        var maxProfit = 0;
        for(int i = 0; i < prices.Length; i++){
            if(prices[i] < minSoFar){
                minSoFar = prices[i];
            }else{
                maxProfit = Math.Max(maxProfit, prices[i] - minSoFar);
            }
        }
        return maxProfit;
    }
}