public class Solution {
    int[] memo;
    public bool CanPartition(int[] nums) {
        var total = nums.Sum(x=>x);
        if(total % 2 != 0) return false;
        memo = new int[total/2 + 1];
        return Solve(nums, total/2, 0);
    }
    
    bool Solve(int[] nums, int total, int pos){
        if(0 == total) return true;
        if(0 > total) return false;
        if(memo[total] != 0) return memo[total] != -1;
        for(int i = pos; i < nums.Length; i++){
            var take = false;
            if(nums[i] <= total){
                take = Solve(nums, total - nums[i], i + 1);
            }
            var dontTake = Solve(nums, total, i + 1);
            if(take || dontTake){
                memo[total] = 1;
                return true;
            }
        }
        memo[total] = -1;
        return false;
    }
    
}