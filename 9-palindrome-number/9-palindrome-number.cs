public class Solution {
    public bool IsPalindrome(int x) {
        if(x < 0 || (x % 10 == 0 && x!=0)){
            return false;
        }
        var rev = 0;
        while(rev < x){
            var last = x % 10;
            rev = rev * 10 + last;
            x = x / 10;
        }
        
        return x == rev || x == rev/10;
    }
}