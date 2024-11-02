public class Solution {
    public int FindPeakElement(int[] nums) {
        var low = 0;
        var high = nums.Length -1;
        
        while(low < high){
            var mid = low + (high - low)/2;
            if(nums[mid] < nums[mid + 1]){
                low = mid + 1;
            }else{
                high = mid;
            }
        }
        return low;
    }
}