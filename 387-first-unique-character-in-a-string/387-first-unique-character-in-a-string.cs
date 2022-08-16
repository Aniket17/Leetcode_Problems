public class Solution {
    public int FirstUniqChar(string s) {
        int[] counts = new int[26];
        foreach(var ch in s){
            var id = (int)ch - 'a';
            counts[id]++;
        }
        for(int i = 0; i < s.Length; i++){
            var id = (int)s[i] - 'a';
            if(counts[id] == 1){
                return i;
            }
        }
        return -1;
    }
}