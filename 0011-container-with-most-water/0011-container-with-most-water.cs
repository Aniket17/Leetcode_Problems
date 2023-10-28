public class Solution {
    public int MaxArea(int[] height) {
        var left = 0;
        var right = height.Length - 1;
        var maxArea = 0;
        
        while(left < right){
            var minHeight = Math.Min(height[left], height[right]);
            maxArea = Math.Max(maxArea, minHeight * (right-left));
            if(height[left] < height[right]){
                left++;
            }else if(height[left] > height[right]){
                right--;
            }else{
                left++;
            }
        }

        return maxArea;
    }
}