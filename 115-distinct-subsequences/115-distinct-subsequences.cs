public class Solution {
    public int NumDistinct(string s1, string s2) {
        if(s2.Length > s1.Length) return 0;
        if(s1 == s2) return 1;
        var cache = new Dictionary<string, int>();
        var lcsLen = LengthOfLCS(s1, s2, 0, 0, cache);
        return lcsLen;
    }
    private int LengthOfLCS(string s1, string s2, int i, int j, Dictionary<string, int> cache){
        if(j == s2.Length) return 1;
        if(i == s1.Length) return 0;
        
        var key = $"{i},{j}";
        if(cache.ContainsKey(key)) return cache[key];
        if(s1[i] == s2[j]){
            return cache[key] = LengthOfLCS(s1, s2, i + 1, j + 1, cache) + LengthOfLCS(s1, s2, i + 1, j, cache);
        }else{
            return cache[key] = LengthOfLCS(s1, s2, i + 1, j, cache);
        }
    }
}