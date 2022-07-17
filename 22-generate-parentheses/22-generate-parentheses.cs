public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        //count of open should always be greater
        var ans = new List<string>();
        Generate(n, 0, 0, "", ans);
        return ans;
    }
    
    private void Generate(int n, int open, int closed, string str, List<string> ans){
        if(str.Length == n*2){
            ans.Add(str);
            return;
        }
        if(open < n){
            Generate(n, open + 1, closed, str+"(", ans);
        }
        if(closed < n && closed < open){
            Generate(n, open, closed + 1, str+")", ans);
        }
    }
}