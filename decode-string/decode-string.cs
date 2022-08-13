public class Solution {
    public string DecodeString(string s)
    {
        if (String.IsNullOrEmpty(s)) return s;
        
        Stack<char> stack = new Stack<char>();
        
        foreach(char c in s){
            if(c != ']'){
                stack.Push(c);
            }else{
                var curr = new StringBuilder();
                while(stack.Peek() != '['){
                    curr.Append(stack.Pop());
                }
                stack.Pop();
                var rep = 0;
                var repCount = 0;
                while(stack.Count > 0 && Char.IsDigit(stack.Peek())){
                    rep += (int)(stack.Pop() - '0') * (int)Math.Pow(10, repCount++);
                }
                var str = curr.ToString();
                while(rep-- > 0){
                    for(int i = str.Length - 1; i >= 0; i--){
                        stack.Push(str[i]);
                    }
                }
            }
        }
        var sb = new StringBuilder();
        var cnt = stack.Count - 1;
        while(stack.Count > 0){
            var c = stack.Pop();
            sb.Append(c);
        }
        return new String(sb.ToString().Reverse().ToArray());
    }
}