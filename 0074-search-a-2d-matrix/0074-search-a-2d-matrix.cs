public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length;
        int left = 0, right = m * n - 1;
        while(left <= right){
            var mid = (left + right)/2;
            var (row,col) = GetCords(mid, n);
            if(matrix[row][col] < target){
                //move left
                left++;
            }else if(matrix[row][col] > target){
                //move right
                right--;
            }else{
                //equal
                return true;
            }
        }
        return false;
    }
    private (int row, int col) GetCords(int index, int n) => (index / n, index % n);
}