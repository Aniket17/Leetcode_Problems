public class Solution {
    public int CharacterReplacement(string s, int k) {
        var map = new int[26];
        int maxFreq = 0, left=0, right=0;
        var result = 0;
        while(left <= right && right < s.Length){
            var len = right - left + 1;
            var ch = s[right];
            map[ch-'A']++;
            maxFreq = Math.Max(maxFreq, map[ch-'A']);
            if(len - maxFreq <= k){
                //valid window
                result = Math.Max(result, len);
            }else{
                map[s[left]-'A']--;
                left++;
            }
            right++;
        }
        return result;
    }
}