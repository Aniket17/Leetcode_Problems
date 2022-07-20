public class Solution {
    Dictionary<string, bool> memo = new Dictionary<string, bool>();
    public bool IsInterleave(string s1, string s2, string s3) {
        var i = 0;
        var j = 0;
        var k = 0;
        var key = $"{s1},{s2},{s3}";
        if(memo.ContainsKey(key)) return memo[key];
        while(i < s1.Length && j < s2.Length && k < s3.Length){
            var ch = s3[k++];
            if(s1[i] == ch && s2[j] == ch){
                return memo[key] = IsInterleave(s1.Substring(i+1), s2.Substring(j), s3.Substring(k))
                    || IsInterleave(s1.Substring(i), s2.Substring(j+1), s3.Substring(k));
            }else if(s1[i] == ch){
                i++;
            }else if(s2[j] == ch){
                j++;
            }else{
                memo[key] = false;
            }
        }
        
        if(i < s1.Length && k < s3.Length){
            return memo[key] = s1.Substring(i) == s3.Substring(k);
        }
        
        if(j < s2.Length && k < s3.Length){
            return memo[key] = s2.Substring(j) == s3.Substring(k);
        }
        return memo[key] = (i == s1.Length && j == s2.Length && k == s3.Length);
    }
}

/*
a a b c c
a a b c d
a a b c d 

*/