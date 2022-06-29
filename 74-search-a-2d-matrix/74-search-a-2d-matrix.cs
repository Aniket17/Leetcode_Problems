public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var low = 0;
        var high = m * n - 1;
        while(low <= high){
            var mid = (low + high)/2;
            var el = matrix[mid / n][mid % n];
            
            if(el == target) return true;
            else if(el < target){
                low = mid + 1;
            }else{
                high = mid - 1;
            }
        }
        return false;
    }
}