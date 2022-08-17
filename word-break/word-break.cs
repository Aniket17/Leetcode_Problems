public class Solution {
    Dictionary<string, bool> memo = new Dictionary<string, bool>();
    public bool WordBreak(string s, IList<string> words) {
        if(s == "") return true;
        foreach(var w in words){
            int wIndex = s.IndexOf(w);
            if(wIndex < 0) continue;
            var part1 = s.Substring(0, wIndex);
            if(!memo.ContainsKey(part1)){
                memo[part1] = WordBreak(part1, words);
            }
            var part2 = s.Substring(wIndex+w.Length);
            if(!memo.ContainsKey(part2)){
                memo[part2] = WordBreak(part2, words);
            }
            if(memo[part1] && memo[part2]) return true;
        }
        return false;
    }
}