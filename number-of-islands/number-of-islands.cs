public class Solution {
    public int NumIslands(char[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        var count  = 0;
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                if(grid[row][col] == '1'){
                    MarkZeros(grid, row, col);
                    count++;
                }
           }
        }
        return count;
    }
    private void MarkZeros(char[][] grid, int i, int j){
        if(!IsValid(grid, i, j)) return;
        grid[i][j] = '0';
        MarkZeros(grid, i, j + 1);
        MarkZeros(grid, i, j - 1);
        MarkZeros(grid, i + 1, j);
        MarkZeros(grid, i - 1, j);
    }

    private bool IsValid(char[][] grid, int i, int j){
        if(i < 0 || j < 0 || i > grid.Length - 1 || j > grid[0].Length - 1 || grid[i][j] == '0'){
            return false;
        }
        return true;
    }

}
