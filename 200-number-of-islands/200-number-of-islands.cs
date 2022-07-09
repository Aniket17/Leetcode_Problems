public class Solution {
    int[][] dirs = new int[4][]{
        new int[2]{1,0},
        new int[2]{0,1},
        new int[2]{0,-1},
        new int[2]{-1,0},
    };
    public int NumIslands(char[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        var count = 0;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == '1'){
                    Visit(grid, i, j);
                    count++;
                }
            }
        }
        return count;
    }
    
    void Visit(char[][] grid, int i, int j){
        var m = grid.Length;
        var n = grid[0].Length;
        if(i < 0 || j < 0 || i >= m || j >= n || grid[i][j] == '0'){
            return;
        }
        grid[i][j] = '0';
        foreach(var dir in dirs){
            var row = i + dir[0];
            var col = j + dir[1];
            Visit(grid, row, col);
        }
    }
}