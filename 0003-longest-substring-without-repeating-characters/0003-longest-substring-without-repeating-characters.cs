public class Solution {
    public int LengthOfLongestSubstring(string s) {
        //brute force
        //find every substring in n^2 time and check which has repeats
        //use two pointer approach
        //use i and j to track current substring
        //maintain a hashset to track current characters
        //move j until we find a char which is repeated
        //calculate len as j-i+1
        //move i until that repeat char is found
        //move i one step further from first occurance of repeat char
        //remove the char from the hashset
        //do this till j < s.Length

        int n = s.Length, i = 0, j = 0, maxLen = 0, currLen = 0;
        var seen = new HashSet<char>();
        while(j < n){
            var ch = s[j];
            if(seen.Contains(ch)){
                while(i <= j && s[i] != ch){
                    seen.Remove(s[i]);
                    i++;
                }
                i++; //move one step further   
            }
            seen.Add(ch);
            currLen = j - i + 1;
            maxLen = Math.Max(maxLen, currLen);
            j++;
        }
        return maxLen;
    }
}