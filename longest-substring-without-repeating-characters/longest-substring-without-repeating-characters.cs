public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(String.IsNullOrEmpty(s)) return 0;
        int max = 0;
        int current = 0;
        var map = new HashSet<char>(); //b,c,a
        var indices = new int[128];
        for(int i = 0, j = 0; j < s.Length; j++){
            
            if(map.Contains(s[j]) && indices[s[j]] >= i){
                //found repeat
                current = j - i;
                i = indices[s[j]] + 1;
                if(i == j) current = 1;
            }else{
                map.Add(s[j]);
                current = j - i + 1;
            }
            indices[s[j]] = j;
            max = Math.Max(current, max);
        }
        return max;
    }
}

/*
"ckilbkd"
"0123456"
current max 

*/
    