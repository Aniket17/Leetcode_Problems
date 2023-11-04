public class Solution {
    public int Trap(int[] height) {
        var n = height.Length;
        var left = new int[n];
        var right = new int[n];
        
        left[0] = height[0];
        right[n-1] = height[n-1];
        for(int i = 1; i < n; i++){
            left[i] = Math.Max(left[i-1], height[i]);
        }

        for(int i = n - 2; i >= 0; i--){
            right[i] = Math.Max(right[i+1], height[i]);
        }

        var total = 0;
        for(int i = 1; i < n-1; i++){
            total += Math.Max(0, Math.Min(left[i], right[i]) - height[i]);
        }
        return total;
    }
}

/*
[4,2,0,3,2,5]
nge => [5,3,3,5,5,5]
len=5
20

*/