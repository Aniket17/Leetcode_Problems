public class Solution {
    private const int mod = 1000000007;

    public int SumOfGoodSubsequences(int[] nums) {
        long res = 0;
        int n = nums.Length;
        Dictionary<int, long> sum = new Dictionary<int, long>();
        Dictionary<int, long> count = new Dictionary<int, long>();

        for (int i = 0; i < n; i++) {
            res = (res + nums[i]) % mod;
            int toFind1 = nums[i] + 1;
            int toFind2 = nums[i] - 1;

            long cnt1 = count.ContainsKey(toFind1) ? count[toFind1] : 0;
            long sum1 = sum.ContainsKey(toFind1) ? sum[toFind1] : 0;
            res = (res + (cnt1 * nums[i] % mod + sum1) % mod) % mod;

            long cnt2 = count.ContainsKey(toFind2) ? count[toFind2] : 0;
            long sum2 = sum.ContainsKey(toFind2) ? sum[toFind2] : 0;
            res = (res + (cnt2 * nums[i] % mod + sum2) % mod) % mod;

            if (!count.ContainsKey(nums[i])) count[nums[i]] = 0;
            if (!sum.ContainsKey(nums[i])) sum[nums[i]] = 0;

            count[nums[i]] = (count[nums[i]] + cnt1 + cnt2 + 1) % mod;
            long curr = ((nums[i]) * (cnt1 + cnt2 + 1)) % mod;
            sum[nums[i]] = (sum[nums[i]] + sum1 + sum2 + curr) % mod;
        }

        return (int)res;
    }
}