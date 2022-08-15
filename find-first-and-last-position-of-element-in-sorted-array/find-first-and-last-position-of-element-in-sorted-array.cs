public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        var startIndex = Array.BinarySearch(nums, target);
        var endIndex = startIndex;
        
        if(startIndex < 0) return new int[]{-1,-1};
        while(startIndex > 0 && nums[startIndex - 1] == target){
            var id = Search(nums, 0, startIndex - 1, target);
            if(id == -1){
                break;
            }
            startIndex = id;
        }
        while(endIndex < nums.Length - 1 && nums[endIndex + 1] == target){
            var id = Search(nums, endIndex + 1, nums.Length - 1, target);
            if(id == -1){
                break;
            }
            endIndex = id;
        }
        return new int[]{startIndex, endIndex};
    }
    
    private int Search(int[] nums, int low, int high, int target){
        var mid = low + (high - low)/2;
        if(low == high){
            return nums[low] == target ? low : -1;
        }
        if(low < high){
            if(nums[mid] == target){
                return mid;
            }else if(nums[mid] < target){
                return Search(nums, mid+1, high, target);
            }else{
                return Search(nums, low, mid-1, target);
            }
        }
        return -1;
    }
}