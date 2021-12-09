public class Solution {
    public int FindDuplicate(int[] nums) {
        for(int i = 1; i <= nums.Length; i++){
            if(nums[Math.Abs(nums[i - 1]) - 1] < 0){
                return Math.Abs(nums[i - 1]);
            }
            nums[Math.Abs(nums[i - 1]) - 1] *= -1;
        }
        return 0;
    }
}

/*
[-1,-3,-4,-2,2]
*/