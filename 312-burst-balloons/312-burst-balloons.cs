public class Solution {
    int[][] memo;
    public int MaxCoins(int[] nums) {
        if(nums.Length == 1) return nums[0];
        memo = new int[nums.Length + 2][];
        for(int i = 0; i <= nums.Length+1; i++){
            memo[i] = new int[nums.Length+2];
        }
        var newNums = new int[nums.Length + 2];
        newNums[0] = 1;
        for(int i = 0; i < nums.Length; i++){
            newNums[i + 1] = nums[i];
        }
        newNums[nums.Length + 1] = 1;
        return Burst(newNums, 1, nums.Length);
    }
    
    int Burst(int[] nums, int i, int j){
        if(i > j) return 0;
        if(memo[i][j] > 0) return memo[i][j];
        var ans = 0;
        for(int k = i; k <= j; k++){
            int gain = nums[i-1] * nums[k] * nums[j+1];
            var remaining = Burst(nums, i, k - 1) + Burst(nums, k+1, j);
            ans = Math.Max(ans, remaining + gain);   
        }
        return memo[i][j] = ans;
    }
}