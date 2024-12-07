public class Solution {
    public int MinimumSize(int[] nums, int maxOperations) {
        int left = 1, right = int.MinValue;
        
        // Find the maximum number in nums
        foreach (var num in nums) {
            right = Math.Max(right, num);
        }

        while (left < right) {
            int mid = left + (right - left) / 2;
            if (CanReduce(nums, maxOperations, mid)) {
                right = mid; // Try for a smaller penalty
            } else {
                left = mid + 1; // Increase the penalty
            }
        }

        return left;
    }

    // Helper function to check if a given penalty can be achieved within maxOperations
    private bool CanReduce(int[] nums, int maxOperations, int penalty) {
        int operations = 0;
        foreach (var num in nums) {
            operations += (num - 1) / penalty; // Equivalent to ceil(num / penalty) - 1
            if (operations > maxOperations) return false;
        }
        return true;
    }

}