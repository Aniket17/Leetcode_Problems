public class Solution {
    public bool IsAnagram(string s, string t) {
        var map = new int[26];
        foreach(var ch in s){
            map[ch - 'a']++;
        }
        foreach(var ch in t){
            map[ch - 'a']--;
        }
        return !map.Any(x=>x!=0);
    }
}