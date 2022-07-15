public class Solution {
    public string ReverseStr(string s, int k) {
        //take 2k groups 
        //reverse these k chars from every group and append it
        var groupSize = 2 * k;
        var sb = new StringBuilder();
        for(int i = 0; i < s.Length; i+=groupSize){
            var word = "";
            if(i + groupSize > s.Length){
                word = s.Substring(i);
            }else{
                word = s.Substring(i, groupSize);
            }
            //reverse k chars
            if(word.Length <= k){
                //reverse all                
                char[] charArray = word.ToCharArray();
                Array.Reverse(charArray);
                word = new string(charArray);
            }else{
                //reverse first k
                char[] charArray = word.Substring(0, k).ToCharArray();
                Array.Reverse(charArray);
                var pref = new string(charArray);
                var suff = word.Substring(k);
                word = pref + suff;
            }
            
            sb.Append(word);
        }
        return sb.ToString();
    }
}