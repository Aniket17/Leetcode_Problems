public class Solution {
     int[][] _dirs = new int[][]{
        new int[]{0,1},
        new int[]{1,0},
    };
    int[] memo;
    public int UniquePathsWithObstacles(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        memo = new int[m*n];
        Array.Fill(memo, -1);
        if(grid[m-1][n-1] == 1 || grid[0][0] == 1) return 0;
        return ExplorePaths(0, 0, m, n, grid);
    }
    
    private int ExplorePaths(int i, int j, int m, int n, int[][] grid){
        if(i == m - 1 && j == n - 1){
            return 1;
        }
        var key = i*n+j;
        if(memo[key] != -1) return memo[key];
        var max = 0;
        foreach(var dir in _dirs){
            var row = i+dir[0];
            var col = j+dir[1];
            if(IsValid(row, col, m, n) && grid[row][col] == 0){
                max += ExplorePaths(row, col, m, n, grid);
            }
        }
        return memo[key] = max;
    }
    
    bool IsValid(int row, int col, int m, int n){
        if(row < 0 || col < 0 || row >= m || col >= n){
            return false;
        }
        return true;
    }
}