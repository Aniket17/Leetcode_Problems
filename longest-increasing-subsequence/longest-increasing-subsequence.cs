public class Solution {
    int[,] memo;
    public int LengthOfLIS(int[] nums) {
        var n = nums.Length;
        var sorted = nums.Distinct().OrderBy(x=>x).ToArray();
        int m = sorted.Length;
        memo = new int[n,m];
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                memo[i, j] = -1;
            }
        }
        
        return Solve(nums, sorted, 0, 0);
    }
    
    int Solve(int[] s, int[] t, int i, int j){
        if(i >= s.Length || j >= t.Length) return 0;
        if(memo[i,j] != -1) return memo[i,j];
        if(s[i] == t[j]){
            return memo[i,j] = 1 + Solve(s, t, i + 1, j + 1);
        }
        return memo[i,j] = Math.Max(Solve(s, t, i+1, j), Solve(s,t,i,j+1));
    }
}