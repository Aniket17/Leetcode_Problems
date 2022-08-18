public class Solution {
    int[] memo;
    public int NumWays(int n, int k) {
        memo = new int[n+1];
        Array.Fill(memo, -1);
        return TotalWays(n, k);
    }
    
    int TotalWays(int i, int k){
        if (i == 1) return k;
        if (i == 2) return k * k;
        if (memo[i] !=-1) {
            return memo[i];
        }
        // Use the recurrence relation to calculate totalWays(i)
        memo[i] = (k - 1) * (TotalWays(i - 1, k) + TotalWays(i - 2, k));
        return memo[i];
    }
}

/*
n k w
7 2 2+ (6,2,1) = 12
6 2 2+ (5,2,2) = 10
5 2 2+ (4,1,0) = 8
4 1 1+ (3,2,1) = 7
3 2 2+ (2,2,2) = 6
2 2 4
*/