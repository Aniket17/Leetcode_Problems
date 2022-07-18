public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        map[0] = 1;
        var prefixSum = 0;
        var answer = 0;
        foreach(var num in nums){
            prefixSum += num;
            answer += map.GetValueOrDefault(prefixSum - k);
            map[prefixSum] = 1 + map.GetValueOrDefault(prefixSum);
        }
        return answer;
    }
}