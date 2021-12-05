public class Solution {
    public int LongestValidParentheses(string s) {
        var stack = new Stack<int>();
        int i = 0;
        int maxCount = 0;
        stack.Push(-1);
        while(i < s.Length){
            if(s[i] == '('){
                stack.Push(i);
            }else{
                stack.Pop();
                if (stack.Count == 0) {
                    stack.Push(i);
                } else {
                    maxCount = Math.Max(maxCount, i - stack.Peek());
                }
            }
            i++;
        }
        return maxCount;
    }
}
