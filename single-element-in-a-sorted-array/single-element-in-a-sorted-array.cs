public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        if(nums.Length == 1){ return nums[0]; }
        var low = 0;
        var high = nums.Length - 1;
        
        while(low < high){
            var mid = low + (high - low)/2;
            var firstOccurance = -1;
            if(mid == 0){
                if(nums[mid] == nums[mid + 1]){
                    firstOccurance = mid;
                }else{
                    return nums[mid];
                }
            }else if(mid == nums.Length - 1){
                if(nums[mid] == nums[mid - 1]){
                    firstOccurance = mid - 1;
                }else{
                    return nums[mid];
                }
            }else{
                if(nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1]){
                    return nums[mid];
                }
                firstOccurance = nums[mid] == nums[mid - 1] ? mid - 1 : mid;
            }
            if(firstOccurance % 2 == 0){
                low = mid + 1;
            }else{
                high = mid - 1;
            }
        }
        return nums[low];
    }
}

// first occurance is even index -> search left
// first occurance is odd index -> search right
// check if either side has same element