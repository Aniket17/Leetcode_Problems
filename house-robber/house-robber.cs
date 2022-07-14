public class Solution {
    int[] memo;
    public int Rob(int[] nums) {
        memo = new int[nums.Length];
        Array.Fill(memo, -1);
        var startAt1 = RobHouse(nums, 0);
        var startAt2 = RobHouse(nums, 1);
        return Math.Max(startAt1, startAt2);
    }
    
    private int RobHouse(int[] nums, int houseNumber){
        if(houseNumber >= nums.Length) return 0;
        if(memo[houseNumber] != -1) return memo[houseNumber];
        var robbed = nums[houseNumber] + RobHouse(nums, houseNumber + 2);
        var notRobbed = RobHouse(nums, houseNumber + 1);
        return memo[houseNumber] = Math.Max(robbed, notRobbed);
    }
}