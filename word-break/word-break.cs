public class Solution {
    
    Dictionary<string, bool> memo = new Dictionary<string, bool>();
    
    public bool WordBreak(string s, IList<string> wordDict) {
        if(s.Length == 0) return true;
        
        foreach(var w in wordDict){
            var index = s.IndexOf(w);
            
            if(index < 0) continue;
            
            var firstPart = s.Substring(0, index);
            var secondPart = s.Substring(index + w.Length);
            
            if(!memo.ContainsKey(firstPart)){
                memo[firstPart] = WordBreak(firstPart, wordDict);
            }
            
            if(!memo.ContainsKey(secondPart)){
                memo[secondPart] = WordBreak(secondPart, wordDict);
            }
            
            if(memo[firstPart] && memo[secondPart]){
                return true;
            }
        }
        return false;
    }
}