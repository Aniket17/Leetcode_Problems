public class Solution {
    public int LengthOfLongestSubstring(string s) {
        /*
        //pwwkew
        i   ch   left    right   set  max
        0   p      0       1      [p]  1
        1   w      0       2      [pw] 2
        2   w      2       2      [w]  2
        3   k      2       3      [wk]  2
        4   e      2       4      [wke]  2
        5   w      2       4      [wke]  3

        */
        var set = new HashSet<char>();//[]
        var left = 0; 
        var right = 0;
        var maxLen = 0;
        while(right < s.Length){
            var ch = s[right];
            if(set.Contains(ch)){
                //move left till we find it again
                while(s[left] != ch){
                    set.Remove(s[left++]);
                }
                //left is at repeat char, remove that as well
                set.Remove(ch);
                left++;
            }else{
                //healthy substring, recalc maxLen
                set.Add(ch); 
                right++;
            }
            maxLen = Math.Max(maxLen, set.Count());
        }
        return maxLen;
    }
}