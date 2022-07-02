/*
[1,1,3,3,4,4,8,8,9]
 0 1 2 3 4 5 6 7 8 

*/

public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        var low = 0;
        var high = nums.Length - 1;
        if(nums.Length == 1) return nums[0];
        while(low <= high){
            var mid = high - (high- low)/2;
            if(mid == 0 || mid == nums.Length - 1){
                if(mid == 0 && nums[mid] != nums[mid+1]){
                    return nums[mid];
                }else if(mid == nums.Length - 1 && nums[mid] != nums[mid-1]){
                    return nums[mid];
                }
                // handle outofbound
            }
            if(nums[mid] == nums[mid - 1]){
                if(mid%2 != 1){
                    // go left
                    high = mid - 1;
                }else{
                    // go right
                    low = mid + 1;
                }
            }else if(nums[mid] == nums[mid + 1]){
                if(mid%2 != 0){
                    // go left
                    high = mid - 1;
                }else{
                    // go right
                     low = mid + 1;
                }
            }else{
                return nums[mid];
            }
        }
        
        return nums[low];
    }
}