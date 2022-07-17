public class Solution {
    public int MaxSubArray(int[] nums) {
        var max = int.MinValue;
        var sum = 0;
        for(int i = 0; i < nums.Length; i++){
            sum = Math.Max(nums[i], sum + nums[i]);
            max = Math.Max(sum, max);
        }
        return max;
    }
}