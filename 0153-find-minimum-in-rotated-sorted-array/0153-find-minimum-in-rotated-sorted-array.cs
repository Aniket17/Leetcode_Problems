public class Solution {
    public int FindMin(int[] nums) {
        var n = nums.Length;
        int left = 0, right = n - 1;
        while(left < right){
            var mid = left + (right - left)/2;
            if(nums[mid] > nums[n-1]){
                //min is in right
                left = mid + 1;
            }else{
                right = mid;
            }
        }
        return nums[left];
    }
}

/*
[11,13,15,17]

*/