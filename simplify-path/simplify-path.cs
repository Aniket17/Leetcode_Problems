public class Solution {
    public string SimplifyPath(string path) {
        var stack = new Stack<string>();
        var dirs = path.Split("/");
        
        foreach(var dir in dirs){
            if(dir == "." || dir.Length == 0){
                continue;
            }
            if(dir == ".."){
                if(stack.Count != 0)
                    stack.Pop();
            }else{
                stack.Push(dir);
            }
        }
        var ans = new StringBuilder();
        foreach(var dir in stack.Reverse()){
            ans.Append('/');
            ans.Append(dir);
        }
        return ans.Length > 0 ? ans.ToString() : "/" ;
    }
}

/*
'/' when stack is empty skip
'/' when stack.Peek() == '/' skip
'.' count rest dots till '/', if more than 2 push all
if count == 1 skip, if count = 2 increment counter
push if(count == 0)

*/