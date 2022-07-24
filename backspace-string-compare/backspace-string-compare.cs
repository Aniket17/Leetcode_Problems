public class Solution {
    public bool BackspaceCompare(string s, string t) {
        var stack = new Stack<char>();
        foreach(var ch in s){
            if(ch == '#'){
                if(stack.Count > 0){
                    stack.Pop();
                }
            }else{
                stack.Push(ch);
            }
        }
        s = new String(stack.Select(x=>x).ToArray());
        stack = new Stack<char>();
        foreach(var ch in t){
            if(ch == '#'){
                if(stack.Count > 0){
                    stack.Pop();
                }
            }else{
                stack.Push(ch);
            }
        }
        t = new String(stack.Select(x=>x).ToArray());
        return s == t;
    }
}