public class Solution {
    public int MaxSubArray(int[] nums) {
        var currentMax = nums[0];
        int max = nums[0];
        for(int i = 1; i < nums.Length; i++){
            currentMax = Math.Max(currentMax + nums[i], nums[i]);
            max = Math.Max(currentMax, max);
        }
        return max;
    }
}

//[-2,1,-3,4,-1,-2,100,-5,4]