public class Solution {
    public void SetZeroes(int[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        int[] rows = new int[m];
        int[] cols = new int[n];
        Array.Fill(rows, -1);
        Array.Fill(cols, -1);
        
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                if(matrix[row][col] == 0){
                    rows[row] = 0;
                    cols[col] = 0;
                }
            }
        }
        
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                if(rows[row] == 0 || cols[col] == 0){
                    matrix[row][col] = 0;
                }        
            }
        }
    }
}