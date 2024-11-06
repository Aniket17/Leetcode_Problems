public class Solution {
    int[][] dp;
    public int MinDifficulty(int[] jobDifficulty, int d) {
        var n = jobDifficulty.Length;
        dp = new int[n][];
        for(int i = 0; i < n; i++){
            dp[i] = new int[d + 1];
            Array.Fill(dp[i], -1);
        }
        var ans = MinDifficultyUtil(jobDifficulty, d, 0);
        return ans == int.MaxValue ? -1 : ans;
    }

    int MinDifficultyUtil(int[] jobs, int days, int index){
        if(days == 1){
            return GetMax(jobs, index, jobs.Length);
        }
        if(index >= jobs.Length || days <= 0) return int.MaxValue;
        if(dp[index][days] != -1) return dp[index][days];

        var minJobDifficulty = int.MaxValue;
        var maxCurrDayDiff = int.MinValue;

        for(int i = index; i <= jobs.Length - days; i++){
            //take it to current day or leave it for current day
            //calculate overall schedule difficulty
            //take the max from this day
            maxCurrDayDiff = Math.Max(jobs[i], maxCurrDayDiff);
            var nextDayDiff = MinDifficultyUtil(jobs, days - 1, i + 1);
            if(nextDayDiff != int.MaxValue){
                minJobDifficulty = Math.Min(minJobDifficulty, maxCurrDayDiff + nextDayDiff);
            }
        }
        return dp[index][days] = minJobDifficulty;
    }

    int GetMax(int[] jobs, int start, int end) {
        int max = int.MinValue;
        for (int i = start; i < end; i++) {
            max = Math.Max(max, jobs[i]);
        }
        return max;
    }

    //dp(i, day) = dp(i...len-day, day-1)
}