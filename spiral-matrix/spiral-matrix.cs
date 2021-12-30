public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        int top = 0, left = 0, bottom = m - 1, right = n - 1;
        
        List<int> ans = new List<int>();
        var size = m * n;
        while(ans.Count < size){
            for(int i = left; i <= right && ans.Count < size; i++){
                ans.Add(matrix[top][i]);
            }
            top++;
            for(int i = top; i <= bottom && ans.Count < size; i++){
                ans.Add(matrix[i][right]);
            }
            right--;
            for(int i = right; i >= left && ans.Count < size; i--){
                ans.Add(matrix[bottom][i]);
            }
            bottom--;
            for(int i = bottom; i >= top && ans.Count < size; i--){
                ans.Add(matrix[i][left]);
            }
            left++;
        }
        
        return ans;
    }
}