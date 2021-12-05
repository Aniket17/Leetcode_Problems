public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var res = new List<string>();
        if(n<=0) return res;
        Permute(res, n, 0, 0, "");
        return res;
    }
    
    public void Permute(List<string> result, int max, int opening, int closing, string current)     {
        if(current.Length == max * 2){
            result.Add(current);
            return;
        }
        if(opening < max){
            Permute(result, max, opening + 1, closing, current+"(");
        }
        
        if(closing < max && closing < opening){
            Permute(result, max, opening, closing + 1, current+")");
        }
    }
    
}

// valid paranthesis
// should always have more or equa number of '(' than ')'
// should start with '(' and end with ')'