public class Solution {
    public int Reverse(int x) {
        int rev = 0;
        int high = int.MaxValue/10 ;
        int low = int.MinValue/10 ;
        while (x != 0) {
            int pop = x % 10;
            x /= 10;
            if (rev > high|| (rev == high && pop > 7)) return 0;
            if (rev < low || (rev == low && pop < -8)) return 0;
            rev = rev * 10 + pop;
        }
        return rev;
    }
}
/*  
198
res - 8
res - 8 * 10 + 9 = 89
res - 89 * 10 + 1 = 891
    
*/