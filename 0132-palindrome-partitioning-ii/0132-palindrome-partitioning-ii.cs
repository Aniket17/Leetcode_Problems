public class Solution {
    Dictionary<int, int> memo;
    public int MinCut(string s) {
        memo = new();
        return MinCutUtil(s, 0);
    }
    int MinCutUtil(string s, int start){
        if(memo.ContainsKey(start)) return memo[start];
        if(start == s.Length || IsPalindrome(s, start, s.Length - 1)) return 0;
        var minCuts = s.Length - start;
        for(int i = start; i < s.Length; i++){
            if(IsPalindrome(s, start, i)){
                minCuts = Math.Min(minCuts, 1 + MinCutUtil(s, i + 1));
            }
        }
        return memo[start] = minCuts;
    }

    bool IsPalindrome(string s, int left, int right){
        while(left <= right){
            if(s[left++] != s[right--]) return false;
        }
        return true;
    }
}