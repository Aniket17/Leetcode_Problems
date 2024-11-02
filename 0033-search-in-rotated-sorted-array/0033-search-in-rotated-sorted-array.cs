public class Solution {
    public int Search(int[] nums, int target) {
        var pivot = FindPivot(nums);
        //search the left half
        var index = Search(nums, 0, pivot-1, target);
        if(index == -1){
            index = Search(nums, pivot, nums.Length-1, target);
        }
        return index;
    }

    int FindPivot(int[] nums){
        int lower = 0, higher = nums.Length - 1, n = nums.Length;
        
        while(lower <= higher){
            int mid = lower + (higher - lower)/2;
            if(nums[mid] > nums[n-1]){
                lower = mid + 1;
            }else{
                higher = mid - 1;
            }
        }
        return lower;
    }

    int Search(int[] nums, int lower, int higher, int target){
        if(lower > higher) return -1;
        var mid = lower + (higher - lower)/2;
        if(nums[mid] == target) return mid;
        if(nums[mid] > target) return Search(nums, lower, mid-1, target);
        return Search(nums, mid + 1, higher, target);
    }
}

