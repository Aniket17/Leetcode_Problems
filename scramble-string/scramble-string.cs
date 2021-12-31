public class Solution {
    Dictionary<string, bool> memo;
    public bool IsScramble(string s1, string s2) {
        memo = new Dictionary<string, bool>();
        return Solve(s1, s2);
    }
    
    bool Solve(string s1, string s2){
        if(s1.Length == 1){
            return s1 == s2;
        }
        if(s1 == s2) return true;
        var n = s1.Length;
        
        var key = string.Join("*", s1, s2);
        if(memo.ContainsKey(key)) return memo[key];
        
        for(int i = 1; i < s1.Length; i++){
            
            var ans = (Solve(s1.Substring(0, i), s2.Substring(0, i)) && Solve(s1.Substring(i), s2.Substring(i))) 
                || 
                (Solve(s1.Substring(0, i), s2.Substring(n-i)) && Solve(s1.Substring(i), s2.Substring(0, n-i)));
            if(ans) return memo[key] = true;
        }
        return memo[key] = false;
    }
}