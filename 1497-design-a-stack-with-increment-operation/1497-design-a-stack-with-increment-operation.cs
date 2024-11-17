public class CustomStack {
    int[] items;
    int top = -1;
    public CustomStack(int maxSize) {
        items = new int[maxSize];
    }
    
    public void Push(int x) {
        if(top == items.Length - 1){
            return;
        }
        top++;
        items[top] = x;
    }
    
    public int Pop() {
        if(top == -1) return -1;
        return items[top--];
    }
    
    public void Increment(int k, int val) {
        for(int i = 0; i < Math.Min(k, top+1); i++){
            items[i] += val;
        }
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */