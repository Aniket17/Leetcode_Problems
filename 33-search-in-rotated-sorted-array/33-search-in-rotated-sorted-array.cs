/*
[7,1,2,3,4,5,6]
 0,1,2,3,4,5,6
*/

public class Solution {
    public int Search(int[] nums, int target) {
        //find pivot
        var low = 0;
        var high = nums.Length - 1;
        //already sorted
        if(nums[low] <= nums[high]) return BinarySearch(nums, low, high, target);
        var pivot = GetPivot(nums, low, high);

        var idx = BinarySearch(nums, 0, pivot, target);
        if(idx == -1){
            idx = BinarySearch(nums, pivot, nums.Length-1, target);
        }
        return idx;
    }
    
    private int GetPivot(int[] nums, int low, int high){
        if(low >= high) return -1;

        var mid = low + (high - low)/2;
            
        if(mid == 0){
            if(nums[mid] > nums[mid + 1]){
                return mid + 1;
            }
        }else if(mid == nums.Length - 1){
            if(nums[mid] < nums[mid - 1]){
                return mid;
            }
        }else{
            if(nums[mid - 1] > nums[mid]){
                return mid;
            }else if(nums[mid] > nums[mid + 1]){
                return mid + 1;
            }
        }
        
        if(nums[low] > nums[mid]){
            return GetPivot(nums, low, mid);
        }else if(nums[mid] > nums[high]){
            return GetPivot(nums, mid + 1, high);
        }
        return -1;
    }
    
    int BinarySearch(int[] nums, int low, int high, int target){
        if(low > high) return -1;
        var mid = low + (high-low)/2;
        if(nums[mid] == target){
            return mid;
        }else if(nums[mid] < target){
            return BinarySearch(nums, mid + 1, high, target);
        }else{
            return BinarySearch(nums, low, mid - 1, target);
        }
    }
}