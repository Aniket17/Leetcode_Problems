public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        int cash = 0, hold = -prices[0];
        for (int i = 1; i < prices.Length; i++) {
            cash = Math.Max(cash, hold + prices[i] - fee);
            hold = Math.Max(hold, cash - prices[i]);
        }
        return cash;
    }
}

/*
[1,3,2,8,4,9], fee = 2
[
{9,6},
{8,3},
{4,4},
{3,1},
{2,2},
{1,0},
]

8-2=6
8-1=5 + 9-4=3 => 8
*/