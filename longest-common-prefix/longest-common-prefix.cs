public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if(strs.Length == 0) return "";
        if(strs.Length == 1) return strs[0];
        
        var minLen = strs.Min(x=>x.Length);
        if(minLen == 0) return "";
        
        var count = 0;
        while(count < minLen){
            var ch = strs[0][count];
            foreach(string s in strs){
                if(s[count] != ch){
                    return s.Substring(0, count);
                }
            }
            count++;
        }
        return strs[0].Substring(0, count);
    }
}