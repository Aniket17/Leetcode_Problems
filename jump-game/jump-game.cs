public class Solution {
    public bool CanJump(int[] nums) {
        int size = nums.Length;
        if(size <=1) return true; 
        int badIndex = 0;
        for(int i = size - 2; i >=0; i--){
              if(nums[i] <= badIndex){
                    badIndex++;
              }else{
                    badIndex = 0;
              }
        }
        return nums[0] > badIndex;
    }
}

/*
[3,2,1,0,4]
[3,I,I,I,0]
*/