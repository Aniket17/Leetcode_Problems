public class Solution {
    public bool IsValid(string s) {
        var map = new Dictionary<char, char>();
        map.Add('(', ')');
        map.Add('{', '}');
        map.Add('[', ']');
        var stack = new Stack<char>();
        foreach(var c in s){
            if(map.ContainsKey(c)){
                //opening bracket
                stack.Push(c);
            }else{
                //closing one
                if(stack.Count == 0){
                    return false;
                }
                var opening = stack.Pop();
                if(map[opening] != c){
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}


//((([]{()})))