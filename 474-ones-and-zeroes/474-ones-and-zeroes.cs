public class Solution {
    Dictionary<string, int> memo = new Dictionary<string, int>();
    public int FindMaxForm(string[] strs, int m, int n) {
        return FindMax(strs, 0, m, n);
    }
    
    int FindMax(string[] strs, int pos, int m , int n){
        if(pos >= strs.Length) return 0;
        
        var key = $"{pos},{m},{n}";
        if(memo.ContainsKey(key)) return memo[key];
        var zeros = strs[pos].Where(x=>x=='0').Count();
        var ones = strs[pos].Length - zeros;
        //take
        var take = 0;
        if(zeros <= m && ones <= n){
            take = 1 + FindMax(strs, pos+1, m-zeros, n-ones);
        }
        //dont take
        var dontTake = FindMax(strs, pos+1, m, n);
        return memo[key] = Math.Max(take, dontTake);
    }
}