public class Solution {
    bool?[,] memo;
    public bool IsInterleave(string s1, string s2, string s3) {
        //if s1[i] == s2[j] == s3[k] => dp(i+1, j+1, k+1)
        //if s1[i] == s3[k] => dp(i+1, j, k+1)
        //if s2[j] == s3[k] => dp(i, j+1, k+1)
        //dp => if((i > s1.Length || j > s2.Length) && k != s3.Length) return false
        //if any dp call returns true return true
        if(s1.Length + s2.Length != s3.Length) return false;
        memo = new bool?[s1.Length + 1, s2.Length + 1];
        return IsInterleaveUtil(s1, s2, s3, 0, 0, 0);
    }

    bool IsInterleaveUtil(string s1, string s2, string s3, int i, int j, int k){
        if(i == s1.Length && j == s2.Length && k == s3.Length) return true;
        if (memo[i, j].HasValue) return memo[i, j].Value;
        var result = false;
        if(i < s1.Length && s1[i] == s3[k]){
            result |= IsInterleaveUtil(s1, s2, s3, i + 1, j, k + 1);
        }
        if(j < s2.Length && s2[j] == s3[k]){
            result |= IsInterleaveUtil(s1, s2, s3, i, j + 1, k + 1);
        }
        memo[i, j] = result;
        return result;
    }
}