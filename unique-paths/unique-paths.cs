public class Solution {
    public int UniquePaths(int m, int n) {
        var grid = new int[m + 1][];
        for(int i = 0; i <= m; i++){
            var arr = new int[n + 1];
            Array.Fill(arr, 1);
            grid[i] = arr;
        }
        for(int i = 1; i < m; i++){
            for(int j = 1; j < n; j++){
               grid[i][j] = grid[i - 1][j] + grid[i][j-1]; 
            }
        }
        return grid[m - 1][n - 1];
    }
}