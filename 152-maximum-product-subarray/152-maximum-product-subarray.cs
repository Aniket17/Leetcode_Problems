public class Solution {
    public int MaxProduct(int[] nums) {
        int currentMin = nums[0];
        int currentMax = nums[0];
        int max = nums[0];
        
        for(int i = 1; i < nums.Length; i++){
            var curr = nums[i];
            var tmp = Math.Max(curr, Math.Max(curr * currentMax, curr * currentMin));;
            currentMin = Math.Min(curr, Math.Min(curr * currentMax, curr * currentMin));
            currentMax = tmp;
            max = Math.Max(max, currentMax);
        }
        return max;
    }
}