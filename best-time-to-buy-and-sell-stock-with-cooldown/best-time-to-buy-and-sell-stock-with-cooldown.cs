public class Solution {
    public int MaxProfit(int[] prices) {
        int sold = int.MinValue, held = int.MinValue, reset = 0;

        foreach (int price in prices) {
          int preSold = sold;

          sold = held + price;
          held = Math.Max(held, reset - price);
          reset = Math.Max(reset, preSold);
        }

        return Math.Max(sold, reset);
    }
}

/*
 [1,2,3,0,2]
*/