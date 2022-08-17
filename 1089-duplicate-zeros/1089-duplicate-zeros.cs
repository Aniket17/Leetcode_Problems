public class Solution {
    public void DuplicateZeros(int[] arr) {
        int dups = 0;
        int n = arr.Length - 1;

        // Find the number of zeros to be duplicated
        // Stopping when left points beyond the last element in the original array
        // which would be part of the modified array
        for (int left = 0; left <= n - dups; left++) {

            // Count the zeros
            if (arr[left] == 0) {

                // Edge case: This zero can't be duplicated. We have no more space,
                // as left is pointing to the last element which could be included  
                if (left == n - dups) {
                    // For this zero we just copy it without duplication.
                    arr[n] = 0;
                    n -= 1;
                    break;
                }
                dups++;
            }
        }

        // Start backwards from the last element which would be part of new array.
        int last = n - dups;

        // Copy zero twice, and non zero once.
        for (int i = last; i >= 0; i--) {
            if (arr[i] == 0) {
                arr[i + dups] = 0;
                dups--;
                arr[i + dups] = 0;
            } else {
                arr[i + dups] = arr[i];
            }
        }
    }
}