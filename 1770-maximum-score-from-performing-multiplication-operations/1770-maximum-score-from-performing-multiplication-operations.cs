public class Solution {
    public int MaximumScore(int[] nums, int[] multipliers) {
        return Helper(nums, multipliers, 0, 0, new int?[multipliers.Length,multipliers.Length]);
    }
    
    private int Helper(int[] nums, int[] mul, int idx, int start, int?[,] memo)
    {
        if(idx == mul.Length) return 0;
        if(!memo[idx,start].HasValue)
        {
            int end = start + nums.Length - idx - 1;
            memo[idx,start] = Math.Max(nums[start] * mul[idx] + Helper(nums, mul,idx+1,start+1,memo),
                                nums[end] * mul[idx] + Helper(nums, mul,idx+1,start,memo));
        }
        return memo[idx,start].Value;
    }
}
