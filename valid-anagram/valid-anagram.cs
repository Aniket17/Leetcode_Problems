public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) return false;
        var map = new Dictionary<char, int>();
        foreach(var ch in s) map[ch] = 1 + map.GetValueOrDefault(ch);
        foreach(var ch in t){
            if(!map.ContainsKey(ch)) return false;
            map[ch]--;
            if(map[ch] < 0) return false;
        }
        return true;
    }
}