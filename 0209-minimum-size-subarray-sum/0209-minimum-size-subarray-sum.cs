public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int currSum = 0, i = 0, j = 0, minWindow = int.MaxValue;
        while(j < nums.Length){
            currSum += nums[j];
            while(i <= j && currSum >= target){
                minWindow = Math.Min(minWindow, j - i + 1);
                //shrink the window
                currSum -= nums[i];
                i++;
            }
            j++;
        }
        return minWindow == int.MaxValue ? 0 : minWindow;
    }
}

/*
[2,3,1,2,4,3]

*/