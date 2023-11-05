public class Solution {
    public string MinWindow(string s, string t) {
        if(t.Length > s.Length) return "";
        var countsMap = t.GroupBy(x => x).Select(x => new { Key = x.Key, Ct = x.Count() }).ToDictionary(x => x.Key, x => x.Ct);

        int left = 0, right = 0;
        var currMap = new Dictionary<char, int>();
        var formed = 0;
        var required = countsMap.Keys.Count;
        var ans = new int[]{-1,0,0}; //len, left, right
        while(right < s.Length){
            var ch = s[right];
            currMap[ch] = currMap.GetValueOrDefault(ch) + 1;
            if(countsMap.ContainsKey(ch) && currMap[ch] == countsMap[ch]){
                formed++;
            }

            while(formed == required && left <= right){
                ch = s[left];
                if(ans[0] == -1 || ans[0] > right-left+1){
                    ans = new int[]{right-left+1, left, right};
                }
                currMap[ch]--;
                if(countsMap.ContainsKey(ch) && currMap[ch] < countsMap[ch]){
                    formed--;
                }
                left++;
                
            }
            right++;
        }
        return ans[0] == -1 ? "" : s.Substring(ans[1], (ans[2] - ans[1]+1));
    }
}