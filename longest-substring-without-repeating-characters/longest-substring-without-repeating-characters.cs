public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length == 0) return 0;
        Dictionary<char, int> map = new Dictionary<char, int>();
        var max = 0;
        var current = 0;
        for(int i = 0, j = 0; j < s.Length; j++){
            if(map.ContainsKey(s[j]) && map[s[j]] >= i){
                // found repeat
                // move i to map[s[j]]
                // calculate the max
                // update map[s[j]]
                current = j - i;
                i = map[s[j]] + 1;
                if(i == j) current = 1;
            }else{
                current = j - i + 1;
            }
            map[s[j]] = j;
            max = Math.Max(max, current);
        }
        
        return max;
    }
}

/*
"ckilbkd"
"0123456"

i   j   map                     max
0   4   c:0 k:1 i:2 l:3 b:4

1   5   c:0 k:5 i:2 l:3 b:4      5

1   6   c:0 k:5 i:2 l:3 b:4 d:6     

*/
    