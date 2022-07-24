public class Solution {
    public string MinWindow(string s, string t) {
        
        if(String.IsNullOrEmpty(s) || String.IsNullOrEmpty(t)) return String.Empty;
        
        // Dictionary which keeps a count of all the unique characters in t.
        var dict = new Dictionary<char, int>();
        for(int i = 0; i < t.Length; i++){
            var c = t[i];
            if(!dict.ContainsKey(c)) dict[c] = 1; else dict[c] += 1;
        }
        
        // Number of unique characters in t, which need to be present in the desired window.
        var required = dict.Keys.Count;
        
        // Left and Right pointer
        int left = 0, right = 0;
        
        // formed is used to keep track of how many unique characters in t
        // are present in the current window in its desired frequency.
        // e.g. if t is "AABC" then the window must have two A's, one B and one C.
        // Thus formed would be = 3 when all these conditions are met.
        int formed = 0;
        
        // Dictionary which keeps a count of all the unique characters in the current window.
        var currentCount = new Dictionary<char, int>();
        
        int[] ans = new int[]{-1, 0, 0};
        
        while(right < s.Length){
            var c = s[right];
            if(currentCount.ContainsKey(c)) currentCount[c] += 1; else currentCount[c] = 1;
            
            if(dict.ContainsKey(c) && currentCount.GetValueOrDefault(c) == dict[c]){
                //matches with set
                formed++;
            }
           
            while(formed == required && left <= right){
                //found desirable condition.. now can move left
                c = s[left];
                
                //save current window
                if(ans[0] == -1 ||( right - left + 1) < ans[0]){
                    ans[0] = right - left + 1;
                    ans[1] = left;
                    ans[2] = right;
                }
                currentCount[c] -= 1;
                if(dict.ContainsKey(c) && currentCount[c] < dict[c]){
                //matches with set
                    formed--;
                }
                
                left++;
            }
            right++;
        }
        return ans[0] == -1 ? "" : s.Substring(ans[1], (ans[2] - ans[1]+1));
    }
}

/*
s = "ADOBECODEBANC", t = "ABC"
0 {A:1, B:1, C:1} {} 3
0 {A:1, B:1, C:1} {A:1} 2
3 {A:1, B:1, C:1} {A:1, B:1} 1
5 {A:1, B:1, C:1} {A:1, B:1, C:1} 0
*/