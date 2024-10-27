public class Solution {
    public bool CanJump_OLD_APPROACH(int[] nums) {
        var n = nums.Length;
        var ans = new int[n];
        ans[n-1] = n-1;
        for(int i = n - 2; i >=0; i--){
            if(ans[i+1] <= i + nums[i]){
                ans[i] = i;
            }else{
                ans[i] = ans[i+1];
            }
        }

        return ans[0] <= nums[0];
    }

    public bool CanJump(int[] nums) {
        int maxReach = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (i > maxReach) {
                return false;
            }
            maxReach = Math.Max(maxReach, i + nums[i]);
            if (maxReach >= nums.Length - 1) {
                return true;
            }
        }
        return false;
    }
}

/*
[2,3,1,1,4]
[0,1,2,3,4]
[G,G,G,G,G]

[3,2,1,0,4]
[B,B,B,B,G]

*/