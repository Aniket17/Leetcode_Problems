public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var ans = new List<string>();
        Generate(n, 0, 0, "", ans);
        return ans;
    }

    void Generate(int n, int open, int close, string curr, List<string> ans){
        if(open == n && close == n){
            ans.Add(curr);
            return;
        }
        if(open < n){
            Generate(n, open + 1, close, curr+"(", ans);
            if(open > close){
                Generate(n, open, close + 1, curr + ")", ans);
            }
        }else if(open == close){
            Generate(n, open + 1, close, curr+"(", ans);
        }else if(close < n){
            Generate(n, open, close + 1, curr+")", ans);
        }
    }
}