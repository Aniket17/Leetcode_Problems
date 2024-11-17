public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var right = GetNextMinimumIndices(heights);
        var left = GetPrevMinimumIndices(heights);
        var maxArea = 0;
        for(int i = 0; i < heights.Length; i++){
            var width = right[i] - left[i] - 1;
            var height = heights[i];
            maxArea = Math.Max(maxArea, Math.Abs(width * height));
        }
        return maxArea;
    }
    
    private int[] GetNextMinimumIndices(int[] heights){
        var stack = new Stack<int>();
        var n = heights.Length;
        var ans = new int[n];
        stack.Push(heights.Length);
        for(int i = n - 1; i >= 0; i--){
            if(stack.Peek() == heights.Length){
                ans[i] = stack.Peek();
                stack.Push(i);
                continue;
            }
            if(heights[stack.Peek()] < heights[i]){
                ans[i] = stack.Peek();
            }else{
                while(stack.Count > 1 && heights[stack.Peek()] >= heights[i]){
                    stack.Pop();
                }
                ans[i] = stack.Peek();
            }
            stack.Push(i);
        }
        return ans;
    }
    private int[] GetPrevMinimumIndices(int[] heights){
        var stack = new Stack<int>();
        var n = heights.Length;
        var ans = new int[n];
        stack.Push(-1);
        for(int i = 0; i < n; i++){
            if(stack.Peek() == -1){
                ans[i] = stack.Peek();
                stack.Push(i);
                continue;
            }
            if(heights[stack.Peek()] < heights[i]){
                ans[i] = stack.Peek();
            }else{
                while(stack.Count > 1 && heights[stack.Peek()] >= heights[i]){
                    stack.Pop();
                }
                ans[i] = stack.Peek();
            }
            stack.Push(i);
        }
        return ans;
    }
}
