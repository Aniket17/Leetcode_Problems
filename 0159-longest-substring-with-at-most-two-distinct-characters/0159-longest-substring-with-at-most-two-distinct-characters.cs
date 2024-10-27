public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        var map = new Dictionary<char, int>();
        int i = 0, j = 0, maxLen = 0;
        while(j < s.Length){
            var ch = s[j];
            map[ch] = map.GetValueOrDefault(ch) + 1;
            while(map.Keys.Count > 2){
                //reduce by moving i
                map[s[i]]--;
                if(map[s[i]] == 0){
                    map.Remove(s[i]);
                }
                i++;
            }

            //calculate
            maxLen = Math.Max(maxLen, j - i + 1);
            j++;
        }
        return maxLen;
    }
}