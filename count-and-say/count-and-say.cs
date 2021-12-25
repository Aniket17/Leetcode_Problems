public class Solution {
    public string CountAndSay(int n) {
        if(n < 0) return "";
        string res = "1";
        while(n > 1){
            var sb = new StringBuilder();
            for(int i = 0; i < res.Length; i++){
                int count = 1;
                while(i + 1 < res.Length && res[i] == res[i + 1]){
                    ++count;
                    ++i;
                }
                sb.Append(count).Append(res[i]);
            }
            res = sb.ToString();
            --n;
        }
        return res;
    }
}