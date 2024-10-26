public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        int low = 0, high = arr.Length - 1;

        while (low < high) {
            int mid = low + (high - low) / 2;

            if (arr[mid] < arr[mid + 1]) {
                // We are in the increasing part of the mountain, so move right
                low = mid + 1;
            } else {
                // We are in the decreasing part, so the peak is at mid or to the left
                high = mid;
            }
        }

        // When low == high, we have found the peak
        return low;
    }
}