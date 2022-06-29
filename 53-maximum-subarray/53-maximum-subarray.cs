public class Solution {
    public int MaxSubArray(int[] nums) {
        var currentMax = nums[0];
        var max = nums[0];
        
        for(int i = 1; i < nums.Length; i++){
            currentMax = Math.Max(nums[i], currentMax + nums[i]);
            max = Math.Max(currentMax, max);
        }
        return max;
    }
}