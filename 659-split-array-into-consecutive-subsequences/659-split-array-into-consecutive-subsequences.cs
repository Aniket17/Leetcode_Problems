public class Solution {
    public bool IsPossible(int[] nums) {
        Dictionary<int, int> subsequences = new();
        Dictionary<int, int> frequency = new();
        foreach(int num in nums) {
            frequency[num] = frequency.GetValueOrDefault(num) + 1;
        }
        foreach(int num in nums) {
            //num already part of a valid subsequence.
            if (frequency[num] == 0) {
                continue;
            }
            // If a valid subsequence exists with the last element = num - 1.
            if (subsequences.GetValueOrDefault(num - 1) > 0) {
                subsequences[num - 1] = subsequences.GetValueOrDefault(num - 1) - 1;
                subsequences[num] = subsequences.GetValueOrDefault(num) + 1;
            } else if (frequency.GetValueOrDefault(num + 1) > 0 && 
                       frequency.GetValueOrDefault(num + 2) > 0) {
                // If we want to start a new subsequence, check if num + 1 and num + 2 exist.
                // Update the list of subsequences with the newly created subsequence
                subsequences[num + 2] = subsequences.GetValueOrDefault(num + 2) + 1;
                frequency[num + 1] = frequency.GetValueOrDefault(num + 1) - 1;
                frequency[num + 2] = frequency.GetValueOrDefault(num + 2) - 1;
            } else {
                //No valid subsequence is possible with num
                return false;
            }
            frequency[num] = frequency[num] - 1;
        }
        return true;
    }
}