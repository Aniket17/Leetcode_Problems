public class Solution {
    List<string> answer = new();
    public IList<string> GenerateParenthesis(int N) {
        //number of open == number of closed
        //open > closed, add closed
        //open == closed add open
        //open should always be >= closed
        //start with open
        //track number of open
        //start with n = 2*n, number of open = 0
        //reduce n and increase number of open
        //backtrack
        //when N == 0 exit
        GenerateParenthesis(N, 0, 0, "");
        return answer;
    }
    void GenerateParenthesis(int n, int open, int close, string res) {
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