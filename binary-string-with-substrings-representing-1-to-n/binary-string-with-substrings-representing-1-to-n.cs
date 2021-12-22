public class Solution {
    public bool QueryString(string s, int n) {
        for(int i = 1; i <= n; i++){
            if(s.IndexOf(Convert.ToString(i, 2)) == -1) return false;
        }
        return true;
    }
}