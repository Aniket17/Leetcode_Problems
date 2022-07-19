public class Solution {
    public int HeightChecker(int[] heights) {
        var sorted = heights.OrderBy(x=>x).ToArray();
        int count = 0;
        for(int i = 0; i < heights.Length; i++){
            if(heights[i] != sorted[i]) count++;
        }
        return count;
    }
}