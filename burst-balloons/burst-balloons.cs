public class Solution {
    int[,] dp;
    public int MaxCoins(int[] nums) {
        dp = new int[nums.Length + 2,nums.Length + 2];
        var list = nums.ToList();
        list.Insert(0,1);
        list.Insert(list.Count,1);
        return Solve(list, 1, list.Count - 1);
    }
    
    int Solve(List<int> nums, int i, int j){
        if(i >= j){
            return 0;
        }
        if(dp[i,j] != 0) return dp[i,j];
        var max = int.MinValue;
        for(int k = i; k < j; k++){
            var temp = Solve(nums, i, k) + Solve(nums, k + 1, j) + (nums[i - 1] * nums[j] * nums[k]);
            max = Math.Max(max, temp);
        }
        return dp[i,j] = max;
    }
}