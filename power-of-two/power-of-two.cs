public class Solution {
    public bool IsPowerOfTwo(int n) {
        // check only one bit is set
        if (n == 0) return false;
        long x = (long) n;
        return (x & (-x)) == x;
    }
}