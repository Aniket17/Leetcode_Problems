public class Solution {
    int[] memo;
    public int Rob(int[] nums) {
        var len = nums.Length;
        if(len == 1) return nums[0];
        var ans1 = Solve(nums, 0, len - 2);
        var ans2 = Solve(nums, 1, len - 1);
        return Math.Max(ans1, ans2);
    }
    
    public int Solve(int[] nums, int start, int end) {
        int t1 = 0;
        int t2 = 0;

        for (int i = start; i <= end; i++) {
            int temp = t1;
            int current = nums[i];
            t1 = Math.Max(current + t2, t1);
            t2 = temp;
        }
        return t1;
    }
}