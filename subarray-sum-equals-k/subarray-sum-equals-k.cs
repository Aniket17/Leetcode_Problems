/*
brute force - N^2 - loop over all subarrays and find sum == k
solution - sliding window - T - O(N) S - O(1)

[1,2,3]
i   j   sum
0   0   1


*/

public class Solution {
    public int SubarraySum(int[] nums, int k) {
        if(nums.Length == 0) return 0;
        int count = 0, sum = 0;
        Dictionary<int, int> map = new Dictionary<int, int>();
        map.Add(0, 1);
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            if (map.ContainsKey(sum - k)){
                count += map[sum - k];
            }
            map[sum] = map.GetValueOrDefault(sum, 0) + 1;
        }
        return count;
    }
}
