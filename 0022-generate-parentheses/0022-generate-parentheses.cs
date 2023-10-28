public class Solution {
    IList<string> answer = new List<string>();
    public IList<string> GenerateParenthesis(int n) {
        GenerateParenthesis(n, 0, 0, "");
        return answer;
    }

    public void GenerateParenthesis(int n, int open, int close, string res) {
        if(res.Length == n * 2) {
            answer.Add(res);
            return;
        }
        if(open < n){
            GenerateParenthesis(n, open+1, close, res+"(");
            if(close < open){
                GenerateParenthesis(n, open, close+1, res+")");
            }
        }else if(open == close){
            GenerateParenthesis(n, open+1, close, res+"(");
        }
        else if(close < n){
            GenerateParenthesis(n, open, close+1, res+")");
        }
    }
}