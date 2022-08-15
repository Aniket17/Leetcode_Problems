public class Solution {
    public int MaxProduct(int[] nums) {
        var max = nums[0];
        var currentMin = nums[0];
        var currentMax = nums[0];
        for(int i = 1; i < nums.Length; i++){
            var tmp = Math.Max(nums[i], Math.Max(currentMax * nums[i], currentMin * nums[i]));
            currentMin = Math.Min(nums[i], Math.Min(currentMax * nums[i], currentMin * nums[i]));
            currentMax = tmp;
            max = Math.Max(max, currentMax);
        }
        return max;
    }
}