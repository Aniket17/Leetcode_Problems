public class StockSpanner {

    List<int> prices;
    public StockSpanner() {
        prices = new List<int>();
    }
    
    public int Next(int price) {
        prices.Add(price);
        var count = 0;
        for(int i = prices.Count - 1; i >= 0; i--){
            if(prices[i] <= price) count++;
            else break;
        }
        return count;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */