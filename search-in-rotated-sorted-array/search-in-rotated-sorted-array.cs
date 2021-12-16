public class Solution {
    public int Search(int[] nums, int target) {
        
        if(nums.Length == 0) return -1;
        
        if(nums.Length == 1) return target == nums[0] ? 0 : -1;
        
        var pivot = GetPivot(nums, 0, nums.Length - 1);
        Console.WriteLine("PIVOT - " + pivot);
        if(pivot == -1){
            //already sorted
            return Search(nums, 0, nums.Length - 1, 0, nums.Length - 1, target);
        }
        
        var idx = Search(nums, 0, pivot, 0, pivot, target);
        if(idx != -1){
            return idx;
        }
        return Search(nums, pivot, nums.Length - 1, pivot, nums.Length - 1, target);
    }
    
    int Search(int[] nums, int left, int right, int low, int high, int target){
        if(low == high){
            if(nums[low] == target){ 
                return low;
            }
            return -1;
        }
       
        if(low < left || high > right){
            return -1;
        }
        
        var mid = low + (high - low)/2;
        if(target < nums[mid]){
            //search left
            return Search(nums, left, right, low, mid, target);
        }else if(target > nums[mid]){
            return Search(nums, left, right, mid + 1, high, target);
        }
        return mid;
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
}

/*
[0,1,2,4,5,6,7]
[4,5,6,7,0,1,2] ans + 1 start
[7,1,2,4,5,6,0] ans - 1 end

[7,6,5,0,3,2,1] ans - 1 end
*/
