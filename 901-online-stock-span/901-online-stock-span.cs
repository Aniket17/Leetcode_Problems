public class StockSpanner {
    Stack<(int price, int span)> stack= new Stack<(int price, int span)>();
    public StockSpanner() {
    }
    
    public int Next(int price) {
       int span =1;
        while(stack.Count!=0 && price>=stack.Peek().price){
            span +=stack.Peek().span;
            stack.Pop();
        }
        stack.Push((price,span));
        return span;
    }
}
/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */