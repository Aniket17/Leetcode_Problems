public class Solution {
    public int MaxSubArray(int[] nums) {
        int curr = nums[0], max = nums[0];
        for(int i = 1; i < nums.Length; i++){
            curr = Math.Max(nums[i], curr+nums[i]);
            max = Math.Max(curr, max);
        }
        return max;
    }
}