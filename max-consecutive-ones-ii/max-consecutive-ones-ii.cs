/**
Given a binary array nums, return the maximum number of consecutive 1's in the array if you can flip at most one 0.

e.g [1,0,1,1,0] => 4

// brute force - loop over all sub arrays n^2
// sliding window - find sub max len subarray with atmost one 0
e.g [1,0,1,1,0]

i   j   count   lastZero
0   0   1       -1
0   1   2        1
0   2   3        1
0   3   4        1
2   4   3        4   


[0,0]
*/

public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        if(nums.Length == 0) return 0;
        var maxLen = 0;
        var lastZeroPos = -1;
        var i = 0;
        for(int j = 0; j < nums.Length; j++){
            if(nums[j] == 1) continue;
            if(lastZeroPos == -1){
                lastZeroPos = j; 
            }else{
                maxLen = Math.Max(j - i, maxLen);
                i = lastZeroPos + 1;
                lastZeroPos = j;
            }
        }
        maxLen = Math.Max(nums.Length - i, maxLen);
        return maxLen;
    }
}