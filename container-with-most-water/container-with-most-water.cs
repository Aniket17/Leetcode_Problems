public class Solution {
    public int MaxArea(int[] heights) {
        var n = heights.Length;
        var max = 0;
        int i = 0, j = n-1;
        while(i < j){
            max = Math.Max(Math.Min(heights[i], heights[j]) * (j-i), max);
            if(heights[j] > heights[i]){
                i++;
            }else{
                j--;
            }
        }
        return max;
    }
}

/*
[1,8,6,2,5,4,8,3,7]


*/