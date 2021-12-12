public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var max = 0;
        var currentMax = 0;
        for(int i = 0; i < nums.Length; i++){
            if((nums[i] & 1) == 0){
                max = Math.Max(currentMax, max);
                currentMax = 0;
            }else{
                currentMax++;
            }
        }
        max = Math.Max(currentMax, max);
        return max;
    }
}