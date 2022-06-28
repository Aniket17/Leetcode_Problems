public class MyStack {
    int[] list;
    int top;
    public MyStack() {
        list = new int[100];
        top = -1;
    }
    
    public void Push(int x) {
        top++;
        list[top] = x;
    }
    
    public int Pop() {
        if(top == -1) throw new System.Exception("Empty stack");
        var topElement = list[top--];
        return topElement;
    }
    
    public int Top() {
        if(top == -1) throw new System.Exception("Empty stack");
        return list[top];
    }
    
    public bool Empty() {
        return top == -1;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 
 [1]
 */