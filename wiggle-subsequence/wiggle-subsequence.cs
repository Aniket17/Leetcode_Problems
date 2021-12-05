/*
A wiggle sequence is a sequence where the differences between successive numbers strictly alternate between positive and negative. The first difference (if one exists) may be either positive or negative. A sequence with one element and a sequence with two non-equal elements are trivially wiggle sequences.

For example, [1, 7, 4, 9, 2, 5] is a wiggle sequence because the differences (6, -3, 5, -7, 3) alternate between positive and negative.
In contrast, [1, 4, 7, 2, 5] and [1, 7, 4, 5, 5] are not wiggle sequences. The first is not because its first two differences are positive, and the second is not because its last difference is zero.
A subsequence is obtained by deleting some elements (possibly zero) from the original sequence, leaving the remaining elements in their original order.

Given an integer array nums, return the length of the longest wiggle subsequence of nums.

// brute force - loop over all sub arrays, T(n) = O(N^2), S(n) = O(1)
// sliding window

start with j = 1
check if sides (j + 1, j - 1) are both greater or are both smaller..
.. if there are two consecutive greaters or smallers, move i to lastFoundMisMatch
.. or move j


*/

public class Solution {
    public int WiggleMaxLength(int[] nums) {
        if(nums.Length < 2) return nums.Length;
        bool? isGreater = null;
        var i = 0;
        for(int j = 1; j < nums.Length; j++){
            if(nums[j - 1] == nums[j])
            {
                i++;
                continue;
            }
            if(isGreater == null){
                isGreater = nums[j - 1] > nums[j];
                continue;
            }
            if (nums[j - 1] < nums[j] && !isGreater.Value)
            {
                //breaks rule - last sq was smaller(!isGreater) and this is smaller too
                //skip
                i++;
            }else if (nums[j - 1] > nums[j] && isGreater.Value)
            {
                //breaks rule - last sq was Greater and this is Greater too
                //skip
                i++;
            }
            isGreater = nums[j - 1] > nums[j];
        }
        return nums.Length - i;
    }
}


/*
[1,17,5,10,13,15,10,5,16,8]
[0,1, 0, 1, 1, 1, 0,0, 1,0]
*/