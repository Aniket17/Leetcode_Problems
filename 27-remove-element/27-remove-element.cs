/*
[0,1,2,2,3,0,2,4,2], 2
[0,1,_,_,3,0,_,4,_]
[0,1,_,_,3,0,4,4,_] 
[0,1,3,_,3,0,4,4,_]
[0,1,3,0,3,0,4,4,_]
*/

public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var count = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == val){
                nums[i] = int.MaxValue;
                count++;
            }
        }
        Array.Sort(nums);
        return nums.Length - count;
    }
}
