public class Solution {
    int[,] memo;
    public int MinDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.Length;
        if (n < d) {
            return -1;
        }
        memo = new int[n, d + 1];
        for(int i = 0; i < n; i++){
            for(int j = 0; j <= d; j++) {
                memo[i,j] = -1;
            }
        }
        return Solve(jobDifficulty, 0, d);
    }
    
    int Solve(int[] jobs, int pos, int d){
        if(memo[pos, d] != -1) return memo[pos, d];
        int max = int.MinValue;
        if(d == 1){
            //take all the jobs and return max diff
            for(int i = pos; i < jobs.Length; i++){
                max = Math.Max(jobs[i], max);
            }
            return memo[pos,d] = max;
        }
        int res = int.MaxValue;
        
        for(int i = pos; i < jobs.Length - d + 1; i++){
            max = Math.Max(jobs[i], max);
            res = Math.Min(res, max + Solve(jobs, i + 1, d - 1));
        }
        return memo[pos,d] = res;
    }
}