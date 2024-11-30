public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] diff = new int[n + 1];

        // Apply the queries to the difference array
        foreach (var query in queries) {
            int li = query[0];
            int ri = query[1];
            diff[li]++;
            if (ri + 1 < diff.Length) {
                diff[ri + 1]--;
            }
        }

        // Compute the prefix sum to get the actual effect of queries
        for (int i = 1; i < n; i++) {
            diff[i] += diff[i - 1];
        }

        // Check if nums can be transformed
        for (int i = 0; i < n; i++) {
            if(nums[i] > diff[i]) return false;
        }

        // Ensure all elements are zero
        return true;
    }
}