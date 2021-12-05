public class Solution {
    int[] memo;
    public int Rob(int[] nums) {
        memo = new int[nums.Length];
        Array.Fill(memo, -1);
        return Solve(nums, 0);
    }
    
    public int Solve(int[] nums, int i) {
        if(i >= nums.Length){
            return 0;
        }
        if(memo[i] > -1) return memo[i];
        memo[i] = Math.Max(Solve(nums, i + 2) + nums[i], Solve(nums, i + 1));
        return memo[i];
    }
}