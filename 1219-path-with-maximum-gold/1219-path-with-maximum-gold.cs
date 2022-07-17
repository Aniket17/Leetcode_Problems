public class Solution {
    int[][] directions = new int[][]{
        new int[]{1,0},
        new int[]{0,1},
        new int[]{-1,0},
        new int[]{0,-1},
    };
    Dictionary<string, int> memo = new Dictionary<string, int>(); //stores max gold that can be collected from this pos.
    public int GetMaximumGold(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        HashSet<string> seen = new HashSet<string>();
        var max = 0;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 0 || seen.Contains($"{i},{j}")) continue;
                seen.Add($"{i},{j}");
                var ans = grid[i][j] + CollectGold(grid, i, j, seen);
                max = Math.Max(max, ans);
                seen.Remove($"{i},{j}");
            }
        }
        
        return max;
    }
    
    private int CollectGold(int[][] grid, int i, int j, HashSet<string> seen){
        var m = grid.Length;
        var n = grid[0].Length;
        if(i < 0 || j < 0 || i >= m || j >= n) return 0;
        if(grid[i][j] == 0) return 0;
        var max = 0;
        foreach(var dir in directions){
            var row = i + dir[0];
            var col = j + dir[1];
            if(row < 0 || col < 0 || row >= m || col >= n  || grid[row][col] == 0 || seen.Contains($"{row},{col}"))
            {
                continue;
            }
            seen.Add($"{row},{col}");
            max = Math.Max(max, grid[row][col] + CollectGold(grid, row, col, seen));
            seen.Remove($"{row},{col}");
        }
        return max;
    }
}