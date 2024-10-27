public class Solution {
    public void Rotate(int[][] matrix) {
        Transpose(matrix);
        ReverseRows(matrix);
    }

    void Transpose(int[][] matrix){
        int m = matrix.Length, n = matrix[0].Length;
        for(int row = 0; row < m; row++){
            for(int col = row + 1; col < n; col++){
                Swap(matrix, row, col);
            }
        }
    }

    void Swap(int[][] matrix, int row, int col){
        var tmp = matrix[row][col];
        matrix[row][col] = matrix[col][row];
        matrix[col][row] = tmp;
    }

    void ReverseRows(int[][] matrix){
        int m = matrix.Length;
        for(int row = 0; row < m; row++){
            ReverseRow(matrix, row);
        }
    }

    void ReverseRow(int[][] matrix, int row){
        var n = matrix[0].Length;
        int i = 0, j = n-1;
        while(i <= j){
            var tmp = matrix[row][i];
            matrix[row][i] = matrix[row][j];
            matrix[row][j] = tmp;
            i++; j--;
        }
    }
}