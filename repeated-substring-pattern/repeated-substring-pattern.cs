public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        var len = s.Length;
        
        for(int i = len/2; i >= 1; i--){
            if(len % i == 0){
                int rep = len / i;
                var part = s.Substring(0, i);
                var sb = new StringBuilder();
                for(int j = 0; j < rep; j++){
                    sb.Append(part);
                }
                if(sb.ToString() == s) return true;
            }
        }
        return false;
    }
}