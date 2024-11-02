public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        int n = s.Length, i = 0, j = 0;
        if(s.Length < 3) return s.Length;
        Dictionary<char, int> windowChars = new();
        var len = 0;
        while(j < n){
            var ch = s[j];
            windowChars[ch] = windowChars.GetValueOrDefault(ch) + 1;
            while(windowChars.Keys.Count > 2){
                //minimize the window
                windowChars[s[i]]--;
                if(windowChars[s[i]] == 0){
                    windowChars.Remove(s[i]);
                }
                i++;
            }
            len = Math.Max(len, j - i + 1);
            j++;
        }
        return len;
    }
}