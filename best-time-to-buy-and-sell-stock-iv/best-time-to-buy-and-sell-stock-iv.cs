public class Solution {
    int[,,] memo;
    public int MaxProfit(int k, int[] prices) {
        int n = prices.Length;
        memo = new int[n+1, k+1, 2];

        return Solve(prices, 0, k, 0);
    }
    int Solve(int[] prices, int pos, int k, int holding){
        // is holding -> sell and move next or dont sell and move next
        // not holding -> hold and move next or move next
        if(memo[pos, k, holding] != 0) return memo[pos, k, holding];
        if(k == 0 || pos >= prices.Length) return 0;
        int res = 0;
        var doNothing = Solve(prices, pos+1, k, holding);
        if(holding == 1){
            res = prices[pos] + Solve(prices, pos+1, k-1, 0);
        }else{
            res = -prices[pos] + Solve(prices, pos+1, k, 1);
        }
        
        return memo[pos, k, holding] = Math.Max(doNothing, res);
    }
}