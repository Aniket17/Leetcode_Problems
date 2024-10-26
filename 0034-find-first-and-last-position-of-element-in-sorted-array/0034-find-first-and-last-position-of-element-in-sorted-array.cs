public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        //use binary search on nums to find target
        //if we find the target at position x then we need to find how far on left and right x is growing
        var ans = new int[]{-1,-1};
        var low = 0;
        var high = nums.Length - 1;
        var pos = Search(nums, 0, high, target);
        if(pos == -1) return ans;
        //we can divide the search space from 0 to x and x to len
        //we again run binary search on updated space to find pos of x
        //we will keep dividing the space until we dont find the target
        ans = new int[]{ pos, pos };
        while(pos != -1){
            //search left
            pos = Search(nums, low, pos - 1, target);
            if(pos != -1){
                ans[0] = pos;
            }
        }
        pos = ans[1];
        while(pos != -1){
            //search right
            pos = Search(nums, pos + 1, high, target);
            if(pos != -1){
                ans[1] = pos;
            }
        }

        return ans;
    }

    int Search(int[] nums, int low, int high, int target){
        if(low > high) return -1;
        var mid = (low + high)/2;
        if(nums[mid] == target){
            return mid;
        }else if(nums[mid] < target){
            return Search(nums, mid + 1, high, target);
        }else{
            return Search(nums, low, mid - 1, target);
        }
    }
}