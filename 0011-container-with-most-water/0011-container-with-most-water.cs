public class Solution {
    public int MaxArea(int[] height) {
        //brute force:
        //find all combinations in n^2 time and check the areas
        //optimal: as area will be maximized with how far apart the lines are and how tall the lines are
        //we can use two pointer approach here and start with max far apart lines, i.e. left and right
        //and we will continue to move the pointer which leads us to max height
        int left = 0, right = height.Length - 1, n = height.Length, maxArea = 0;
        while(left < right){
            maxArea = Math.Max(maxArea, (right-left) * Math.Min(height[left], height[right]));
            if(height[left] < height[right]){
                //move the left hoping it will give better height
                left++;
            }else{
                right--;
            }
        }
        return maxArea;
    }
}