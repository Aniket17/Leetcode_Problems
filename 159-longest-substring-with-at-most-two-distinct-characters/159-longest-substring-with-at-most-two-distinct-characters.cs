public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        int n = s.Length;
        if (n < 3) return n;

        // sliding window left and right pointers
        int left = 0;
        int right = 0;
        // hashmap character -> its rightmost position
        // in the sliding window
        Dictionary<char, int> map = new();

        int maxLen = 2;

        while (right < n) {
          // when the slidewindow contains less than 3 characters
          map[s[right]] = right++;

          // slidewindow contains 3 characters
          if (map.Count == 3) {
            // delete the leftmost character
            int delIndex = map.Select(x=>x.Value).Min(x=>x);
            map.Remove(s[delIndex]);
            // move left pointer of the slidewindow
            left = delIndex + 1;
          }

          maxLen = Math.Max(maxLen, right - left);
        }
        return maxLen;
    }
}