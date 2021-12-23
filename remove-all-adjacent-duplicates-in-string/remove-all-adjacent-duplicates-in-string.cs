public class Solution {
    public string RemoveDuplicates(string s) {
        var stack = new Stack<char>();
        stack.Push(s[0]);
        
        for(int i = 1; i < s.Length; i++){
            var ch = s[i];
            if(stack.Count > 0 && stack.Peek() == ch){
                stack.Pop();
                while(stack.Count > 0){
                    if(stack.Peek() == ch){
                        stack.Pop();
                    }else{
                        break;
                    }
                }
            }else{
                stack.Push(ch);
            }
        }
        return string.Join("", stack.Reverse());
    }
}