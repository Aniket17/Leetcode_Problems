public class Solution {
    Dictionary<string, IList<string>> memo = new();
    List<string> ans;
    public IList<string> WordBreak(string s, IList<string> words) {
        ans = new();
        CanBreak(s, words, new List<string>(), -1);
        return ans;
    }
    
    public void CanBreak(string s, IList<string> words, List<string> curr, int lastInserted) {
        if(s == ""){
            ans.Add(string.Join(" ", curr));
            return;
        }
        foreach(var w in words){
            int wIndex = s.IndexOf(w);
            if(wIndex < 0) continue;
            if(wIndex < lastInserted) continue;
            var part1 = s.Substring(0, wIndex);
            var part2 = s.Substring(wIndex+w.Length);
            var newS = part1+part2;
            curr.Add(w);
            CanBreak(newS, words, curr, wIndex);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}