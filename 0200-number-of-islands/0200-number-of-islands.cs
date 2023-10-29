public class Solution {
    public int NumIslands(char[][] grid) {
        var m = grid.Length; 
        var n = grid[0].Length;
        var visited = new HashSet<int>();
        var totalIslands = 0;

        for(var row = 0; row < m; row++){
            for(var col = 0; col < n; col++){
                if(grid[row][col] == '1' && !visited.Contains(row*n+col)){
                    totalIslands++;
                    VisitIsland(grid, row, col, m, n, visited);
                }
            }
        }
        return totalIslands;
    }
    void VisitIsland(char[][] grid, int row, int col, int m, int n, HashSet<int> visited){
        if(row >= m || row < 0 || col < 0 || col >= n) return;
        if(grid[row][col] == '0' || visited.Contains(row*n+col)) return;
        var dirs = new int[4][]{ new int[] {0,1}, new int[] {1,0}, new int[] {0,-1}, new int[] {-1, 0} };
        visited.Add(row*n+col);
        foreach(var dir in dirs){
            VisitIsland(grid, row+dir[0], col+dir[1], m, n, visited);
        }
    }
}