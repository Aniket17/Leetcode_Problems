public class Solution {
    public void Rotate(int[][] matrix) {
        int size = matrix.Length;
        Transpose(matrix);
        Reverse(matrix);
    }
    
    private void Transpose(int[][] matrix){
        //transpose operation is moving diagonally and swapping i and j elements
        for(int row = 0; row < matrix.Length; row++){
            for(int col = row + 1; col < matrix[0].Length; col++){
                var temp = matrix[row][col];
                matrix[row][col] = matrix[col][row];
                matrix[col][row] = temp;
            }
        }
    }
    
    private void Reverse(int[][] matrix){
        //Reverse operation is applied only on rows
        for(int row = 0; row < matrix.Length; row++){
            var left = 0;
            var right = matrix[0].Length - 1;
            while(left < right){
                var temp = matrix[row][left];
                matrix[row][left] = matrix[row][right];
                matrix[row][right] = temp;
                left++;
                right--;
            }
        }
    }
}