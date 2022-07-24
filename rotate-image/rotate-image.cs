public class Solution {
    public void Rotate(int[][] matrix) {
        Transpose(matrix);
        for(int row = 0; row<matrix.Length;row++){
            SwapRowElements(matrix, row);
        }
    }
    void Transpose(int[][] matrix){
        var m = matrix.Length;
        for(int i=0; i<m;i++){
            for(int j=0; j<m;j++){
                if(i == j) break;
                var tmp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = tmp;
            }
        }
    }
    
    void SwapRowElements(int[][] matrix, int row){
        var m = matrix.Length;
        int i = 0, j = m - 1;
        while(i < j){
            var tmp = matrix[row][i];
            matrix[row][i] = matrix[row][j];
            matrix[row][j] = tmp;
            i++;
            j--;
        }
    }
}