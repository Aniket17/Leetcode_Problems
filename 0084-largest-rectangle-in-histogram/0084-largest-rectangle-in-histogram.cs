public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var n = heights.Length;
        var minStack = new Stack<int>();
        minStack.Push(-1);
        var maxArea = 0;
        for(int i = 0; i < n; i++){
            while(minStack.Peek() != -1 && heights[i] <= heights[minStack.Peek()]){
                //pop and calculate
                var top = minStack.Pop();
                var currHeight = heights[top];
                var currWidth = i - minStack.Peek() - 1;
                maxArea = Math.Max(maxArea, currHeight * currWidth);
            }

            minStack.Push(i);
        }
        while(minStack.Peek() != -1){
            var top = minStack.Pop();
            var currHeight = heights[top];
            var currWidth = n - minStack.Peek() - 1;
            maxArea = Math.Max(maxArea, currHeight * currWidth);
        }
        return maxArea;
    }
}

/*
[2,1,5,6,2,3]

i   max stack
0   0   0,-1
1   2   -1
*/