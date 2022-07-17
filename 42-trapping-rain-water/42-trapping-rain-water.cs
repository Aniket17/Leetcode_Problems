public class Solution {
    public int Trap(int[] heights) {
        var n = heights.Length;
        var left = new int[n];
        var right = new int[n];
        left[0] = heights[0];
        for(int i = 1; i < n; i++){
            left[i] = Math.Max(left[i - 1], heights[i]);
        }
        right[n - 1] = heights[n - 1];
        for(int i = n - 2; i >= 0; i--){
            right[i] = Math.Max(right[i + 1], heights[i]);
        }
        var area = 0;
        for(int i = 0; i < n; i++){
            area += Math.Min(left[i], right[i]) - heights[i];
        }
        return area;
    }
}

/*
b - [0,1,0,2,1,0,1,3,2,1,2,1]

r - [0,1,1,2,2,2,2,3,3,3,3,3]
l - [3,3,3,3,3,3,3,3,2,2,2,1]
a - [0,0,1,0,1,2,1,0,0,1,0,0]
*/