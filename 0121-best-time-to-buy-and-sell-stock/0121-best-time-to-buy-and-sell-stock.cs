public class Solution {
    public int MaxProfit(int[] prices) {
        //[7,1,5,3,6,4]
        //find max on right
        //[7,6,6,6,6,4]
        var n = prices.Length;
        var maxOnRight = new int[n];
        maxOnRight[n - 1] = prices[n - 1];
        n -= 2;
        while(n >= 0){
            maxOnRight[n] = Math.Max(prices[n], maxOnRight[n+1]);
            n--;
        }
        var maxProfit = 0;
        for(int i = 0; i < prices.Length; i++){
            maxProfit = Math.Max(maxProfit, maxOnRight[i] - prices[i]);
        }

        return maxProfit;
    }
}