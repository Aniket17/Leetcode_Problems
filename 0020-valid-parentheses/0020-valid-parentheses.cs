public class Solution {
    public bool IsValid(string s) {
        var map = new Dictionary<char, char>();
        map.Add('(', ')');
        map.Add('{', '}');
        map.Add('[', ']');
        var stack = new Stack<char>();
        foreach(var ch in s){
            if(map.ContainsKey(ch)){
                stack.Push(ch);
            }else{
                if(stack.Count == 0) return false;
                if(map[stack.Pop()] != ch) return false;
            }
        }
        return stack.Count == 0;
    }
}