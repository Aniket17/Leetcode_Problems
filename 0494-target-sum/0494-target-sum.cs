public class Solution {
    public int FindTargetSumWays(int[] nums, int target, int pos = 0, int currRes = 0) {
        if(pos == nums.Length){
            if(target == currRes) return 1;
            else return 0;
        }
        //do addition or do sub
        return FindTargetSumWays(nums, target, pos+1, currRes + nums[pos]) 
        + FindTargetSumWays(nums, target, pos+1, currRes - nums[pos]);
    }
}