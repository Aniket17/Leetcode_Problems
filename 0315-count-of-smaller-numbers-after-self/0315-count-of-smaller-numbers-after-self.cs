public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        int n = nums.Length;
        var counts = new int[n];  // This will hold the count of smaller elements to the right
        var indexedNums = new (int val, int index)[n];  // Pair each element with its original index
        
        for (int i = 0; i < n; i++) {
            indexedNums[i] = (nums[i], i);  // Store value and index
        }

        MergeSort(indexedNums, counts, 0, n - 1);
        return counts.ToList();
    }

    void MergeSort((int val, int index)[] nums, int[] counts, int low, int high) {
        if (low >= high) return;  // Base case: single element or no element
        
        int mid = (low + high) / 2;
        MergeSort(nums, counts, low, mid);
        MergeSort(nums, counts, mid + 1, high);
        Merge(nums, counts, low, mid, high);
    }

    void Merge((int val, int index)[] nums, int[] counts, int low, int mid, int high) {
        var leftArray = new (int val, int index)[mid - low + 1];
        var rightArray = new (int val, int index)[high - mid];

        // Copy the left and right subarrays
        for (int i = 0; i < leftArray.Length; i++) leftArray[i] = nums[low + i];
        for (int i = 0; i < rightArray.Length; i++) rightArray[i] = nums[mid + 1 + i];

        int iLeft = 0, iRight = 0, k = low;
        int rightSmallerCount = 0;  // Tracks how many elements from the right half are smaller

        // Merging and counting
        while (iLeft < leftArray.Length && iRight < rightArray.Length) {
            if (leftArray[iLeft].val <= rightArray[iRight].val) {
                // Left element is smaller, so it should go into the merged array
                counts[leftArray[iLeft].index] += rightSmallerCount;  // Add the count of smaller elements from the right
                nums[k++] = leftArray[iLeft++];
            } else {
                // Right element is smaller, increment rightSmallerCount
                rightSmallerCount++;
                nums[k++] = rightArray[iRight++];
            }
        }

        // Copy the remaining elements from leftArray (if any)
        while (iLeft < leftArray.Length) {
            counts[leftArray[iLeft].index] += rightSmallerCount;  // All remaining right elements are smaller
            nums[k++] = leftArray[iLeft++];
        }

        // Copy the remaining elements from rightArray (if any)
        while (iRight < rightArray.Length) {
            nums[k++] = rightArray[iRight++];
        }
    }
}
