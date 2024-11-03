public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        // start with second last row, calc matrix(row, col) = Min((row + 1, col - 1), (row + 1, col), (row + 1, col + 1))
        //move upwards until we reach row, col < 0
        //scan the first row
        int m = matrix.Length, n = matrix[0].Length;
        if(m == 1) return matrix[m-1].Min();
        for(int row = m - 2; row >= 0; row--){
            for(int col = 0; col < n; col++){
                var newRow = row + 1;
                var minPath = int.MaxValue;
                for(int dir = -1; dir <= 1; dir++){
                    var newCol = col + dir;
                    if(newCol < 0 || newCol >= n) continue;
                    minPath = Math.Min(minPath, matrix[newRow][newCol]);
                }
                matrix[row][col] += minPath; 
            }
        }
        return matrix[0].Min();
    }
}