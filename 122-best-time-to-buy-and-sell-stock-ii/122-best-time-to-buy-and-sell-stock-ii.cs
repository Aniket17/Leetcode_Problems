public class Solution {
    public int MaxProfit(int[] prices) {
        int total = 0;
        int valey = int.MaxValue;
        int peak = valey;
        
        for(int i = 0; i < prices.Length; i++){
            if(prices[i] < peak){
                total += peak - valey;
                valey = prices[i];
                peak = prices[i];
            }else{
                peak = prices[i];
            }
        }
        total += peak-valey;
        return total;
    }
}