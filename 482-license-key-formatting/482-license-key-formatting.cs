public class Solution {
    public string LicenseKeyFormatting(string s, int k) {
        var chars = s.ToUpper().Where(x=>x != '-').ToArray();
        s = new string(chars);
        if(s.Length <= k) return s.ToUpper();
        var sb = new StringBuilder();
        int i = 0;
        var firstGroup = chars.Length%k == 0 ? k :chars.Length%k;
        while(i < firstGroup){
            sb.Append(chars[i++]);
        }
        sb.Append('-');
        while(i < s.Length){
            if(i + k < s.Length){
                sb.Append(s.Substring(i, k));
            }else{
                sb.Append(s.Substring(i));
            }
            i += k;
            if(i < s.Length)sb.Append('-');
        }
        return sb.ToString();
    }
}