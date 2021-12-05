public class Solution {
    public bool IsPalindrome(int x) {
        if(x < 0) return false;
        var str = x.ToString();
        var rev = new String(str.Reverse().ToArray());
        return str == rev;
    }
}