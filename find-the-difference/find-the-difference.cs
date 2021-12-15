public class Solution {
    public char FindTheDifference(string s, string t) {
        if(t.Length == 1) return t[0];
        
        var sMap = new Dictionary<char, int>();
        foreach(var c in s){
            sMap[c] = sMap.GetValueOrDefault(c) + 1;
        }
        foreach(var c in t){
            sMap[c] = sMap.GetValueOrDefault(c) - 1;
            if(sMap[c] < 0){
                return c;
            }
        }
        return t[s.Length];
    }
}