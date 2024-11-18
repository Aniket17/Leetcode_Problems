public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
        // Step 1: Sort envelopes by width (asc) and height (desc if widths are equal)
        Array.Sort(envelopes, (a, b) => 
            a[0] == b[0] ? b[1].CompareTo(a[1]) : a[0].CompareTo(b[0]));

        // Step 2: Extract heights and find the LIS
        var heights = envelopes.Select(e => e[1]).ToArray();
        return LengthOfLIS(heights);
    }

    private int LengthOfLIS(int[] nums) {
        var lis = new List<int>();

        foreach (var num in nums) {
            int pos = BinarySearch(lis, num);
            if (pos == lis.Count) {
                lis.Add(num); // Extend the LIS
            } else {
                lis[pos] = num; // Replace to maintain the smallest possible value
            }
        }

        return lis.Count;
    }

    private int BinarySearch(List<int> lis, int target) {
        int left = 0, right = lis.Count - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (lis[mid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return left; // Position to insert or replace
    }
}
