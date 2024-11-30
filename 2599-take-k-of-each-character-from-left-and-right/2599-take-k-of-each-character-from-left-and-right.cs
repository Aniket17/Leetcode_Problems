public class Solution {
    public int TakeCharacters(string s, int k) {
        int n = s.Length;

        // Step 1: Count total occurrences of 'a', 'b', and 'c'
        int[] total = new int[3];
        foreach (char c in s) {
            total[c - 'a']++;
        }

        // If any character occurs less than k times, return -1
        if (total[0] < k || total[1] < k || total[2] < k) return -1;

        // Step 2: Sliding window to find the smallest substring containing at least (total[x] - k) of each character
        int[] count = new int[3];
        int left = 0, minWindow = 0;

        for (int right = 0; right < n; right++) {
            count[s[right] - 'a']++;

            // While the current window contains more than (total[x] - k) of each character
            while (left <= right && (count[0] > total[0] - k ||
                   count[1] > total[1] - k ||
                   count[2] > total[2] - k)) {
                count[s[left] - 'a']--;
                left++;
            }
            minWindow = Math.Max(minWindow, right - left + 1);
        }

        // Step 3: Calculate the minimum number of minutes
        return n - minWindow;
    }
}