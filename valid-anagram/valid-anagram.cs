public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) return false;
        int[] chars = new int[128];
        foreach(char c in s){
            chars[c]++;
        }
        foreach(char c in t){
            chars[c]--;
        }
        return !chars.Any(x=>x!=0);
    }
}