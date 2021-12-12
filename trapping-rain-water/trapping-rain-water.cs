public class Solution {
    public int Trap(int[] height) {
        var n = height.Length;
        var left = new int[n];
        var right = new int[n];
        left[0] = height[0];
        for(int i = 1; i <  n; i++){
            left[i] = Math.Max(height[i], left[i-1]);
        }
        right[n - 1] = height[n - 1];
        for(int i = n - 2; i >= 0; i--){
            right[i] = Math.Max(height[i], right[i+1]);
        }
        
        var max = 0;
        for(int i = 1; i < n - 1; i++){
            max += Math.Min(right[i], left[i]) - height[i];
        }
        return max;
    }
}

/*
b - [0,1,0,2,1,0,1,3,2,1,2,1]

r - [0,1,1,2,2,2,2,3,3,3,3,3]
l - [3,3,3,3,3,3,3,3,2,2,2,1]

a - [0,0,1,0,1,2,1,0,0,1,0,0]

*/