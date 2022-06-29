public class Solution {
    
    // find max till now array
    // choose the max
    // [7,1,5,3,6,4]
    // [7,6,6,6,6,4]
    // [7,6,4,3,1]
    // [7,6,4,3,1]
    
    
    public int MaxProfit(int[] prices) {
        var n = prices.Length;
        var nextMaxPrice = new int[n];
        nextMaxPrice[n-1] = prices[n-1];
        
        for(int i = n - 2; i >= 0; i--){
            nextMaxPrice[i] = Math.Max(prices[i], nextMaxPrice[i + 1]);
        }
        var maxProfit = 0;
        for(int i = 0; i < n; i++){
            maxProfit = Math.Max(maxProfit, nextMaxPrice[i] - prices[i]);
        }
        
        return maxProfit;
    }
}