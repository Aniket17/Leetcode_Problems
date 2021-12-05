/*
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
*/

public class Solution {
    int[] dp = new int[46];
    public int ClimbStairs(int n) {
        if(n < 3) return n;
        if(dp[n] > 0) return dp[n];
        dp[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        return dp[n];
    }
}