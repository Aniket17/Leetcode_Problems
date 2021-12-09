public class Solution {
    public int MaxSubArray(int[] nums) {
        if(nums.Length == 0) return 0;
        
        int currentMax = nums[0];
        var maxSum = currentMax;
        for(int i = 1; i < nums.Length; i++){
            currentMax = Math.Max(nums[i], currentMax + nums[i]);
            maxSum = Math.Max(maxSum, currentMax);
        }
        return maxSum;
    }
}

/*
[-2,1,-3,4,-1,2,1,-5,4]

i   currentMax
0   -2
1   (-1, -2) => -1
2   (-4, -3) => -3
3   (4, 1) => 4
5   (-1, 3) => 3
6   (2, 5) => 5
7   (1, 6) => 6
8   (-5, 1)=> 1
9   (4, 5) => 5
*/