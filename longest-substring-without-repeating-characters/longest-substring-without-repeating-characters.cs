public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length <= 1) return s.Length;
        Dictionary<char, int> map = new();
        int max = 0;
        for(int i = 0, j = 0; j < s.Length; j++){
            if(!map.ContainsKey(s[j])){
                map[s[j]] = j;
            }else{
                var ind = map[s[j]];
                if(ind >= i){
                    i = ind+1;
                }
                map[s[j]] = j;
            }
            max = Math.Max(j - i + 1, max);
        }
        return max;
    }
}
/*
pwwkew
call i j count max
0    0 0 1
1    0 1 2
2.   0 2 0
3.   2 2 1
4    2 3.2
5.   2 4 3
6.   2 5 3
7.   
*/