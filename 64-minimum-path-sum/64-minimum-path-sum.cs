public class Solution {
    public int MinPathSum(int[][] grid) {
        for (int i = grid.Length - 1; i >= 0; i--) {
            for (int j = grid[0].Length - 1; j >= 0; j--) {
                if(i == grid.Length - 1 && j != grid[0].Length - 1)
                    grid[i][j] = grid[i][j] +  grid[i][j + 1];
                else if(j == grid[0].Length - 1 && i != grid.Length - 1)
                    grid[i][j] = grid[i][j] + grid[i + 1][j];
                else if(j != grid[0].Length - 1 && i != grid.Length - 1)
                    grid[i][j] = grid[i][j] + Math.Min(grid[i + 1][j],grid[i][j + 1]);
            }
        }
        return grid[0][0];
    }
}

/*
[[1,2,3],
[4,5,6]]
*/