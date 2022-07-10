public class Solution {
    public int MaxProduct(int[] nums) {
        int currentMin = nums[0];
        int currentMax = nums[0];
        int max = nums[0];
        
        for(int i = 1; i < nums.Length; i++){
            var tmp = Math.Max(nums[i], Math.Max(nums[i] * currentMax, nums[i] * currentMin));;
            currentMin = Math.Min(nums[i], Math.Min(nums[i] * currentMax, nums[i] * currentMin));
            currentMax = tmp;
            max = Math.Max(max, currentMax);
        }
        return max;
    }
}