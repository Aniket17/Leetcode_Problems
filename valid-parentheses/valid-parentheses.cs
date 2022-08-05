public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        Dictionary<char, char> map = new();
        map.Add('(',')');
        map.Add('[',']');
        map.Add('{','}');
        foreach(var ch in s){
            if(map.ContainsKey(ch)){
                stack.Push(ch);
            }else{
                if(stack.Count == 0 || map[stack.Peek()] != ch) return false;
                stack.Pop();
            }
        }
        return stack.Count == 0;
    }
}

/*
"([]){([])}"
stack - 
*/