import java.util.HashMap;

class Solution {
    public String minWindow(String s, String t) {
        if (s.length() == 0 || t.length() == 0) {
            return "";
        }

        // Frequency map for characters in t
        HashMap<Character, Integer> map = new HashMap<>();
        for (int i = 0; i < t.length(); i++) {
            map.put(t.charAt(i), map.getOrDefault(t.charAt(i), 0) + 1);
        }

        int left = 0;
        int right = 0;
        int requiredMatches = map.size();  // Number of unique characters to match
        int currentMatches = 0;  // Track how many unique characters we have matched
        String ans = "";
        int minLength = Integer.MAX_VALUE;  // Track the minimum window length

        // Frequency map for characters in the current window
        HashMap<Character, Integer> windowCounts = new HashMap<>();

        while (right < s.length()) {
            char currentChar = s.charAt(right);
            if (map.containsKey(currentChar)) {
                windowCounts.put(currentChar, windowCounts.getOrDefault(currentChar, 0) + 1);
                
                // Check if this character's count matches the required count in t
                if (windowCounts.get(currentChar).intValue() == map.get(currentChar).intValue()) {
                    currentMatches++;
                }
            }

            // Try to shrink the window from the left if all characters are matched
            while (currentMatches == requiredMatches) {
                char leftChar = s.charAt(left);

                // Check if the current window is the smallest valid window
                if ((right - left + 1) < minLength) {
                    minLength = right - left + 1;
                    ans = s.substring(left, right + 1);
                }

                // Shrink the window by moving `left` to the right
                if (map.containsKey(leftChar)) {
                    windowCounts.put(leftChar, windowCounts.get(leftChar) - 1);
                    
                    // If the character count goes below the required count, the window is no longer valid
                    if (windowCounts.get(leftChar).intValue() < map.get(leftChar).intValue()) {
                        currentMatches--;
                    }
                }

                left++;  // Move the left pointer to shrink the window
            }

            right++;  // Expand the window by moving the right pointer
        }

        return ans;
    }
}
