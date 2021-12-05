public class Solution {
    int[] memo;
    bool hasInit = false;
    public int Fib(int n) {
        if(!hasInit){
            memo = new int[n + 1];
            Array.Fill(memo, -1);
            hasInit = true;
        }
        if(n < 2) return n;
        if(memo[n] > -1) return memo[n];
        memo[n] = Fib(n - 1) + Fib(n - 2);
        return memo[n];
    }
}