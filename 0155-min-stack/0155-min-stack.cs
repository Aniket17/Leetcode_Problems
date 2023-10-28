public class StackItem{
    public int Value {get; set;}
    public int MinSoFar {get; set;}

    public StackItem(int val, int minSoFar){
        Value = val;
        MinSoFar = minSoFar;
    }
}

public class MinStack {
    private Stack<StackItem> _stack;
    public MinStack() {
        _stack = new();
    }
    
    public void Push(int val) {
        if(_stack.Count() == 0){
            _stack.Push(new StackItem(val, val));
        }else{
            var top = _stack.Peek();
            _stack.Push(new StackItem(val, Math.Min(val, top.MinSoFar)));
        }
    }
    
    public void Pop() {
        _stack.Pop();
    }
    
    public int Top() {
        return _stack.Peek().Value;
    }
    
    public int GetMin() {
        return _stack.Peek().MinSoFar;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */