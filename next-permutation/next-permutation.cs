public class Solution {
    public void NextPermutation(int[] nums) {
        var len = nums.Length;
        var swapPos = -1;
        for(int i = len - 1; i > 0; i--){
            if(nums[i] > nums[i - 1]){
                swapPos = i;
                break;
            }
        }
        if(swapPos > 0){
            int j = nums.Length - 1;
            while (nums[j] <= nums[swapPos - 1]) {
                j--;
            }
            Swap(nums, swapPos - 1, j);
            SortAsc(nums, swapPos);
            return;
        }
        Array.Reverse(nums);
        return;
    }
    
    
    private void Swap(int[] nums, int pos1, int pos2){
        var temp = nums[pos1];
        nums[pos1] = nums[pos2];
        nums[pos2] = temp;
    }
    
    private void SortAsc(int[] nums, int pos){
        var left = pos;
        var right = nums.Length - 1;
        while(left < right){
            Swap(nums, right, left);
            left++;
            right--;
        }
    }
}

/*
start from end
if current digit > i - 1, swap, return

[1,2,1,0]
[2,0,1,1]

[2,0,1,1]

*/