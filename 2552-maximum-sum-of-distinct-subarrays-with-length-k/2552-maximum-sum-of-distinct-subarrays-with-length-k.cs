public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        var prefixSum = new long[n + 1];
        for (int ind = 1; ind <= n; ind++) {
            prefixSum[ind] = prefixSum[ind - 1] + nums[ind - 1];
        }

        int i = 0, j = 0;
        long maxSum = 0;
        var set = new HashSet<int>();

        while (j < n) {
            // Add the current number to the set and check for duplicates
            while (set.Contains(nums[j])) {
                set.Remove(nums[i]);
                i++;
            }
            set.Add(nums[j]);

            // Check if the current window size matches `k`
            if (j - i + 1 == k) {
                maxSum = Math.Max(maxSum, prefixSum[j + 1] - prefixSum[i]);
                // Shrink the window to maintain `k` length
                set.Remove(nums[i]);
                i++;
            }
            j++;
        }

        return maxSum;
    }
}