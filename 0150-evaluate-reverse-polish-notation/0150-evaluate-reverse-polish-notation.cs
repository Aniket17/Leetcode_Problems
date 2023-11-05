public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<string>();
        var ops = new HashSet<string>(){"+", "-", "*", "/"};
        foreach(var token in tokens){
            if(ops.Contains(token)){
                var num2 = Convert.ToInt32(stack.Pop());
                var num1 = Convert.ToInt32(stack.Pop());
                var ans = "";
                switch(token){
                    case "+":
                        ans = (num1+num2).ToString();
                        break;
                    case "-":
                        ans = (num1-num2).ToString();
                        break;
                    case "*":
                        ans = (num1*num2).ToString();
                        break;
                    case "/":
                        ans = (num1/num2).ToString();
                        break;
                }
                stack.Push(ans);
            }else{
                stack.Push(token);
            }
        }
        return Convert.ToInt32(stack.Pop());
    }
}