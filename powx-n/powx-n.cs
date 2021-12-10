public class Solution {
    public double MyPow(double x, int n) {
        if(n == 0 || x == 1){
            return 1;
        }
        long N = n;
        if (N < 0) {
            x = 1 / x;
            N = -N;
        }
        return FastPow(x, N);
    }
    
    private double FastPow(double x, long n) {
        if (n == 0) {
            return 1.0;
        }
        double half = FastPow(x, n / 2);
        if (n % 2 == 0) {
            return half * half;
        } else {
            return half * half * x;
        }
    }
}

/*
2, 10

n   result 
10  2
9   4
8   8
7   16
6   32
5   64
4   128
3   256
2   512
1   1024
*/