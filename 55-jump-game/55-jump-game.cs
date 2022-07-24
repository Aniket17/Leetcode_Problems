public class Solution {
    public bool CanJump(int[] nums) {
        int lastPos = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--) {
            if (i + nums[i] >= lastPos) { //means can reach here, good index
                lastPos = i;
            }
        }
        return lastPos == 0;
    }
}

/*
[3,2,1,0,4]
[3,I,I,I,0]
*/