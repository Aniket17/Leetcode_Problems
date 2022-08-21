public class Solution {
    int min = int.MaxValue;
    public int MinPathSum(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if(i == m - 1 && j != n - 1)
                    grid[i][j] = grid[i][j] +  grid[i][j + 1];
                else if(j == n - 1 && i != m - 1)
                    grid[i][j] = grid[i][j] + grid[i + 1][j];
                else if(j != n - 1 && i != m - 1)
                    grid[i][j] = grid[i][j] + Math.Min(grid[i + 1][j],grid[i][j + 1]);
            }
        }
        return grid[0][0];
    }
}