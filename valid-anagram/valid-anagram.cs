public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) return false;
        var map = new int[256];
        foreach(var ch in s) map[ch] = 1 + map[ch];
        foreach(var ch in t){
            map[ch]--;
            if(map[ch] < 0) return false;
        }
        return true;
    }
}