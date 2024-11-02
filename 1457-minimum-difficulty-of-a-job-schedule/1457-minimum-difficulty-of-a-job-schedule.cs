public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.Length;
        if (d > n) return -1; // More days than jobs is impossible
        
        // Initialize memoization table with -1 (uncomputed state)
        int[,] dp = new int[n, d + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= d; j++) {
                dp[i, j] = -1;
            }
        }
        
        int result = Util(jobDifficulty, d, 0, dp);
        return result == int.MaxValue ? -1 : result;
    }

    int Util(int[] jobs, int days, int index, int[,] dp) {
        if (days == 1) {
            return GetMax(jobs, index, jobs.Length);
        }
        if (index >= jobs.Length || days <= 0) {
            return int.MaxValue; // Invalid state
        }
        if (dp[index, days] != -1) {
            return dp[index, days];
        }
        
        int maxInCurrentDay = int.MinValue;
        int minTotalDifficulty = int.MaxValue;
        
        for (int i = index; i <= jobs.Length - days; i++) {
            maxInCurrentDay = Math.Max(maxInCurrentDay, jobs[i]);
            int nextDayDifficulty = Util(jobs, days - 1, i + 1, dp);
            if (nextDayDifficulty != int.MaxValue) {
                minTotalDifficulty = Math.Min(minTotalDifficulty, maxInCurrentDay + nextDayDifficulty);
            }
        }
        
        dp[index, days] = minTotalDifficulty;
        return dp[index, days];
    }

    int GetMax(int[] jobs, int start, int end) {
        int max = int.MinValue;
        for (int i = start; i < end; i++) {
            max = Math.Max(max, jobs[i]);
        }
        return max;
    }
}
