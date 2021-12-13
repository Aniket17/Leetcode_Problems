public class Solution {
    public int MaxPower(string s) {
        if(s.Length < 2) return s.Length;
        var left = 0;
        var right = 1;
        var max = 1;
        while(right < s.Length){
            if(s[right] != s[right - 1]){
                max = Math.Max(right - left, max);
                left = right;
            }
            right++;
        }
        max = Math.Max(right - left, max);
        return max;
    }
}

/*
leetcode
l   r   lp  m
1   1   0   1
1   2   0   1
1   3   1   1
2   4   1   2

*/