public class Solution {
    public bool CanJump(int[] nums) {
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
}

/*
[2,3,1,1,4]
[0,1,2,3,4]
[G,G,G,G,G]

[3,2,1,0,4]
[B,B,B,B,G]

*/