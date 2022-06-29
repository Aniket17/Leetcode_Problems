/*
[
[5,1,9,11],
[2,4,8,10],
[13,3,6,7],
[15,14,12,16]
]
Transpose =>
[
[5,2,13,15],
[1,4,3,14],
[9,8,6,12],
[11,10,7,16]
]
Reverse =>
[
[15,13,2,5],
[14,3,4,1],
[12,6,8,9],
[16,7,10,11]
]

*/

public class Solution {
    public void Rotate(int[][] matrix) {
        Transpose(matrix);
        Reverse(matrix);
    }
    
    private void Transpose(int[][] matrix){
        var m = matrix.Length;
        var n = matrix[0].Length;
        
        for(int row = 0; row < m; row++){
            for(int col = row + 1; col < n; col++){
                Swap(matrix, row, col);
            }
        }
    }
    
    private void Reverse(int[][] matrix){
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
    
    private void Swap(int[][] matrix, int row, int col){
        var tmp = matrix[row][col];
        matrix[row][col] = matrix[col][row];
        matrix[col][row] = tmp;
    }
}