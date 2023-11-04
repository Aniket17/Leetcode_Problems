public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var n = nums.Length;
        var leftProduct = new int[n];
        var rightProduct = new int[n];
        leftProduct[0] = 1;
        rightProduct[n-1] = 1;

        for(int i = 1; i < n; i++){
            leftProduct[i] = leftProduct[i-1]*nums[i-1];
        }

        for(int i = n-2; i >= 0; i--){
            rightProduct[i] = rightProduct[i+1]*nums[i+1];
        }

        var ans = new int[n];
        for(int i = 0; i < n; i++){
            ans[i] = leftProduct[i] * rightProduct[i];
        }

        return ans;
    }
}

/*
[1,2,3,4]
L [1,2,6,24]
R [24,24,12,4]
*/