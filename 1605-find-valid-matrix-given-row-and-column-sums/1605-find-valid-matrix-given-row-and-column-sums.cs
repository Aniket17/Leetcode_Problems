public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int rows = rowSum.Length, cols = colSum.Length;
        
        int[][] result = new int[rows][];
        
        for(int i=0; i<rows; ++i){
            result[i] = new int[cols];
            for(int j=0; j<cols; ++j) {
                if(i == j) {
                    result[i][j] = Math.Min(rowSum[i], colSum[i]);
                    
                    rowSum[i] -= result[i][j];
                    colSum[i] -= result[i][j];
                }
            }
        }
        
        for(int j=0; j<cols; ++j) 
        {
            for(int i=0; i<rows; ++i) {
                
                if(result[i][j] != 0) 
                    continue;
                
                result[i][j] = Math.Min(rowSum[i], colSum[j]);
                
                rowSum[i] -= result[i][j];
                colSum[j] -= result[i][j];
            }
        }
        return result;
    }
}