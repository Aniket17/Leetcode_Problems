public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }

        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, 1); // Each element has an LIS of at least 1 (itself)

        int maxLIS = 1;

        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (nums[j] < nums[i]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            maxLIS = Math.Max(maxLIS, dp[i]); // Update the global maximum
        }

        return maxLIS;
    }
}
