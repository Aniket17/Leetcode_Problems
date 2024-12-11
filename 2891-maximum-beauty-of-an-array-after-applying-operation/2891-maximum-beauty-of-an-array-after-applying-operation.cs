using System;

public class Solution
{
    public int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);
        int maxBeauty = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            // Find the farthest index where the value is within the range [nums[i], nums[i] + 2 * k]
            int upperBound = FindUpperBound(nums, nums[i] + 2 * k);
            // Update the maximum beauty based on the current range
            maxBeauty = Math.Max(maxBeauty, upperBound - i + 1);
        }

        return maxBeauty;
    }

    // Helper function to find the largest index where arr[index] <= val
    private int FindUpperBound(int[] arr, int val)
    {
        int low = 0, high = arr.Length - 1, result = 0;

        // Perform binary search to find the upper bound
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (arr[mid] <= val)
            {
                result = mid; // Update the result and move to the right half
                low = mid + 1;
            }
            else
            {
                high = mid - 1; // Move to the left half
            }
        }

        return result;
    }
}
