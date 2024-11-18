public class Solution {
    public void Rotate(int[] nums, int k) {
        var n = nums.Length;
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive);
        k = k % n;
        var ans = new int[n];
        for(int i = 0; i < n; i++){
            var newPos = (i + k) % n;
            ans[newPos] = nums[i];
        }
        for(int i = 0; i < n; i++){
            nums[i] = ans[i];
        }
    }
}