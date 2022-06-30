/*
"abcabcbb"
"pwwkew"
i  j  char  map
0  1   p,w  [p: 0, w: 1]
0  2   p,w  [p: 0, w: 2]
2  3   w,k  [p: 0, w: 2, k:3]
2  4   p,w  [p: 0, w: 2, k:3, e:4]
2  5   p,w  [p: 0, w: 2, k:3, e:4]

*/
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(string.IsNullOrEmpty(s)) return 0;
        var map = new Dictionary<char, int>();
        var longest = 0;
        var current = 0;
        for(int i = 0, j = 0; j < s.Length; j++){
            if(map.ContainsKey(s[j]) && map[s[j]] >= i){
                //found a repeat
                current = j - i;
                i = map[s[j]] + 1;
                if(i == j) current = 1;
            }else{
                current = j - i + 1;
            }
            map[s[j]] = j;
            longest = Math.Max(longest, current);
        }
        return longest;
    }
}