public class Solution {
    public int Rob(int[] nums) {
        int[] dp = new int[nums.Length];
        Array.Fill(dp, -1);
        return Rob(0);

        int Rob(int index){
            if(index >= nums.Length) return 0;
            if(dp[index] != -1) return dp[index];
            return dp[index] = Math.Max(nums[index] + Rob(index+2), Rob(index+1));
        }
    }
}