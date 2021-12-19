public class Solution {
    public int StrStr(string haystack, string needle) {
        if(string.IsNullOrEmpty(needle)) return 0;
        if(string.IsNullOrEmpty(haystack)) return -1;
        
        int nextIndex = GetNextIndex(haystack, needle, start: 0);
        int j = 0;
        
        while(true){
            if(nextIndex >= haystack.Length){ return -1; }
            
            var index = nextIndex;
            var i = nextIndex;

            while(i < haystack.Length && j < needle.Length && needle[j] == haystack[i]){
                i++;
                j++;
            }
            if(j == needle.Length){
                return index;
            }
            nextIndex = GetNextIndex(haystack, needle, start: index + 1);
            j = 0;
        }
        return -1;
    }
    
    private int GetNextIndex(string haystack, string needle, int start){
        while(start < haystack.Length && needle[0] != haystack[start]){
            start++;
        }
        return start;
    }
}