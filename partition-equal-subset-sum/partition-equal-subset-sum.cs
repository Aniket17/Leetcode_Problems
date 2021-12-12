public class Solution {
    public bool CanPartition(int[] nums) {
        var total = nums.Sum();
        if(total % 2 != 0) return false;
        var targetSum = total / 2;
        var dp = new int[targetSum + 2];
        return TargetSum(nums, targetSum, nums.Length - 1, dp);
    }
    
    private bool TargetSum(int[] nums, int target, int n, int[] dp){
        if(target == 0) return true;
        if(target < 0) return false;
        if(n < 0) return false;
        if(dp[target] != 0){
            return dp[target] == 1;
        }
        dp[target] = TargetSum(nums, target - nums[n], n - 1, dp) || TargetSum(nums, target, n - 1, dp) ? 1 : -1;
        return dp[target] == 1;
    }
}