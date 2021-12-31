public class Solution {
    Dictionary<string, bool> memo = new Dictionary<string, bool>();
    
    public bool IsInterleave(string s1, string s2, string s3) {
        int i = 0;
        int j = 0; 
        int k = 0;
        
        var key = string.Join("*", s1, s2, s3);
        if(memo.ContainsKey(key)) return memo[key];
        
        while(i < s1.Length && j < s2.Length && k < s3.Length){
            var target = s3[k++];
            if(s1[i] == target && s2[j] == target){
                // 2 calls
                var ans = IsInterleave(s1.Substring(i + 1), s2.Substring(j), s3.Substring(k)) ||
                    IsInterleave(s1.Substring(i), s2.Substring(j + 1), s3.Substring(k));
                return memo[key] = ans;
            }else if(s1[i] == target){
                i++;
            }else if(s2[j] == target){
                j++;
            }else{
                return memo[key] = false;
            }
        }
        
        if(i < s1.Length && k < s3.Length){
            return memo[key] = s1.Substring(i) == s3.Substring(k);
        }
        if(j < s2.Length && k < s3.Length){
            return memo[key] = s2.Substring(j) == s3.Substring(k);
        }
        return memo[key] = i == s1.Length && j == s2.Length && k == s3.Length;
    }
}